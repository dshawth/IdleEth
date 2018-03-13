namespace IdleEth
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IdleWaitTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DisabledRadioButton = new System.Windows.Forms.RadioButton();
            this.EnabledRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StartManualButton = new System.Windows.Forms.Button();
            this.StopManualButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewPoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewWalletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OnlineHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WalletGroupBox = new System.Windows.Forms.GroupBox();
            this.WorkerTextBox = new System.Windows.Forms.TextBox();
            this.WorkerLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.WalletComboBox = new System.Windows.Forms.ComboBox();
            this.CustomWalletTextBox = new System.Windows.Forms.TextBox();
            this.GPUComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.GPUCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.WalletGroupBox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.IdleWaitTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DisabledRadioButton);
            this.groupBox1.Controls.Add(this.EnabledRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 84);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Mine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seconds Idle";
            // 
            // IdleWaitTextBox
            // 
            this.IdleWaitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::IdleEth.Properties.Settings.Default, "IdleWaitTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IdleWaitTextBox.Location = new System.Drawing.Point(42, 52);
            this.IdleWaitTextBox.MaxLength = 10;
            this.IdleWaitTextBox.Name = "IdleWaitTextBox";
            this.IdleWaitTextBox.Size = new System.Drawing.Size(50, 20);
            this.IdleWaitTextBox.TabIndex = 3;
            this.IdleWaitTextBox.Text = global::IdleEth.Properties.Settings.Default.IdleWaitTime;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "After";
            // 
            // DisabledRadioButton
            // 
            this.DisabledRadioButton.AutoSize = true;
            this.DisabledRadioButton.Location = new System.Drawing.Point(80, 20);
            this.DisabledRadioButton.Name = "DisabledRadioButton";
            this.DisabledRadioButton.Size = new System.Drawing.Size(66, 17);
            this.DisabledRadioButton.TabIndex = 1;
            this.DisabledRadioButton.TabStop = true;
            this.DisabledRadioButton.Text = "Disabled";
            this.DisabledRadioButton.UseVisualStyleBackColor = true;
            // 
            // EnabledRadioButton
            // 
            this.EnabledRadioButton.AutoSize = true;
            this.EnabledRadioButton.Checked = true;
            this.EnabledRadioButton.Location = new System.Drawing.Point(10, 20);
            this.EnabledRadioButton.Name = "EnabledRadioButton";
            this.EnabledRadioButton.Size = new System.Drawing.Size(64, 17);
            this.EnabledRadioButton.TabIndex = 0;
            this.EnabledRadioButton.TabStop = true;
            this.EnabledRadioButton.Text = "Enabled";
            this.EnabledRadioButton.UseVisualStyleBackColor = true;
            this.EnabledRadioButton.CheckedChanged += new System.EventHandler(this.EnabledRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StartManualButton);
            this.groupBox2.Controls.Add(this.StopManualButton);
            this.groupBox2.Location = new System.Drawing.Point(193, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(89, 84);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manual Mine";
            // 
            // StartManualButton
            // 
            this.StartManualButton.Location = new System.Drawing.Point(7, 19);
            this.StartManualButton.Name = "StartManualButton";
            this.StartManualButton.Size = new System.Drawing.Size(75, 23);
            this.StartManualButton.TabIndex = 2;
            this.StartManualButton.Text = "Start";
            this.StartManualButton.UseVisualStyleBackColor = true;
            this.StartManualButton.Click += new System.EventHandler(this.StartManualButton_Click);
            // 
            // StopManualButton
            // 
            this.StopManualButton.Enabled = false;
            this.StopManualButton.Location = new System.Drawing.Point(7, 50);
            this.StopManualButton.Name = "StopManualButton";
            this.StopManualButton.Size = new System.Drawing.Size(75, 23);
            this.StopManualButton.TabIndex = 1;
            this.StopManualButton.Text = "Stop";
            this.StopManualButton.UseVisualStyleBackColor = true;
            this.StopManualButton.Click += new System.EventHandler(this.StopManualButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 402);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(295, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(60, 17);
            this.ToolStripStatusLabel.Text = "Welcome!";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(295, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewPoolToolStripMenuItem,
            this.ViewWalletToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // ViewPoolToolStripMenuItem
            // 
            this.ViewPoolToolStripMenuItem.Name = "ViewPoolToolStripMenuItem";
            this.ViewPoolToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.ViewPoolToolStripMenuItem.Text = "Pool";
            this.ViewPoolToolStripMenuItem.Click += new System.EventHandler(this.ViewPoolToolStripMenuItem_Click);
            // 
            // ViewWalletToolStripMenuItem
            // 
            this.ViewWalletToolStripMenuItem.Name = "ViewWalletToolStripMenuItem";
            this.ViewWalletToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.ViewWalletToolStripMenuItem.Text = "Wallet";
            this.ViewWalletToolStripMenuItem.Click += new System.EventHandler(this.ViewWalletToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OnlineHelpToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // OnlineHelpToolStripMenuItem
            // 
            this.OnlineHelpToolStripMenuItem.Name = "OnlineHelpToolStripMenuItem";
            this.OnlineHelpToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.OnlineHelpToolStripMenuItem.Text = "Online";
            this.OnlineHelpToolStripMenuItem.Click += new System.EventHandler(this.OnlineHelpToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // WalletGroupBox
            // 
            this.WalletGroupBox.Controls.Add(this.WorkerTextBox);
            this.WalletGroupBox.Controls.Add(this.WorkerLabel);
            this.WalletGroupBox.Controls.Add(this.label3);
            this.WalletGroupBox.Controls.Add(this.WalletComboBox);
            this.WalletGroupBox.Controls.Add(this.CustomWalletTextBox);
            this.WalletGroupBox.Location = new System.Drawing.Point(12, 117);
            this.WalletGroupBox.Name = "WalletGroupBox";
            this.WalletGroupBox.Size = new System.Drawing.Size(270, 94);
            this.WalletGroupBox.TabIndex = 10;
            this.WalletGroupBox.TabStop = false;
            this.WalletGroupBox.Text = "Wallet";
            // 
            // WorkerTextBox
            // 
            this.WorkerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::IdleEth.Properties.Settings.Default, "Worker", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.WorkerTextBox.Location = new System.Drawing.Point(139, 32);
            this.WorkerTextBox.Name = "WorkerTextBox";
            this.WorkerTextBox.Size = new System.Drawing.Size(85, 20);
            this.WorkerTextBox.TabIndex = 4;
            this.WorkerTextBox.Text = global::IdleEth.Properties.Settings.Default.Worker;
            // 
            // WorkerLabel
            // 
            this.WorkerLabel.AutoSize = true;
            this.WorkerLabel.Location = new System.Drawing.Point(140, 16);
            this.WorkerLabel.Name = "WorkerLabel";
            this.WorkerLabel.Size = new System.Drawing.Size(79, 13);
            this.WorkerLabel.TabIndex = 3;
            this.WorkerLabel.Text = "Worker (Name)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Custom";
            // 
            // WalletComboBox
            // 
            this.WalletComboBox.FormattingEnabled = true;
            this.WalletComboBox.Items.AddRange(new object[] {
            "Developer",
            "Crypto Club",
            "Libra Gaming",
            "Custom"});
            this.WalletComboBox.Location = new System.Drawing.Point(6, 19);
            this.WalletComboBox.Name = "WalletComboBox";
            this.WalletComboBox.Size = new System.Drawing.Size(101, 21);
            this.WalletComboBox.TabIndex = 1;
            // 
            // CustomWalletTextBox
            // 
            this.CustomWalletTextBox.Location = new System.Drawing.Point(6, 63);
            this.CustomWalletTextBox.Name = "CustomWalletTextBox";
            this.CustomWalletTextBox.Size = new System.Drawing.Size(257, 20);
            this.CustomWalletTextBox.TabIndex = 0;
            this.CustomWalletTextBox.Text = global::IdleEth.Properties.Settings.Default.CustomWallet;
            // 
            // GPUComboBox
            // 
            this.GPUComboBox.FormattingEnabled = true;
            this.GPUComboBox.Items.AddRange(new object[] {
            "Nvidia",
            "AMD",
            "Both"});
            this.GPUComboBox.Location = new System.Drawing.Point(6, 19);
            this.GPUComboBox.Name = "GPUComboBox";
            this.GPUComboBox.Size = new System.Drawing.Size(74, 21);
            this.GPUComboBox.TabIndex = 11;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.GPUComboBox);
            this.groupBox5.Controls.Add(this.GPUCheckedListBox);
            this.groupBox5.Location = new System.Drawing.Point(12, 217);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(270, 168);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "GPU";
            // 
            // GPUCheckedListBox
            // 
            this.GPUCheckedListBox.FormattingEnabled = true;
            this.GPUCheckedListBox.Location = new System.Drawing.Point(6, 46);
            this.GPUCheckedListBox.Name = "GPUCheckedListBox";
            this.GPUCheckedListBox.Size = new System.Drawing.Size(257, 79);
            this.GPUCheckedListBox.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 424);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.WalletGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "IdleEth";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.WalletGroupBox.ResumeLayout(false);
            this.WalletGroupBox.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button StopManualButton;
        private System.Windows.Forms.RadioButton EnabledRadioButton;
        private System.Windows.Forms.RadioButton DisabledRadioButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox IdleWaitTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem OnlineHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.GroupBox WalletGroupBox;
        private System.Windows.Forms.TextBox CustomWalletTextBox;
        private System.Windows.Forms.TextBox WorkerTextBox;
        private System.Windows.Forms.Label WorkerLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox WalletComboBox;
        private System.Windows.Forms.ComboBox GPUComboBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewPoolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewWalletToolStripMenuItem;
        private System.Windows.Forms.Button StartManualButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox GPUCheckedListBox;
    }
}

