using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls.Primitives;
using Elysium.Notifications;
using RCS.DTV.RZC.Helpers;
using RCS.DTV.RZC.Models;
using RCS.DTV.RZC.Services;
using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class FantasyViewModel : ViewModelBase<FantasyViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private IFantasyServiceAgent _serviceAgent;
        private Boolean isManual;
        // Default ctor
        public FantasyViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public FantasyViewModel(IFantasyServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;
            Loading = false;
            isManual = false;

            TopPassers = new ObservableCollection<TopPassers>(_serviceAgent.LoadPassers());
            TopRushers = new ObservableCollection<TopRushers>(_serviceAgent.LoadRushers());
            TopReceivers = new ObservableCollection<TopReceivers>(_serviceAgent.LoadReceivers());

            SwapActionShots();
            InitTimer();
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        #region Properties

        private Boolean _loading;

        public Boolean Loading
        {
            get { return _loading; }
            set
            {
                if (_loading == value)
                    return;
                _loading = value;
                NotifyPropertyChanged(m => m.Loading);
            }
        }

        private string _topPasserPicture;

        public string TopPasserPicture
        {
            get { return _topPasserPicture; }
            set
            {
                if (_topPasserPicture == value)
                    return;
                _topPasserPicture = value;
                NotifyPropertyChanged(m => m.TopPasserPicture);
            }
        }

        private string _topRusherPicture;

        public string TopRusherPicture
        {
            get { return _topRusherPicture; }
            set
            {
                if (_topRusherPicture == value)
                    return;
                _topRusherPicture = value;
                NotifyPropertyChanged(m => m.TopRusherPicture);
            }
        }

        private string _topReceiverPicture;

        public string TopReceiverPicture
        {
            get { return _topReceiverPicture; }
            set
            {
                if (_topReceiverPicture == value)
                    return;
                _topReceiverPicture = value;
                NotifyPropertyChanged(m => m.TopReceiverPicture);
            }
        }

        private ObservableCollection<TopPassers> _topPassers;

        public ObservableCollection<TopPassers> TopPassers
        {
            get { return _topPassers; }
            set
            {
                if (_topPassers == value)
                    return;
                _topPassers = value;
                NotifyPropertyChanged(m => m.TopPassers);
            }
        }

        private ObservableCollection<TopRushers> _topRushers;

        public ObservableCollection<TopRushers> TopRushers
        {
            get { return _topRushers; }
            set
            {
                if (_topRushers == value)
                    return;
                _topRushers = value;
                NotifyPropertyChanged(m => m.TopRushers);
            }
        }

        private ObservableCollection<TopReceivers> _topReceivers;

        public ObservableCollection<TopReceivers> TopReceivers
        {
            get { return _topReceivers; }
            set
            {
                if (_topReceivers == value)
                    return;
                _topReceivers = value;
                NotifyPropertyChanged(m => m.TopReceivers);
            }
        }


        #endregion

        #region Public Functions

        public void InitTimer()
        {
            Timer time = new Timer();
            time.Elapsed += ExecuteTimer;
            time.Interval = 30000; // in miliseconds
            time.Start();
        }

        private void ExecuteTimer(object sender, EventArgs e)
        {
            ReloadTopPlayers();
            SetTopPlayers();
        }

        public void ReloadTopPlayers()
        {
            TopPassers = new ObservableCollection<TopPassers>(_serviceAgent.LoadPassers());
            TopRushers = new ObservableCollection<TopRushers>(_serviceAgent.LoadRushers());
            TopReceivers = new ObservableCollection<TopReceivers>(_serviceAgent.LoadReceivers());

            SwapActionShots();
        }

        public void LoadPasserPic()
        {
            var pic = _serviceAgent.LoadPicture();
            if (pic != null)
            {
                TopPasserPicture = pic;
                TopPassers[0].Picture = pic;
            }
        }

        public void LoadRusherPic()
        {
            var pic = _serviceAgent.LoadPicture();
            if (pic != null)
            {
                TopRusherPicture = pic;
                TopRushers[0].Picture = pic;
            }
        }

        public void LoadReceiverPic()
        {
            var pic = _serviceAgent.LoadPicture();
            if (pic != null)
            {
                TopReceiverPicture = pic;
                TopReceivers[0].Picture = pic;
            }
        }

        public void ManualPictures()
        {
            isManual = true;
        }

        public void DefaultPictures()
        {
            string str;
            isManual = false;
            str = String.Format("{0}|{1}|{2}", "", "", "");
            CurrentSession.VizEngine.Invoke("SetDefaultPictures \"" + str + "\"");
        }

        public void SetDefaultPictures()
        {
            try
            {
                string defaultPics;

                if (TopPasserPicture != null && TopRusherPicture != null && TopRusherPicture != null)
                {
                    defaultPics = String.Format("{0}|{1}|{2}", TopPasserPicture, TopRusherPicture, TopReceiverPicture);
                    CurrentSession.VizEngine.Invoke("SetDefaultPictures \"" + defaultPics.Replace(@"\", "/") + "\"");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void SetTopPlayers()
        {
            _serviceAgent.SetTopPlayers(TopPasserPicture, TopRusherPicture, TopReceiverPicture, TopPassers, TopRushers, TopReceivers);
        }

        #endregion

        #region Private Functions

        private void SwapActionShots()
        {
            StringBuilder str;
            string temp;
            try
            {
                if (TopPassers[0].Picture.Contains("Headshots") || TopRushers[0].Picture.Contains("Headshots") ||
                    TopReceivers[0].Picture.Contains("Headshots"))
                {
                    if (TopPassers[0].Picture.Contains("ActionShots"))
                    {
                        temp = TopPassers[0].Picture.Replace(@"ActionShots\",
                                                             String.Format(@"Headshots\{0}\", TopPassers[0].Tricode));
                        str = new StringBuilder(temp);
                        str = str.Insert(temp.IndexOf("."), "_B");
                    
                        if (!isManual)
                            TopPasserPicture = str.ToString();
                    }

                    if (TopRushers[0].Picture.Contains("ActionShots"))
                    {
                        temp = TopRushers[0].Picture.Replace(@"ActionShots\",
                                                             String.Format(@"Headshots\{0}\", TopRushers[0].Tricode));
                        str = new StringBuilder(temp);
                        str = str.Insert(temp.IndexOf("."), "_B");

                        if (!isManual)
                            TopRusherPicture = str.ToString();
                    }

                    if (TopReceivers[0].Picture.Contains("ActionShots"))
                    {
                        temp = TopReceivers[0].Picture.Replace(@"ActionShots\",
                                                               String.Format(@"Headshots\{0}\", TopReceivers[0].Tricode));
                        str = new StringBuilder(temp);
                        str = str.Insert(temp.IndexOf("."), "_B");

                        if (!isManual)
                            TopReceiverPicture = str.ToString();
                    }
                }
                else
                {
                    if (!isManual)
                    {
                        TopPasserPicture = TopPassers[0].Picture;
                        TopRusherPicture = TopRushers[0].Picture;
                        TopReceiverPicture = TopReceivers[0].Picture;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // TODO: Optionally add callback methods for async calls to the service agent
        private void HandleFeedback(object sender, TcpMessageReceivedEventArgs args)
        {
            ReloadTopPlayers();
            SetTopPlayers();
        }

        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }

        #endregion

    }
}