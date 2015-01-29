using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Threading;
using Elysium.Notifications;
using RCS.DTV.RZC.Helpers;
using RCS.DTV.RZC.Models;
using RCS.DTV.RZC.Properties;
using RCS.NFLN.SCHEDULE;
using SimpleMvvmToolkit;

namespace RCS.DTV.RZC
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class MainPageViewModel : ViewModelBase<MainPageViewModel>
    {
        #region Private Fields
        private Boolean _checked;
        private Boolean _Ichecked;
        private string _connectStr;
        private string _IconnectStr;
        private readonly DispatcherTimer _restartEventTimer = new DispatcherTimer();
        private iPad iPad { get; set; }
        #endregion

        // Default ctor
        public MainPageViewModel()
        {
            CurrentSession.VizEngine.EngineStatus += UpdateToggle;
            FantasyChecked = false;
            MapChecked = false;
            SponsorChecked = false;
            LiveChecked = false;
            ReplayChecked = false;
            PlayoffChecked = false;
            SocialChecked = false;
            _Ichecked = false;
            BothConnected = false;
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        #region Properties

        private Boolean _isVizConnected;

        public Boolean IsVizConnected
        {
            get { return _isVizConnected; }
            set
            {
                if (_isVizConnected == value)
                    return;
                _isVizConnected = value;
                NotifyPropertyChanged(m => m.IsVizConnected);
            }
        }

        private Boolean _isIPadConnected;

        public Boolean IsIPadConnected
        {
            get { return _isIPadConnected; }
            set
            {
                if (_isIPadConnected == value)
                    return;
                _isIPadConnected = value;
                NotifyPropertyChanged(m => m.IsIPadConnected);
            }
        }

        private Boolean _bothConnected;

        public Boolean BothConnected
        {
            get { return _bothConnected; }
            set
            {
                if (_bothConnected == value)
                    return;
                _bothConnected = value;
                NotifyPropertyChanged(m => m.BothConnected);
            }
        }


        private Boolean _isConsoleOn;

        public Boolean IsConsoleOn
        {
            get { return _isConsoleOn; }
            set
            {
                if (_isConsoleOn == value)
                    return;
                _isConsoleOn = value;
                NotifyPropertyChanged(m => m.IsConsoleOn);
            }
        }

        #region Menu Properties

        private Boolean _fantasyChecked;

        public Boolean FantasyChecked
        {
            get { return _fantasyChecked; }
            set
            {
                if (_fantasyChecked == value)
                    return;
                _fantasyChecked = value;
                NotifyPropertyChanged(m => m.FantasyChecked);
            }
        }

        private Boolean _mapChecked;

        public Boolean MapChecked
        {
            get { return _mapChecked; }
            set
            {
                if (_mapChecked == value)
                    return;
                _mapChecked = value;
                NotifyPropertyChanged(m => m.MapChecked);
            }
        }

        private Boolean _sponsorChecked;

        public Boolean SponsorChecked
        {
            get { return _sponsorChecked; }
            set
            {
                if (_sponsorChecked == value)
                    return;
                _sponsorChecked = value;
                NotifyPropertyChanged(m => m.SponsorChecked);
            }
        }

        private Boolean _liveChecked;

        public Boolean LiveChecked
        {
            get { return _liveChecked; }
            set
            {
                if (_liveChecked == value)
                    return;
                _liveChecked = value;
                NotifyPropertyChanged(m => m.LiveChecked);
            }
        }

        private Boolean _replayChecked;

        public Boolean ReplayChecked
        {
            get { return _replayChecked; }
            set
            {
                if (_replayChecked == value)
                    return;
                _replayChecked = value;
                NotifyPropertyChanged(m => m.ReplayChecked);
            }
        }

        private Boolean _playoffChecked;

        public Boolean PlayoffChecked
        {
            get { return _playoffChecked; }
            set
            {
                if (_playoffChecked == value)
                    return;
                _playoffChecked = value;
                NotifyPropertyChanged(m => m.PlayoffChecked);
            }
        }

        private Boolean _socialChecked;

        public Boolean SocialChecked
        {
            get { return _socialChecked; }
            set
            {
                if (_socialChecked == value)
                    return;
                _socialChecked = value;
                NotifyPropertyChanged(m => m.SocialChecked);
            }
        }

        #endregion

        #endregion

        // Methods that will be called by the view
        #region Public Functions

        public void ConnectRouter()
        {
            CurrentSession.VizEngine.Invoke("SetIP \"" + NetHelper.GetLocalIP() + "\"");
        }

        public void ConnectViz()
        {
            if (!_checked)
            {
                CurrentSession.VizEngine.IP = CurrentSession.Config.EngineIp;
                CurrentSession.VizEngine.Port = CurrentSession.Config.EnginePort;
                CurrentSession.VizEngine.ConnectToEngine();
                Thread t = new Thread(o => SetEndPoint());
                t.Start();
            }
        }

        public void DisconnectViz()
        {
            if (_checked && _connectStr.Equals("Connected"))
            {
                CurrentSession.VizEngine.DisconnectFromEngine();
                _checked = false;
            }
        }

        public void ConnectIPad()
        {
            iPad = new iPad(Settings.Default.iPadIP, Settings.Default.iPadPort);
            CurrentSession.IPad = iPad;
            if (!_Ichecked)
            {
                CurrentSession.IPad.ConnectToiPad();
                Thread.Sleep(1000);
                if (CurrentSession.IPad.IsConnected)
                {
                    CurrentSession.VizEngine.Invoke("SetIP \"" + NetHelper.GetLocalIP() + "\"");
                    _Ichecked = true;
                    _IconnectStr = "Connected";
                    IsIPadConnected = true;
                    CurrentSession.VizEngine.Invoke("SetIPAD \"" + Settings.Default.iPadIP + "\"");

                    if (IsVizConnected && IsIPadConnected)
                        BothConnected = true;
                }
                else
                    IsIPadConnected = false;
            }
            //else
            //{
            //    _restartEventTimer.Start();
            //    _restartEventTimer.Interval = TimeSpan.FromSeconds(1.5);
            //    _restartEventTimer.Tick += delegate { _restartEventTimer.Stop(); IsIPadConnected = false; };
            //    //IsIPadConnected = false;
            //}
        }

        public void DisconnectIPad()
        {
            if (_Ichecked && _IconnectStr.Equals("Connected"))
            {
                CurrentSession.IPad.DisconnectFromiPad();
                IsIPadConnected = false;
                _Ichecked = false;
                _IconnectStr = "";
            }
        }

        public void TurnOnConsole()
        {
            IsConsoleOn = true;
            ConsoleManager.Show();
        }

        public void TurnOffConsole()
        {
            IsConsoleOn = false;
            ConsoleManager.Hide();
        }

        public void SetMainMenu()
        {
            string vizCom = String.Format(@"SetMainMenu ""{0},{1},{2},{3},{4},{5},{6}""",
                                          Convert.ToInt16(FantasyChecked),
                                          Convert.ToInt16(MapChecked),
                                          Convert.ToInt16(SponsorChecked),
                                          Convert.ToInt16(LiveChecked),
                                          Convert.ToInt16(ReplayChecked),
                                          Convert.ToInt16(PlayoffChecked),
                                          Convert.ToInt16(SocialChecked));
           string temp = String.Format("{0},{1},{2},{3},{4},{5},{6}",
                                          Convert.ToInt16(FantasyChecked),
                                          Convert.ToInt16(MapChecked),
                                          Convert.ToInt16(SponsorChecked),
                                          Convert.ToInt16(LiveChecked),
                                          Convert.ToInt16(ReplayChecked),
                                          Convert.ToInt16(PlayoffChecked),
                                          Convert.ToInt16(SocialChecked));

           string iPadCom = String.Format("2 {0}{1}", temp, "\r\n");

            CurrentSession.VizEngine.Invoke(vizCom);
            CurrentSession.IPad.Invoke(iPadCom);

        }

        public void LoadScene()
        {
            if (!CurrentSession.Config.ScenePath.Equals(""))
            {
                if (!CurrentSession.VizEngine.Connected)
                    ConnectViz();

                try
                {
                    if (CurrentSession.VizEngine != null && CurrentSession.VizEngine.Connected)
                    {
                        string strScenePath;
                        if (CurrentSession.VizEngine.Connected)
                        {
                            strScenePath = CurrentSession.Config.ScenePath;

                            //if (!IsSceneInMainLayer(strScenePath) )
                            //{
                            //clear renderer
                            CurrentSession.VizEngine.SendToEngine("-1 RENDERER*FRONT_LAYER SET_OBJECT ");
                            CurrentSession.VizEngine.SendToEngine("-1 RENDERER*MAIN_LAYER SET_OBJECT ");
                            CurrentSession.VizEngine.SendToEngine("-1 RENDERER*BACK_LAYER SET_OBJECT ");
                            CurrentSession.VizEngine.SendToEngine("-1 SCENE CLEANUP ");
                            Thread.Sleep(500);

                            //set scene on middle layer
                            CurrentSession.VizEngine.SendToEngine("-1 RENDERER SET_OBJECT SCENE*" + strScenePath);

                            //display on console
                            Console.WriteLine("LOAD SCENE");
                            Console.WriteLine("SENT TO ENGINE: 1 RENDERER SET_OBJECT SCENE*" + strScenePath);
                            //}
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
            else
            {
                //NotificationManager.Push("Viz Scene", "Viz scene path has not been set");
            }
        }
        #endregion

        #region Private Functions

        private void SetEndPoint()
        {
            bool done = true;
            while (done)
            {
                if (CurrentSession.VizEngine.Connected)
                {
                    CurrentSession.VizEngine.Invoke("SetIP \"" + NetHelper.GetLocalIP() + "\"");
                    done = false;
                    _checked = true;
                    Console.WriteLine(" \n*** VIZPGM CONNECTED *** \n");
                    _connectStr = "Connected";
                    CurrentSession.VizEngine.Invoke("SetIPAD \"" + Settings.Default.iPadIP + "\"");
                }
            }
        }

        private void UpdateToggle(string status)
        {
            IsVizConnected = status.Equals("Connected");

            if (IsVizConnected && IsIPadConnected)
                BothConnected = true;
        }

        // TODO: Optionally add callback methods for async calls to the service agent

        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }

        #endregion
    }
}