using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;
using System.Management;

namespace IdleEth
{
    /*CALLBACKS FOR ASYNC INTERFACE UPDATES*/
    delegate void SetStartEnabledCallback(bool enabled);
    delegate void SetStopEnabledCallback(bool enabled);

    public partial class Form1 : Form
    {
        /*LOCAL VARIABLES*/

        private static System.Timers.Timer idleTimer; //for checking idle time
        private Process minerProcess; //miner process
        private string filesPath; //path to the folder in roaming
        private string clientPath; //complete path to the mining client

        /*INTERFACE EVENTS*/
        //initialize the form from the designer
        public Form1() => InitializeComponent();

        //on form load
        private void Form1_Load(object sender, EventArgs e)
        {
            //prepare the path variants
            filesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IdleEth");
            Directory.CreateDirectory(filesPath);
            Directory.CreateDirectory(Path.Combine(filesPath,"bin"));
            clientPath = Path.Combine(filesPath, Properties.Settings.Default.MinerFile);

            //set up the idleTimer
            idleTimer = new System.Timers.Timer();
            idleTimer.Interval = 1000;
            idleTimer.Elapsed += IdleTimerEvent;
            idleTimer.AutoReset = true;

            //check for the miner client on start, also enables the timer
            var nothing = DelayMinerClient(); //assigned to supress warning
            
            //set default auto mode
            Properties.Settings.Default.AutoMine = true;

            //attach validation event to the idle wait text box
            IdleWaitTextBox.KeyPress += new KeyPressEventHandler(IdleWaitTextBox_KeyPress);

            //select the active wallet for the wallet combo box and attach the changed event
            WalletComboBox.SelectedIndex = Properties.Settings.Default.ActiveWallet;
            WalletComboBox.SelectedIndexChanged += new EventHandler(WalletComboxBox_SelectedIndexChanged);

            //select the GPU for the GPU combo box and attach the changed event
            GPUComboBox.SelectedIndex = Properties.Settings.Default.GPUType;
            GPUComboBox.SelectedIndexChanged += new EventHandler(GPUComboBox_SelectedIndexChanged);

            //attach validation events to the custom wallet and worker text boxes
            CustomWalletTextBox.TextChanged += new EventHandler(CustomWalletTextBox_TextChanged);
            WorkerTextBox.TextChanged += new EventHandler(WorkerTextBox_TextChanged);

            //attach form closing event
            FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        //auto mine radio buttons, handles both
        private void EnabledRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (EnabledRadioButton.Checked == true)
            {
                Properties.Settings.Default.AutoMine = true;
            }
            else
            {
                Properties.Settings.Default.AutoMine = false;
            }
            Properties.Settings.Default.Save();
        }

        //manual mining buttons
        private void StartManualButton_Click(object sender, EventArgs e)
        {
            if (Mine())
            {
                SetStartEnabled(false);
                SetStopEnabled(true);
                Properties.Settings.Default.ManualMine = true;
            }
        }
        private void StopManualButton_Click(object sender, EventArgs e)
        {
            Stop();
            Properties.Settings.Default.ManualMine = false;
            SetStartEnabled(true);
            SetStopEnabled(false);
        }

        //manual mining buttons async events
        private void SetStartEnabled(bool enabled)
        {
            if (this.StartManualButton.InvokeRequired)
            {
                SetStartEnabledCallback d = new SetStartEnabledCallback(SetStartEnabled);
                this.Invoke(d, new object[] { enabled });
            }
            else
            {
                this.StartManualButton.Enabled = enabled;
            }
        }
        private void SetStopEnabled(bool enabled)
        {
            if (this.StopManualButton.InvokeRequired)
            {
                SetStopEnabledCallback d = new SetStopEnabledCallback(SetStopEnabled);
                this.Invoke(d, new object[] { enabled });
            }
            else
            {
                this.StopManualButton.Enabled = enabled;
            }
        }

        //allow only numbers in the wait time field and edits only when auto mining is disabled
        private void IdleWaitTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnabledRadioButton.Checked == true)
            {
                MessageBox.Show("Disable Auto Mine to change Idle Timer.");
                e.Handled = true; //reject input
            }
            else
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')
                {
                    e.Handled = false; //accept input
                    Properties.Settings.Default.IdleWaitTime = IdleWaitTextBox.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    e.Handled = true; //reject input
                }
            }
        }

        //update the setting value to match the wallet combo box selection
        private void WalletComboxBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ActiveWallet = WalletComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        //update the setting value to match the GPU combo box selection
        private void GPUComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GPUType = GPUComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }


        private void CustomWalletTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CustomWallet = CustomWalletTextBox.Text;
        }

        private void WorkerTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Worker = WorkerTextBox.Text;
        }

        //add to all events: if manual mining, warn

        //event for clean exit and saving settings
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //update the status bar
            ToolStripStatusLabel.Text = "Exiting...";
            Update();

            //prevent the timer from firing as the application closes
            idleTimer.Enabled = false;

            //try to stop any miner processes
            Stop();

            //persist the settings
            Properties.Settings.Default.Save();

            //delay equal to the timer cycle
            System.Threading.Thread.Sleep(1000);
        }

        /*MENU EVENTS*/
        private void ViewPoolToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("https://ethermine.org/miners/" + GetActiveWallet());
        private void ViewWalletToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("https://www.etherchain.org/account/0x" + GetActiveWallet());
        private void OnlineHelpToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("https://github.com/dshawth/IdleEth");
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show(Properties.Settings.Default.IdleWaitTime);
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        /*IDLE TIMER*/
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }
        static uint IdleSeconds()
        {
            uint idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            uint envTicks = (uint)Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                uint lastInputTick = lastInputInfo.dwTime;
                idleTime = envTicks - lastInputTick;
            }

            return ((idleTime > 0) ? (idleTime / 1000) : 0);
        }

        //happens once per second handles all mining events
        private void IdleTimerEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            //auto mode exclusive 
            if ((Properties.Settings.Default.AutoMine == true) && (Properties.Settings.Default.ManualMine == false))
            {
                //timer
                TimeSpan time = TimeSpan.FromSeconds((double)IdleSeconds());
                string output = time.ToString(@"hh\:mm\:ss");
                ToolStripStatusLabel.Text = "Idle Time: " + output;

                int idleTime = 60; //default for safety but unnecessary
                if (Int32.TryParse(Properties.Settings.Default.IdleWaitTime, out idleTime))
                {
                    //if idle time is past and not mining, start
                    if (((int)IdleSeconds() > idleTime) && (minerProcess == null))
                    {
                        Mine();
                    }
                    //mining and idle is less, stop
                    if ((minerProcess != null) && ((int)IdleSeconds() < idleTime))
                    {
                        Stop();
                    }
                }
            }
            else
            {
                //both manual and auto disabled, not mining
            }
        }

        /*MINING FUNCTIONS*/
        //tries to start mining, assignes minerProcess
        private bool Mine()
        {
            bool status = false;
            if (MinerClient())
            {
                string argsString;
                argsString = "--report-hashrate --farm-recheck 200 "; //static args

                //gpu
               switch(Properties.Settings.Default.GPUType)
                {
                    case 0:
                        argsString += "--cuda ";
                        break;
                    case 1:
                        argsString += "--opencl ";
                        break;
                    case 2:
                        argsString += "--opencl "; //!!!!fix me
                        break;
                    default: //should never happen
                        argsString += "";
                        break;
                }

                //!!!!later add server selection
                argsString += "--stratum us1.ethermine.org:5555 ";
                argsString += "--stratum-failover us2.ethermine.org:4444 ";

                //userpass and worker
                argsString += "--userpass " + GetActiveWallet() + "." + Properties.Settings.Default.Worker;

                minerProcess = new Process();
                minerProcess.StartInfo.FileName = clientPath;
                minerProcess.StartInfo.Arguments = argsString;
                minerProcess.EnableRaisingEvents = true;
                minerProcess.Exited += new EventHandler(Miner_Died);
                minerProcess.Start();
                status = true;
            }
            else
            {
                MessageBox.Show("Miner client not ready.");
            }
            return status;
        }

        //tries to stop mining
        private void Stop()
        {
            if (minerProcess != null)
            {
                minerProcess.CloseMainWindow();
                minerProcess.Close();
                minerProcess = null;
            }
        }

        //event when miner process dies
        private void Miner_Died(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ManualMine == true)
            {
                SetStartEnabled(true);
                SetStopEnabled(false);
                Properties.Settings.Default.ManualMine = false;
            }
            minerProcess = null;
            MessageBox.Show("Miner died!");
        }

        //returns the active wallet address
        private string GetActiveWallet()
        {
            string wallet;
            if (Properties.Settings.Default.ActiveWallet < Properties.Settings.Default.Wallets.Count)
            {
                wallet = Properties.Settings.Default.Wallets[Properties.Settings.Default.ActiveWallet];
            }
            else
            {
                //use custom wallet
                wallet = Properties.Settings.Default.CustomWallet;
            }
            return wallet;
        }

        //delayed, async call to MinerClient with warning output
        async Task DelayMinerClient()
        {
            await Task.Delay(2500);
            if (MinerClient())
            {
                await Task.Delay(2500);
                Properties.Settings.Default.AutoMine = true;
            }
            else
            {
                MessageBox.Show("Miner client not ready.");
            }
            idleTimer.Enabled = true;
        }

        //check for the client, prompt user for auto download if not found, return true if ready
        private bool MinerClient()
        {
            //default client not ready
            bool status = false;

            //first check if the client is present and valid
            if (File.Exists(clientPath) && String.Compare(Properties.Settings.Default.MinerSHA1, GetSHA1(clientPath)) == 0)
            {
                //valid
                status = true;
            }
            else //if not
            {
                //ask the user
                DialogResult dialogResult = MessageBox.Show("Download now?", "Miner client not found.", MessageBoxButtons.YesNo);
                //if user says yes
                if (dialogResult == DialogResult.Yes)
                {
                    //try to get the client
                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(new Uri(Properties.Settings.Default.MinerURL), Path.Combine(filesPath, Properties.Settings.Default.MinerZip));
                        }
                    }
                    catch (Exception)
                    {
                        //nothing for now
                    }
                    //try to extract the client
                    try
                    {
                        File.Delete(clientPath);
                    }
                    catch (Exception)
                    {
                        //nothing for now
                    }
                    //extract
                    ZipFile.ExtractToDirectory(Path.Combine(filesPath, Properties.Settings.Default.MinerZip), filesPath);
                    //remove the zip
                    File.Delete(Path.Combine(filesPath, Properties.Settings.Default.MinerZip));
                }
                //check again in case the download worked
                if (File.Exists(clientPath))
                {
                    //validate the file
                    if (String.Compare(Properties.Settings.Default.MinerSHA1, GetSHA1(clientPath)) == 0)
                    {
                        status = true;
                    }
                }
            }
            return status;
        }

        //returns the SHA1 sum of a file
        public string GetSHA1(string filename)
        {
            using (var sha1 = SHA1.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = sha1.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/29667666/how-get-gpu-information-in-c
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController"))
            {

                foreach (ManagementObject mo in searcher.Get())
                {
                    /*foreach (PropertyData property in mo.GetInstances)
                    {
                        if (property.Name == "Description")
                        {
                            
                            if (property.Value.ToString().Contains("Intel"))
                            {
                                GPUCheckedListBox.Items.Add("a", CheckState.Unchecked);
                                GPUCheckedListBox.Items.Add(property.Value.ToString(), CheckState.Unchecked);
                                GPUCheckedListBox.SetItemCheckState(GPUCheckedListBox.Items.Count - 1, CheckState.Indeterminate);
                            }

                        }
                        if (property.Name == "VideoMemoryType")
                        {
                            MessageBox.Show("hi");
                        }
                    }*/
                    MessageBox.Show(String.Format("{0} ", mo["Description"]));
                    MessageBox.Show((Convert.ToInt32(String.Format("{0} ", mo["AdapterRam"])) / 8 / 1024 / 1024).ToString() + " MB");
                }
            }
        }
    }
}