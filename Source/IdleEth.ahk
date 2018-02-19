#CommentFlag //
//OTHER FLAGS
  #Persistent //stay open until explicitly closed
  #SingleInstance Force //one instance only duplicates close
  #NoEnv //performance and compatibility with future releases
  #Warn //warnings for debugging
  SendMode Input //input speed and reliability
  SetWorkingDir %A_ScriptDir% //ensure consistent starting directory


//PACKAGE
  //folder
  FileCreateDir, %A_WorkingDir%\IdleEthFiles
  //files | run: extract, do not overwrite | compile: package the current file
  //config
  FileInstall, config.dat, %A_WorkingDir%\IdleEthFiles\config.dat, 0
  //miner
  FileInstall, ethminer-0.13.0.exe, %A_WorkingDir%\IdleEthFiles\ethminer-0.13.0.exe, 0
  //icon
  FileInstall, ethereum-logo-3.ico, %A_WorkingDir%\IdleEthFiles\ethereum-logo-3.ico, 0


//GLOBALS
  //booleans for mode
  AutoMine = 1
  ManualMine = 0
  
  //to track the miner process ID
  MinerPID = 0
  
  //default idle time
  IdleTimeSeconds = 60
  
  //to track how much time spent mining
  MineTimeSeconds = 0
  
  //wallets
  DevWallet = 70eaf0909e96463bddc2d099cbaa0052cddffaf2 //1
  ClubWallet = 96Af7CdaD701AD7fEb2D5c445c591Dd1DD7773A1 //2
  LibraWallet = 97F78C05b7a59465BE2E9640Baa4E13Fa35ccE0D //3
  CustomWallet = %DevWallet% //4
  
  //default wallet
  ActiveWalletNumber = 1
  
  //worker
  Worker = default
  
  //GPU
  GPUType = 1 //1: Nvidia, 2: AMD
  
  //all defaults set will be overwritten by values loaded from config file below
  //they are set above as failsafes for modified config files
  //missing config files contain the same values as they are generated on run

  
//CONFIG
  NextField=0
  Loop, Read, %A_WorkingDir%\IdleEthFiles\config.dat
  {
    Loop, Parse, A_LoopReadLine, %A_Tab%
    {
      //idle time
      If (A_Index=1) and (A_LoopField="IdleTimeSeconds") {
        NextField=1
      }
      If (A_Index=2) and (NextField=1) {
        IdleTimeSeconds=%A_LoopField%
        nextField=0
      }
      //custom wallet
      If (A_Index=1) and (A_LoopField="CustomWallet") {
        NextField=2
      }
      If (A_Index=2) and (NextField=2) {
        CustomWallet=%A_LoopField%
        nextField=0
      }
      //active wallet number
      If (A_Index=1) and (A_LoopField="ActiveWalletNumber") {
        NextField=3
      }
      If (A_Index=2) and (NextField=3) {
        ActiveWalletNumber=%A_LoopField%
        nextField=0
      }
      //worker
      If (A_Index=1) and (A_LoopField="Worker") {
        NextField=4
      }
      If (A_Index=2) and (NextField=4) {
        Worker=%A_LoopField%
        nextField=0
      }
      //gpu type
      If (A_Index=1) and (A_LoopField="GPUType") {
        NextField=5
      }
      If (A_Index=2) and (NextField=5) {
        GPUType=%A_LoopField%
        nextField=0
      }
    }
  }


//GUI
  //main window
  Gui, IdleEthMain:New, , IdleEth Main
  Gui, IdleEthMain:Default
  
  //icon
  Menu, Tray, Icon, %A_WorkingDir%\IdleEthFiles\ethereum-logo-3.ico
  
  //menu bar sub menus
  Menu, FileMenu, Add, E&xit, FileExit
  Menu, HelpMenu, Add, &About, HelpAbout

  //attach sub menus
  Menu, MainMenuBar, Add, &File, :FileMenu
  Menu, MainMenuBar, Add, &Help, :HelpMenu

  //attach the menu bar to the window
  Gui, Menu, MainMenuBar
  
  //enabled description and radio buttons
  Gui, Add, Text, , Automatically mine when your PC idles:
  Gui, Add, Radio, vEnabledRadio gEnabledRadioEvent Checked, Enabled
  Gui, Add, Radio, gEnabledRadioEvent, Disabled
  
  //idle time description, edit box, and save button
  Gui, Add, Text, , Idle seconds:
  Gui, Add, Text, xm, Wait:
  Gui, Add, Edit, x+m yp w40 vWaitSecondsEdit, %IdleTimeSeconds%
  Gui, Add, Button, x+m x100 w70 gSaveTimeButton, Save
  Gui, Add, Text, x+m yp, Current:
  Gui, Add, Text, x+m yp w100 vIdleSecondsText, 0
  
  //separator
  Gui, Add, Text, xm y+15 w250 h1 0x7
  
  //manual description and buttons
  Gui, Add, Text, xm, Manually mine now:
  Gui, Add, Button, w70 gManualStartButton vManualStartButton, Start
  Gui, Add, Button, x+m w70 gManualStopButton vManualStopButton Disabled, Stop
  
  //separator
  Gui, Add, Text, xm y+m w250 h1 0x7
  
  //wallet description and drop down
  Gui, Add, Text, xm, Wallet Selection:
  Gui, Add, DropDownList, w100 vWalletList gWalletListEvent Choose%ActiveWalletNumber%, Developer|Crypto Club|Libra Gaming|Custom
  
  //custom wallet description and edit
  Gui, Add, Text, xm, Custom Wallet (No leading 0x):
  Gui, Add, Edit, w240 vCustomWalletEdit, %CustomWallet%

  //worker
  Gui, Add, Text, xm, Worker (Name):
  Gui, Add, Edit, w80 vWorkerEdit, %Worker%
  
  //save wallet
  Gui, Add, Button, x+m x100 w70 gSaveWalletButton, Save
  
  //separator
  Gui, Add, Text, xm y+m w250 h1 0x7
  
  //GPU
  Gui, Add, Text, xm, GPU:
  Gui, Add, DropDownList, w100 vGPUList gGPUListEvent Choose%GPUType%, Nvidia (CUDA)|AMD (OpenCL)
  
  //show the gui
  Gui, Show, w270 h370
  
  //start the main timer
  SetTimer, MainTimer, 1000
Return


//GUI EVENTS
//file menu actions
HelpAbout:
  MsgBox, IdleEth Alpha
Return
FileExit:
  ExitApp
Return

//X
IdleEthMainGuiClose:
  ExitApp
Return

//enable disable radio buttons
EnabledRadioEvent:
  //update control variables from GUI
  GuiControlGet, EnabledRadio
  //update variables notify user
  If (EnabledRadio=1) {
    AutoMine=1
    GuiControl, , StatusText, Enabled!
  } Else {
    AutoMine=0
    GuiControl, , StatusText, Disabled!
  }
Return

//save button for time
SaveTimeButton:
  GuiControlGet, WaitSecondsEdit
  IdleTimeSeconds=%WaitSecondsEdit%
  //save the settings
  GoSub, Persist
Return

//manual start/stop buttons
ManualStartButton:
  //set manual flag for the main loop to catch
  ManualMine=1
  //toggle stop enabled, start disabled
  GuiControl, Enable, ManualStopButton
  GuiControl, Disable, ManualStartButton
Return
ManualStopButton:
  //set manual flag for the main loop to catch
  ManualMine=2
  //toggle stop disabled, start enabled
  GuiControl, Disable, ManualStopButton
  GuiControl, Enable, ManualStartButton
Return

WalletListEvent:
  //update control variable from GUI
  GuiControlGet, WalletList
  //warn if manual mining
  If (ManualMine = 1) {
    MsgBox, Restart manual mining to apply changes.
  }
  //set wallet variables
  If (WalletList="Developer") {
    ActiveWalletNumber=1
  } Else If (WalletList="Crypto Club") {
    ActiveWalletNumber=2
  } Else If (WalletList="Libra Gaming") {
    ActiveWalletNumber=3
  } Else {
    ActiveWalletNumber=4
  }
  //save the setting
  GoSub, Persist
Return

SaveWalletButton:
  //update control variable from GUI
  GuiControlGet, CustomWalletEdit
  GuiControlGet, WorkerEdit
  //warn if manual mining
  If (ManualMine = 1) {
    MsgBox, Restart manual mining to apply changes.
  }
  CustomWallet=%CustomWalletEdit%
  Worker=%WorkerEdit%
  //save the settings
  GoSub, Persist
Return

GPUListEvent:
  //update control variable from GUI
  GuiControlGet, GPUList
  If (GPUList="Nvidia (CUDA)") {
    GPUType=1
  } Else {
    GPUType=2
  }
  //save the setting
  GoSub, Persist
Return

//persist
Persist:
  FileDelete, %A_WorkingDir%\IdleEthFiles\config.dat
  FileAppend,
(
IdleTimeSeconds	%IdleTimeSeconds%
CustomWallet	%CustomWallet%
ActiveWalletNumber	%ActiveWalletNumber%
Worker	%Worker%
GPUType	%GPUType%
), %A_WorkingDir%\IdleEthFiles\config.dat
Return


//MAIN LOOP
MainTimer:
  //auto mining mode, not manual
  If (AutoMine = 1) and (ManualMine = 0) {
    IdleSeconds := % Floor(A_TimeIdle/1000)
    GuiControl, IdleEthMain:, IdleSecondsText, %IdleSeconds%
    //if not mining, check if it is time to start
    If (MinerPID = 0) {
      If (IdleSeconds > IdleTimeSeconds) {
        TrayTip IdleEth, Auto Mining Started!, 1, 17
        GoSub, Mine
      }
    } Else { //already mining, check if it is time to stop
      //increment mine time
      MineTimeSeconds += 1
      If (IdleSeconds < IdleTimeSeconds) {
        TrayTip IdleEth, Auto Mining Stopped after %MineTimeSeconds% seconds!, 1, 17
        GoSub, Stop
      } Else { //not time to stop, check if miner died
        Process, Exist, %MinerPID%
        CheckPID = %ErrorLevel%
        If (CheckPID = 0) {
          //miner died
          MsgBox, Miner Died!
          MinerPID = 0
        }
      }
    }
  }
  //manual mining mode
  If (ManualMine = 1) {
    //if not mining, start mining
    If (MinerPID = 0) {
      GoSub, Mine
    } Else { //if mining, check for process died
      Process, Exist, %MinerPID%
      CheckPID = %ErrorLevel%
      If (CheckPID = 0) {
        //miner died
        MsgBox, Miner Died!
        ManualMine = 0
        MinerPID = 0
        //toggle stop disabled, start enabled
        GuiControl, IdleEthMain:Disable, ManualStopButton
        GuiControl, IdleEthMain:Enable, ManualStartButton
      }
    }
  } 
  //stop manual mining
  If (ManualMine = 2) {
    GoSub, Stop
    ManualMine = 0
  }
Return


//MINE
Mine:
  //build the miner string
  MinerString = %A_WorkingDir%\IdleEthFiles\ethminer-0.13.0.exe
  //set the gpu mode
  If (GPUType=1) {
    MinerString = %MinerString% --cuda
  } Else {
    MinerString = %MinerString% --opencl
  }
  //pool details
  MinerString = %MinerString% --report-hashrate
  MinerString = %MinerString% --farm-recheck 200
  MinerString = %MinerString% --stratum us1.ethermine.org:4444
  MinerString = %MinerString% --stratum-failover us2.ethermine.org:4444
  //wallet and worker
  If (ActiveWalletNumber = 1) {
    ActiveWalletAddress = %DevWallet%
  } Else If (ActiveWalletNumber = 2) {
    ActiveWalletAddress = %ClubWallet%
  } Else If (ActiveWalletNumber = 3) {
    ActiveWalletAddress = %LibraWallet%
  } Else {
    ActiveWalletAddress = %CustomWallet%
  }
  MinerString = %MinerString% --userpass %ActiveWalletAddress%.%Worker%
  //debugging
  //MsgBox, %MinerString%
  //run the miner with the prepared string, save the PID
  Run %MinerString%, , , MinerPID
Return


//STOP
Stop:
  Process, Close, %MinerPID%
  MinerPID=0
Return