using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;
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
    public class MapViewModel : ViewModelBase<MapViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private IMapServiceAgent _serviceAgent;
        private Dictionary<string, string> _descDict;
        private int index;

        // Default ctor
        public MapViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public MapViewModel(IMapServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;
            IsWeekSet = false;
            IsLiveGame = false;
            SetOneInput();
            SelectedVideoInput = new ObservableCollection<string>();
            SortIndex = new ObservableCollection<int>();
            index = 1;

            for (int i = 0; i <= 15; i++)
                SelectedVideoInput.Add(null);

            _descDict = new Dictionary<string, string>
                {
                    {"1", "SUNNY"},
                    {"2", "SUN CLOUDY"},
                    {"3", "MOSTLY CLOUDY"},
                    {"4", "MORE CLOUDY"},
                    {"5", "RAIN"},
                    {"6", "RAIN LIGHTNING"},
                    {"7", "LIGHTNING"},
                    {"8", "SNOW"},
                    {"9", "SNOW CLOUDY"},
                    {"10", "NIGHT CLEAR"},
                    {"11", "NIGHT CLOUDY"},
                    {"12", "WINDY"}
                    //{"13", "LIGHT SNOW"},
                    //{"14", "HEAVY SNOW"},
                    //{"15", "FOGGY"},
                    //{"16", "NIGHT CLEAR"},
                    //{"17", "NIGHT CLOUDY"},
                    //{"18", "LIGHTNING"},
                    //{"19", "NIGHT SNOW"},
                    //{"20", "SUN SNOW"}
                };

            ResetIndex();

            LoadFromXML();
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // properties used by the view
        #region Properties

        private ObservableCollection<CoreTeams> _selectedAwayTeams;

        public ObservableCollection<CoreTeams> SelectedAwayTeams
        {
            get { return _selectedAwayTeams; }
            set
            {
                if (_selectedAwayTeams == value)
                    return;
                _selectedAwayTeams = value;
                NotifyPropertyChanged(m => m.SelectedAwayTeams);
            }
        }

        private ObservableCollection<CoreTeams> _selectedHomeTeams;

        public ObservableCollection<CoreTeams> SelectedHomeTeams
        {
            get { return _selectedHomeTeams; }
            set
            {
                if (_selectedHomeTeams == value)
                    return;
                _selectedHomeTeams = value;
                NotifyPropertyChanged(m => m.SelectedHomeTeams);
            }
        }

        private ObservableCollection<Boolean> _isTeamChecked;

        public ObservableCollection<Boolean> IsTeamChecked
        {
            get { return _isTeamChecked; }
            set
            {
                if (_isTeamChecked == value)
                    return;
                _isTeamChecked = value;
                NotifyPropertyChanged(m => m.IsTeamChecked);
            }
        }

        private Boolean _isWeekSet;

        public Boolean IsWeekSet
        {
            get { return _isWeekSet; }
            set
            {
                if (_isWeekSet == value)
                    return;
                _isWeekSet = value;
                NotifyPropertyChanged(m => m.IsWeekSet);
            }
        }

        private Boolean _isLiveGame;

        public Boolean IsLiveGame
        {
            get { return _isLiveGame; }
            set
            {
                if (_isLiveGame == value)
                    return;
                _isLiveGame = value;
                NotifyPropertyChanged(m => m.IsLiveGame);
            }
        }

        private string _weekNumber;

        public string WeekNumber
        {
            get { return _weekNumber; }
            set
            {
                if (_weekNumber == value)
                    return;
                _weekNumber = value;
                NotifyPropertyChanged(m => m.WeekNumber);
            }
        }

        #region Booleans

        private Boolean _teamChecked1;

        public Boolean TeamChecked1
        {
            get { return _teamChecked1; }
            set
            {
                if (_teamChecked1 == value)
                    return;
                _teamChecked1 = value;
                NotifyPropertyChanged(m => m.TeamChecked1);
            }
        }

        private Boolean _teamChecked2;

        public Boolean TeamChecked2
        {
            get { return _teamChecked2; }
            set
            {
                if (_teamChecked2 == value)
                    return;
                _teamChecked2 = value;
                NotifyPropertyChanged(m => m.TeamChecked2);
            }
        }

        private Boolean _teamChecked3;

        public Boolean TeamChecked3
        {
            get { return _teamChecked3; }
            set
            {
                if (_teamChecked3 == value)
                    return;
                _teamChecked3 = value;
                NotifyPropertyChanged(m => m.TeamChecked3);
            }
        }

        private Boolean _teamChecked4;

        public Boolean TeamChecked4
        {
            get { return _teamChecked4; }
            set
            {
                if (_teamChecked4 == value)
                    return;
                _teamChecked4 = value;
                NotifyPropertyChanged(m => m.TeamChecked4);
            }
        }

        private Boolean _teamChecked5;

        public Boolean TeamChecked5
        {
            get { return _teamChecked5; }
            set
            {
                if (_teamChecked5 == value)
                    return;
                _teamChecked5 = value;
                NotifyPropertyChanged(m => m.TeamChecked5);
            }
        }

        private Boolean _teamChecked6;

        public Boolean TeamChecked6
        {
            get { return _teamChecked6; }
            set
            {
                if (_teamChecked6 == value)
                    return;
                _teamChecked6 = value;
                NotifyPropertyChanged(m => m.TeamChecked6);
            }
        }

        private Boolean _teamChecked7;

        public Boolean TeamChecked7
        {
            get { return _teamChecked7; }
            set
            {
                if (_teamChecked7 == value)
                    return;
                _teamChecked7 = value;
                NotifyPropertyChanged(m => m.TeamChecked7);
            }
        }

        private Boolean _teamChecked8;

        public Boolean TeamChecked8
        {
            get { return _teamChecked8; }
            set
            {
                if (_teamChecked8 == value)
                    return;
                _teamChecked8 = value;
                NotifyPropertyChanged(m => m.TeamChecked8);
            }
        }

        private Boolean _teamChecked9;

        public Boolean TeamChecked9
        {
            get { return _teamChecked9; }
            set
            {
                if (_teamChecked9 == value)
                    return;
                _teamChecked9 = value;
                NotifyPropertyChanged(m => m.TeamChecked9);
            }
        }

        private Boolean _teamChecked10;

        public Boolean TeamChecked10
        {
            get { return _teamChecked10; }
            set
            {
                if (_teamChecked10 == value)
                    return;
                _teamChecked10 = value;
                NotifyPropertyChanged(m => m.TeamChecked10);
            }
        }

        private Boolean _teamChecked11;

        public Boolean TeamChecked11
        {
            get { return _teamChecked11; }
            set
            {
                if (_teamChecked11 == value)
                    return;
                _teamChecked11 = value;
                NotifyPropertyChanged(m => m.TeamChecked11);
            }
        }

        private Boolean _teamChecked12;

        public Boolean TeamChecked12
        {
            get { return _teamChecked12; }
            set
            {
                if (_teamChecked12 == value)
                    return;
                _teamChecked12 = value;
                NotifyPropertyChanged(m => m.TeamChecked12);
            }
        }

        private Boolean _teamChecked13;

        public Boolean TeamChecked13
        {
            get { return _teamChecked13; }
            set
            {
                if (_teamChecked13 == value)
                    return;
                _teamChecked13 = value;
                NotifyPropertyChanged(m => m.TeamChecked13);
            }
        }

        private Boolean _teamChecked14;

        public Boolean TeamChecked14
        {
            get { return _teamChecked14; }
            set
            {
                if (_teamChecked14 == value)
                    return;
                _teamChecked14 = value;
                NotifyPropertyChanged(m => m.TeamChecked14);
            }
        }

        private Boolean _teamChecked15;

        public Boolean TeamChecked15
        {
            get { return _teamChecked15; }
            set
            {
                if (_teamChecked15 == value)
                    return;
                _teamChecked15 = value;
                NotifyPropertyChanged(m => m.TeamChecked15);
            }
        }

        private Boolean _teamChecked16;

        public Boolean TeamChecked16
        {
            get { return _teamChecked16; }
            set
            {
                if (_teamChecked16 == value)
                    return;
                _teamChecked16 = value;
                NotifyPropertyChanged(m => m.TeamChecked16);
            }
        }

        #endregion

        #region Weather Logos
        private Image _logo1;

        public Image Logo1
        {
            get { return _logo1; }
            set
            {
                if (_logo1 == value)
                    return;
                _logo1 = value;
                NotifyPropertyChanged(m => m.Logo1);
                Desc1 = GetAutoDesc(Logo1);
            }
        }

        private Image _logo2;

        public Image Logo2
        {
            get { return _logo2; }
            set
            {
                if (_logo2 == value)
                    return;
                _logo2 = value;
                NotifyPropertyChanged(m => m.Logo2);
                Desc2 = GetAutoDesc(Logo2);
            }
        }

        private Image _logo3;

        public Image Logo3
        {
            get { return _logo3; }
            set
            {
                if (_logo3 == value)
                    return;
                _logo3 = value;
                NotifyPropertyChanged(m => m.Logo3);
                Desc3 = GetAutoDesc(Logo3);
            }
        }

        private Image _logo4;

        public Image Logo4
        {
            get { return _logo4; }
            set
            {
                if (_logo4 == value)
                    return;
                _logo4 = value;
                NotifyPropertyChanged(m => m.Logo4);
                Desc4 = GetAutoDesc(Logo4);
            }
        }

        private Image _logo5;

        public Image Logo5
        {
            get { return _logo5; }
            set
            {
                if (_logo5 == value)
                    return;
                _logo5 = value;
                NotifyPropertyChanged(m => m.Logo5);
                Desc5 = GetAutoDesc(Logo5);
            }
        }

        private Image _logo6;

        public Image Logo6
        {
            get { return _logo6; }
            set
            {
                if (_logo6 == value)
                    return;
                _logo6 = value;
                NotifyPropertyChanged(m => m.Logo6);
                Desc6 = GetAutoDesc(Logo6);
            }
        }

        private Image _logo7;

        public Image Logo7
        {
            get { return _logo7; }
            set
            {
                if (_logo7 == value)
                    return;
                _logo7 = value;
                NotifyPropertyChanged(m => m.Logo7);
                Desc7 = GetAutoDesc(Logo7);
            }
        }

        private Image _logo8;

        public Image Logo8
        {
            get { return _logo8; }
            set
            {
                if (_logo8 == value)
                    return;
                _logo8 = value;
                NotifyPropertyChanged(m => m.Logo8);
                Desc8 = GetAutoDesc(Logo8);
            }
        }

        private Image _logo9;

        public Image Logo9
        {
            get { return _logo9; }
            set
            {
                if (_logo9 == value)
                    return;
                _logo9 = value;
                NotifyPropertyChanged(m => m.Logo9);
                Desc9 = GetAutoDesc(Logo9);
            }
        }

        private Image _logo10;

        public Image Logo10
        {
            get { return _logo10; }
            set
            {
                if (_logo10 == value)
                    return;
                _logo10 = value;
                NotifyPropertyChanged(m => m.Logo10);
                Desc10 = GetAutoDesc(Logo10);
            }
        }

        private Image _logo11;

        public Image Logo11
        {
            get { return _logo11; }
            set
            {
                if (_logo11 == value)
                    return;
                _logo11 = value;
                NotifyPropertyChanged(m => m.Logo11);
                Desc11 = GetAutoDesc(Logo11);
            }
        }

        private Image _logo12;

        public Image Logo12
        {
            get { return _logo12; }
            set
            {
                if (_logo12 == value)
                    return;
                _logo12 = value;
                NotifyPropertyChanged(m => m.Logo12);
                Desc12 = GetAutoDesc(Logo12);
            }
        }

        private Image _logo13;

        public Image Logo13
        {
            get { return _logo13; }
            set
            {
                if (_logo13 == value)
                    return;
                _logo13 = value;
                NotifyPropertyChanged(m => m.Logo13);
                Desc13 = GetAutoDesc(Logo13);
            }
        }

        private Image _logo14;

        public Image Logo14
        {
            get { return _logo14; }
            set
            {
                if (_logo14 == value)
                    return;
                _logo14 = value;
                NotifyPropertyChanged(m => m.Logo14);
                Desc14 = GetAutoDesc(Logo14);
            }
        }

        private Image _logo15;

        public Image Logo15
        {
            get { return _logo15; }
            set
            {
                if (_logo15 == value)
                    return;
                _logo15 = value;
                NotifyPropertyChanged(m => m.Logo15);
                Desc15 = GetAutoDesc(Logo15);
            }
        }

        private Image _logo16;

        public Image Logo16
        {
            get { return _logo16; }
            set
            {
                if (_logo16 == value)
                    return;
                _logo16 = value;
                NotifyPropertyChanged(m => m.Logo16);
                Desc16 = GetAutoDesc(Logo16);
            }
        }

        #endregion

        private ObservableCollection<Image> _logoCollection;

        public ObservableCollection<Image> LogoCollection
        {
            get { return _logoCollection; }
            set
            {
                if (_logoCollection == value)
                    return;
                _logoCollection = value;
                NotifyPropertyChanged(m => m.LogoCollection);
            }
        }

        private ObservableCollection<int> _weatherIds;

        public ObservableCollection<int> WeatherIds
        {
            get { return _weatherIds; }
            set
            {
                if (_weatherIds == value)
                    return;
                _weatherIds = value;
                NotifyPropertyChanged(m => m.WeatherIds);
            }
        }

        #region Weather Descriptions

        private string _desc1;

        public string Desc1
        {
            get { return _desc1; }
            set
            {
                if (_desc1 == value)
                    return;
                _desc1 = value;
                NotifyPropertyChanged(m => m.Desc1);
            }
        }

        private string _desc2;

        public string Desc2
        {
            get { return _desc2; }
            set
            {
                if (_desc2 == value)
                    return;
                _desc2 = value;
                NotifyPropertyChanged(m => m.Desc2);
            }
        }

        private string _desc3;

        public string Desc3
        {
            get { return _desc3; }
            set
            {
                if (_desc3 == value)
                    return;
                _desc3 = value;
                NotifyPropertyChanged(m => m.Desc3);
            }
        }

        private string _desc4;

        public string Desc4
        {
            get { return _desc4; }
            set
            {
                if (_desc4 == value)
                    return;
                _desc4 = value;
                NotifyPropertyChanged(m => m.Desc4);
            }
        }

        private string _desc5;

        public string Desc5
        {
            get { return _desc5; }
            set
            {
                if (_desc5 == value)
                    return;
                _desc5 = value;
                NotifyPropertyChanged(m => m.Desc5);
            }
        }

        private string _desc6;

        public string Desc6
        {
            get { return _desc6; }
            set
            {
                if (_desc6 == value)
                    return;
                _desc6 = value;
                NotifyPropertyChanged(m => m.Desc6);
            }
        }

        private string _desc7;

        public string Desc7
        {
            get { return _desc7; }
            set
            {
                if (_desc7 == value)
                    return;
                _desc7 = value;
                NotifyPropertyChanged(m => m.Desc7);
            }
        }

        private string _desc8;

        public string Desc8
        {
            get { return _desc8; }
            set
            {
                if (_desc8 == value)
                    return;
                _desc8 = value;
                NotifyPropertyChanged(m => m.Desc8);
            }
        }

        private string _desc9;

        public string Desc9
        {
            get { return _desc9; }
            set
            {
                if (_desc9 == value)
                    return;
                _desc9 = value;
                NotifyPropertyChanged(m => m.Desc9);
            }
        }

        private string _desc10;

        public string Desc10
        {
            get { return _desc10; }
            set
            {
                if (_desc10 == value)
                    return;
                _desc10 = value;
                NotifyPropertyChanged(m => m.Desc10);
            }
        }

        private string _desc11;

        public string Desc11
        {
            get { return _desc11; }
            set
            {
                if (_desc11 == value)
                    return;
                _desc11 = value;
                NotifyPropertyChanged(m => m.Desc11);
            }
        }

        private string _desc12;

        public string Desc12
        {
            get { return _desc12; }
            set
            {
                if (_desc12 == value)
                    return;
                _desc12 = value;
                NotifyPropertyChanged(m => m.Desc12);
            }
        }

        private string _desc13;

        public string Desc13
        {
            get { return _desc13; }
            set
            {
                if (_desc13 == value)
                    return;
                _desc13 = value;
                NotifyPropertyChanged(m => m.Desc13);
            }
        }

        private string _desc14;

        public string Desc14
        {
            get { return _desc14; }
            set
            {
                if (_desc14 == value)
                    return;
                _desc14 = value;
                NotifyPropertyChanged(m => m.Desc14);
            }
        }

        private string _desc15;

        public string Desc15
        {
            get { return _desc15; }
            set
            {
                if (_desc15 == value)
                    return;
                _desc15 = value;
                NotifyPropertyChanged(m => m.Desc15);
            }
        }

        private string _desc16;

        public string Desc16
        {
            get { return _desc16; }
            set
            {
                if (_desc16 == value)
                    return;
                _desc16 = value;
                NotifyPropertyChanged(m => m.Desc16);
            }
        }

        #endregion

        private ObservableCollection<string> _descriptions;

        public ObservableCollection<string> Descriptions
        {
            get { return _descriptions; }
            set
            {
                if (_descriptions == value)
                    return;
                _descriptions = value;
                NotifyPropertyChanged(m => m.Descriptions);
            }
        }

        #region Weather Temperatures

        private string _temp1;

        public string Temp1
        {
            get { return _temp1; }
            set
            {
                if (_temp1 == value)
                    return;
                _temp1 = value;
                NotifyPropertyChanged(m => m.Temp1);
            }
        }

        private string _temp2;

        public string Temp2
        {
            get { return _temp2; }
            set
            {
                if (_temp2 == value)
                    return;
                _temp2 = value;
                NotifyPropertyChanged(m => m.Temp2);
            }
        }

        private string _temp3;

        public string Temp3
        {
            get { return _temp3; }
            set
            {
                if (_temp3 == value)
                    return;
                _temp3 = value;
                NotifyPropertyChanged(m => m.Temp3);
            }
        }

        private string _temp4;

        public string Temp4
        {
            get { return _temp4; }
            set
            {
                if (_temp4 == value)
                    return;
                _temp4 = value;
                NotifyPropertyChanged(m => m.Temp4);
            }
        }

        private string _temp5;

        public string Temp5
        {
            get { return _temp5; }
            set
            {
                if (_temp5 == value)
                    return;
                _temp5 = value;
                NotifyPropertyChanged(m => m.Temp5);
            }
        }

        private string _temp6;

        public string Temp6
        {
            get { return _temp6; }
            set
            {
                if (_temp6 == value)
                    return;
                _temp6 = value;
                NotifyPropertyChanged(m => m.Temp6);
            }
        }

        private string _temp7;

        public string Temp7
        {
            get { return _temp7; }
            set
            {
                if (_temp7 == value)
                    return;
                _temp7 = value;
                NotifyPropertyChanged(m => m.Temp7);
            }
        }

        private string _temp8;

        public string Temp8
        {
            get { return _temp8; }
            set
            {
                if (_temp8 == value)
                    return;
                _temp8 = value;
                NotifyPropertyChanged(m => m.Temp8);
            }
        }

        private string _temp9;

        public string Temp9
        {
            get { return _temp9; }
            set
            {
                if (_temp9 == value)
                    return;
                _temp9 = value;
                NotifyPropertyChanged(m => m.Temp9);
            }
        }

        private string _temp10;

        public string Temp10
        {
            get { return _temp10; }
            set
            {
                if (_temp10 == value)
                    return;
                _temp10 = value;
                NotifyPropertyChanged(m => m.Temp10);
            }
        }

        private string _temp11;

        public string Temp11
        {
            get { return _temp11; }
            set
            {
                if (_temp11 == value)
                    return;
                _temp11 = value;
                NotifyPropertyChanged(m => m.Temp11);
            }
        }

        private string _temp12;

        public string Temp12
        {
            get { return _temp12; }
            set
            {
                if (_temp12 == value)
                    return;
                _temp12 = value;
                NotifyPropertyChanged(m => m.Temp12);
            }
        }

        private string _temp13;

        public string Temp13
        {
            get { return _temp13; }
            set
            {
                if (_temp13 == value)
                    return;
                _temp13 = value;
                NotifyPropertyChanged(m => m.Temp13);
            }
        }

        private string _temp14;

        public string Temp14
        {
            get { return _temp14; }
            set
            {
                if (_temp14 == value)
                    return;
                _temp14 = value;
                NotifyPropertyChanged(m => m.Temp14);
            }
        }

        private string _temp15;

        public string Temp15
        {
            get { return _temp15; }
            set
            {
                if (_temp15 == value)
                    return;
                _temp15 = value;
                NotifyPropertyChanged(m => m.Temp15);
            }
        }

        private string _temp16;

        public string Temp16
        {
            get { return _temp16; }
            set
            {
                if (_temp16 == value)
                    return;
                _temp16 = value;
                NotifyPropertyChanged(m => m.Temp16);
            }
        }

        #endregion

        private ObservableCollection<string> _tempCollection;

        public ObservableCollection<string> TempCollection
        {
            get { return _tempCollection; }
            set
            {
                if (_tempCollection == value)
                    return;
                _tempCollection = value;
                NotifyPropertyChanged(m => m.TempCollection);
            }
        }

        private ObservableCollection<string> _videoInputs;

        public ObservableCollection<string> VideoInputs
        {
            get { return _videoInputs; }
            set
            {
                if (_videoInputs == value)
                    return;
                _videoInputs = value;
                NotifyPropertyChanged(m => m.VideoInputs);
            }
        }

        private ObservableCollection<string> _selectedVideoInput;

        public ObservableCollection<string> SelectedVideoInput
        {
            get { return _selectedVideoInput; }
            set
            {
                if (_selectedVideoInput == value)
                    return;
                _selectedVideoInput = value;
                NotifyPropertyChanged(m => m.SelectedVideoInput);
            }
        }

        private ObservableCollection<int> _sortIndex;

        public ObservableCollection<int> SortIndex
        {
            get { return _sortIndex; }
            set
            {
                if (_sortIndex == value)
                    return;
                _sortIndex = value;
                NotifyPropertyChanged(m => m.SortIndex);
            }
        }

        #region Button Content

        private string _btnContent1;

        public string BtnContent1
        {
            get { return _btnContent1; }
            set
            {
                if (_btnContent1 == value)
                    return;
                _btnContent1 = value;
                NotifyPropertyChanged(m => m.BtnContent1);
            }
        }

        private string _btnContent2;

        public string BtnContent2
        {
            get { return _btnContent2; }
            set
            {
                if (_btnContent2 == value)
                    return;
                _btnContent2 = value;
                NotifyPropertyChanged(m => m.BtnContent2);
            }
        }

        private string _btnContent3;

        public string BtnContent3
        {
            get { return _btnContent3; }
            set
            {
                if (_btnContent3 == value)
                    return;
                _btnContent3 = value;
                NotifyPropertyChanged(m => m.BtnContent3);
            }
        }

        private string _btnContent4;

        public string BtnContent4
        {
            get { return _btnContent4; }
            set
            {
                if (_btnContent4 == value)
                    return;
                _btnContent4 = value;
                NotifyPropertyChanged(m => m.BtnContent4);
            }
        }

        private string _btnContent5;

        public string BtnContent5
        {
            get { return _btnContent5; }
            set
            {
                if (_btnContent5 == value)
                    return;
                _btnContent5 = value;
                NotifyPropertyChanged(m => m.BtnContent5);
            }
        }

        private string _btnContent6;

        public string BtnContent6
        {
            get { return _btnContent6; }
            set
            {
                if (_btnContent6 == value)
                    return;
                _btnContent6 = value;
                NotifyPropertyChanged(m => m.BtnContent6);
            }
        }

        private string _btnContent7;

        public string BtnContent7
        {
            get { return _btnContent7; }
            set
            {
                if (_btnContent7 == value)
                    return;
                _btnContent7 = value;
                NotifyPropertyChanged(m => m.BtnContent7);
            }
        }

        private string _btnContent8;

        public string BtnContent8
        {
            get { return _btnContent8; }
            set
            {
                if (_btnContent8 == value)
                    return;
                _btnContent8 = value;
                NotifyPropertyChanged(m => m.BtnContent8);
            }
        }

        private string _btnContent9;

        public string BtnContent9
        {
            get { return _btnContent9; }
            set
            {
                if (_btnContent9 == value)
                    return;
                _btnContent9 = value;
                NotifyPropertyChanged(m => m.BtnContent9);
            }
        }

        private string _btnContent10;

        public string BtnContent10
        {
            get { return _btnContent10; }
            set
            {
                if (_btnContent10 == value)
                    return;
                _btnContent10 = value;
                NotifyPropertyChanged(m => m.BtnContent10);
            }
        }

        private string _btnContent11;

        public string BtnContent11
        {
            get { return _btnContent11; }
            set
            {
                if (_btnContent11 == value)
                    return;
                _btnContent11 = value;
                NotifyPropertyChanged(m => m.BtnContent11);
            }
        }

        private string _btnContent12;

        public string BtnContent12
        {
            get { return _btnContent12; }
            set
            {
                if (_btnContent12 == value)
                    return;
                _btnContent12 = value;
                NotifyPropertyChanged(m => m.BtnContent12);
            }
        }

        private string _btnContent13;

        public string BtnContent13
        {
            get { return _btnContent13; }
            set
            {
                if (_btnContent13 == value)
                    return;
                _btnContent13 = value;
                NotifyPropertyChanged(m => m.BtnContent13);
            }
        }

        private string _btnContent14;

        public string BtnContent14
        {
            get { return _btnContent14; }
            set
            {
                if (_btnContent14 == value)
                    return;
                _btnContent14 = value;
                NotifyPropertyChanged(m => m.BtnContent14);
            }
        }

        private string _btnContent15;

        public string BtnContent15
        {
            get { return _btnContent15; }
            set
            {
                if (_btnContent15 == value)
                    return;
                _btnContent15 = value;
                NotifyPropertyChanged(m => m.BtnContent15);
            }
        }

        private string _btnContent16;

        public string BtnContent16
        {
            get { return _btnContent16; }
            set
            {
                if (_btnContent16 == value)
                    return;
                _btnContent16 = value;
                NotifyPropertyChanged(m => m.BtnContent16);
            }
        }
        #endregion

        #region Button Visibility

        private Visibility _btnVis1;

        public Visibility BtnVis1
        {
            get { return _btnVis1; }
            set
            {
                if (_btnVis1 == value)
                    return;
                _btnVis1 = value;
                NotifyPropertyChanged(m => m.BtnVis1);
            }
        }

        private Visibility _btnVis2;

        public Visibility BtnVis2
        {
            get { return _btnVis2; }
            set
            {
                if (_btnVis2 == value)
                    return;
                _btnVis2 = value;
                NotifyPropertyChanged(m => m.BtnVis2);
            }
        }

        private Visibility _btnVis3;

        public Visibility BtnVis3
        {
            get { return _btnVis3; }
            set
            {
                if (_btnVis3 == value)
                    return;
                _btnVis3 = value;
                NotifyPropertyChanged(m => m.BtnVis3);
            }
        }

        private Visibility _btnVis4;

        public Visibility BtnVis4
        {
            get { return _btnVis4; }
            set
            {
                if (_btnVis4 == value)
                    return;
                _btnVis4 = value;
                NotifyPropertyChanged(m => m.BtnVis4);
            }
        }

        private Visibility _btnVis5;

        public Visibility BtnVis5
        {
            get { return _btnVis5; }
            set
            {
                if (_btnVis5 == value)
                    return;
                _btnVis5 = value;
                NotifyPropertyChanged(m => m.BtnVis5);
            }
        }

        private Visibility _btnVis6;

        public Visibility BtnVis6
        {
            get { return _btnVis6; }
            set
            {
                if (_btnVis6 == value)
                    return;
                _btnVis6 = value;
                NotifyPropertyChanged(m => m.BtnVis6);
            }
        }

        private Visibility _btnVis7;

        public Visibility BtnVis7
        {
            get { return _btnVis7; }
            set
            {
                if (_btnVis7 == value)
                    return;
                _btnVis7 = value;
                NotifyPropertyChanged(m => m.BtnVis7);
            }
        }

        private Visibility _btnVis8;

        public Visibility BtnVis8
        {
            get { return _btnVis8; }
            set
            {
                if (_btnVis8 == value)
                    return;
                _btnVis8 = value;
                NotifyPropertyChanged(m => m.BtnVis8);
            }
        }

        private Visibility _btnVis9;

        public Visibility BtnVis9
        {
            get { return _btnVis9; }
            set
            {
                if (_btnVis9 == value)
                    return;
                _btnVis9 = value;
                NotifyPropertyChanged(m => m.BtnVis9);
            }
        }

        private Visibility _btnVis10;

        public Visibility BtnVis10
        {
            get { return _btnVis10; }
            set
            {
                if (_btnVis10 == value)
                    return;
                _btnVis10 = value;
                NotifyPropertyChanged(m => m.BtnVis10);
            }
        }

        private Visibility _btnVis11;

        public Visibility BtnVis11
        {
            get { return _btnVis11; }
            set
            {
                if (_btnVis11 == value)
                    return;
                _btnVis11 = value;
                NotifyPropertyChanged(m => m.BtnVis11);
            }
        }

        private Visibility _btnVis12;

        public Visibility BtnVis12
        {
            get { return _btnVis12; }
            set
            {
                if (_btnVis12 == value)
                    return;
                _btnVis12 = value;
                NotifyPropertyChanged(m => m.BtnVis12);
            }
        }

        private Visibility _btnVis13;

        public Visibility BtnVis13
        {
            get { return _btnVis13; }
            set
            {
                if (_btnVis13 == value)
                    return;
                _btnVis13 = value;
                NotifyPropertyChanged(m => m.BtnVis13);
            }
        }

        private Visibility _btnVis14;

        public Visibility BtnVis14
        {
            get { return _btnVis14; }
            set
            {
                if (_btnVis14 == value)
                    return;
                _btnVis14 = value;
                NotifyPropertyChanged(m => m.BtnVis14);
            }
        }

        private Visibility _btnVis15;

        public Visibility BtnVis15
        {
            get { return _btnVis15; }
            set
            {
                if (_btnVis15 == value)
                    return;
                _btnVis15 = value;
                NotifyPropertyChanged(m => m.BtnVis15);
            }
        }

        private Visibility _btnVis16;

        public Visibility BtnVis16
        {
            get { return _btnVis16; }
            set
            {
                if (_btnVis16 == value)
                    return;
                _btnVis16 = value;
                NotifyPropertyChanged(m => m.BtnVis16);
            }
        }

        #endregion

        #region Selected Index

        private int _selectedIndex1;

        public int SelectedIndex1
        {
            get { return _selectedIndex1; }
            set
            {
                if (_selectedIndex1 == value)
                    return;
                _selectedIndex1 = value;
                NotifyPropertyChanged(m => m.SelectedIndex1);
            }
        }

        private int _selectedIndex2;

        public int SelectedIndex2
        {
            get { return _selectedIndex2; }
            set
            {
                if (_selectedIndex2 == value)
                    return;
                _selectedIndex2 = value;
                NotifyPropertyChanged(m => m.SelectedIndex2);
            }
        }

        private int _selectedIndex3;

        public int SelectedIndex3
        {
            get { return _selectedIndex3; }
            set
            {
                if (_selectedIndex3 == value)
                    return;
                _selectedIndex3 = value;
                NotifyPropertyChanged(m => m.SelectedIndex3);
            }
        }

        private int _selectedIndex4;

        public int SelectedIndex4
        {
            get { return _selectedIndex4; }
            set
            {
                if (_selectedIndex4 == value)
                    return;
                _selectedIndex4 = value;
                NotifyPropertyChanged(m => m.SelectedIndex4);
            }
        }

        private int _selectedIndex5;

        public int SelectedIndex5
        {
            get { return _selectedIndex5; }
            set
            {
                if (_selectedIndex5 == value)
                    return;
                _selectedIndex5 = value;
                NotifyPropertyChanged(m => m.SelectedIndex5);
            }
        }

        private int _selectedIndex6;

        public int SelectedIndex6
        {
            get { return _selectedIndex6; }
            set
            {
                if (_selectedIndex6 == value)
                    return;
                _selectedIndex6 = value;
                NotifyPropertyChanged(m => m.SelectedIndex6);
            }
        }

        private int _selectedIndex7;

        public int SelectedIndex7
        {
            get { return _selectedIndex7; }
            set
            {
                if (_selectedIndex7 == value)
                    return;
                _selectedIndex7 = value;
                NotifyPropertyChanged(m => m.SelectedIndex7);
            }
        }

        private int _selectedIndex8;

        public int SelectedIndex8
        {
            get { return _selectedIndex8; }
            set
            {
                if (_selectedIndex8 == value)
                    return;
                _selectedIndex8 = value;
                NotifyPropertyChanged(m => m.SelectedIndex8);
            }
        }

        private int _selectedIndex9;

        public int SelectedIndex9
        {
            get { return _selectedIndex9; }
            set
            {
                if (_selectedIndex9 == value)
                    return;
                _selectedIndex9 = value;
                NotifyPropertyChanged(m => m.SelectedIndex9);
            }
        }

        private int _selectedIndex10;

        public int SelectedIndex10
        {
            get { return _selectedIndex10; }
            set
            {
                if (_selectedIndex10 == value)
                    return;
                _selectedIndex10 = value;
                NotifyPropertyChanged(m => m.SelectedIndex10);
            }
        }

        private int _selectedIndex11;

        public int SelectedIndex11
        {
            get { return _selectedIndex11; }
            set
            {
                if (_selectedIndex11 == value)
                    return;
                _selectedIndex11 = value;
                NotifyPropertyChanged(m => m.SelectedIndex11);
            }
        }

        private int _selectedIndex12;

        public int SelectedIndex12
        {
            get { return _selectedIndex12; }
            set
            {
                if (_selectedIndex12 == value)
                    return;
                _selectedIndex12 = value;
                NotifyPropertyChanged(m => m.SelectedIndex12);
            }
        }

        private int _selectedIndex13;

        public int SelectedIndex13
        {
            get { return _selectedIndex13; }
            set
            {
                if (_selectedIndex13 == value)
                    return;
                _selectedIndex13 = value;
                NotifyPropertyChanged(m => m.SelectedIndex13);
            }
        }

        private int _selectedIndex14;

        public int SelectedIndex14
        {
            get { return _selectedIndex14; }
            set
            {
                if (_selectedIndex14 == value)
                    return;
                _selectedIndex14 = value;
                NotifyPropertyChanged(m => m.SelectedIndex14);
            }
        }

        private int _selectedIndex15;

        public int SelectedIndex15
        {
            get { return _selectedIndex15; }
            set
            {
                if (_selectedIndex15 == value)
                    return;
                _selectedIndex15 = value;
                NotifyPropertyChanged(m => m.SelectedIndex15);
            }
        }

        private int _selectedIndex16;

        public int SelectedIndex16
        {
            get { return _selectedIndex16; }
            set
            {
                if (_selectedIndex16 == value)
                    return;
                _selectedIndex16 = value;
                NotifyPropertyChanged(m => m.SelectedIndex16);
            }
        }

        #endregion

        #endregion

        // Methods that will be called by the view
        public void GetTeams()
        {
            IsWeekSet = !WeekNumber.Equals("0");
            SelectedAwayTeams = _serviceAgent.GetSelecetedAwayTeams(WeekNumber);
            SelectedHomeTeams = _serviceAgent.GetSelectedHomeTeams(WeekNumber);
        }

        public void SetOneInput()
        {
            if (!IsLiveGame)
            {
                VideoInputs = new ObservableCollection<string>();
                VideoInputs.Add(String.Empty);
                VideoInputs.Add("0-EARLY");
                VideoInputs.Add("0-LATE");
                VideoInputs.Add("1-EARLY");
                VideoInputs.Add("1-LATE");
            }
        }

        public void SetMultiInput()
        {
            if (IsLiveGame)
            {
                VideoInputs = new ObservableCollection<string>();
                VideoInputs.Add(String.Empty);

                for (int i = 0; i <= 8; i++)
                {
                    VideoInputs.Add(String.Format("{0}-EARLY", i));
                    VideoInputs.Add(String.Format("{0}-LATE", i));
                }
            }
        }

        public void SetMap()
        {
            try
            {
                AddToCollection();
                //WeatherIds = new ObservableCollection<string>();

                //string temp, weatherId = "";
                //foreach (var image in LogoCollection)
                //{
                //    if (image == null)
                //    {
                //        WeatherIds.Add("");
                //        continue;
                //    }

                //    temp = image.Source.ToString();
                //    temp = temp.Substring(temp.IndexOf("/Assets"));
                //    temp = temp.Substring(8, 2);

                //    foreach (var c in temp)
                //    {
                //        if (c.Equals('.'))
                //            break;
                //        if (!c.Equals("") || !c.Equals(null))
                //            weatherId += c;
                //    }

                //    WeatherIds.Add(weatherId);
                //    weatherId = "";
                //}

                SaveToXML();

                StringBuilder map = new StringBuilder();

                foreach (var i in SortIndex)
                    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[i], SelectedHomeTeams[i], WeatherIds[i].ToString(), Descriptions[i], TempCollection[i], SelectedVideoInput[i]));
                
                #region Map Booleans
                //if (TeamChecked1)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[0], SelectedHomeTeams[0], WeatherIds[0].ToString(), Descriptions[0], TempCollection[0], SelectedVideoInput[0]));
                //}
                //if (TeamChecked2)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[1], SelectedHomeTeams[1], WeatherIds[1].ToString(), Descriptions[1], TempCollection[1], SelectedVideoInput[1]));
                //}
                //if (TeamChecked3)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[2], SelectedHomeTeams[2], WeatherIds[2].ToString(), Descriptions[2], TempCollection[2], SelectedVideoInput[2]));
                //}
                //if (TeamChecked4)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[3], SelectedHomeTeams[3], WeatherIds[3].ToString(), Descriptions[3], TempCollection[3], SelectedVideoInput[3]));
                //}
                //if (TeamChecked5)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[4], SelectedHomeTeams[4], WeatherIds[4].ToString(), Descriptions[4], TempCollection[4], SelectedVideoInput[4]));
                //}
                //if (TeamChecked6)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[5], SelectedHomeTeams[5], WeatherIds[5].ToString(), Descriptions[5], TempCollection[5], SelectedVideoInput[5]));
                //}
                //if (TeamChecked7)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[6], SelectedHomeTeams[6], WeatherIds[6].ToString(), Descriptions[6], TempCollection[6], SelectedVideoInput[6]));
                //}
                //if (TeamChecked8)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[7], SelectedHomeTeams[7], WeatherIds[7].ToString(), Descriptions[7], TempCollection[7], SelectedVideoInput[7]));
                //}
                //if (TeamChecked9)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[8], SelectedHomeTeams[8], WeatherIds[8].ToString(), Descriptions[8], TempCollection[8], SelectedVideoInput[8]));
                //}
                //if (TeamChecked10)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[9], SelectedHomeTeams[9], WeatherIds[9].ToString(), Descriptions[9], TempCollection[9], SelectedVideoInput[9]));
                //}
                //if (TeamChecked11)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[10], SelectedHomeTeams[10], WeatherIds[10].ToString(), Descriptions[10], TempCollection[10], SelectedVideoInput[10]));
                //}
                //if (TeamChecked12)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[11], SelectedHomeTeams[11], WeatherIds[11].ToString(), Descriptions[11], TempCollection[11], SelectedVideoInput[11]));
                //}
                //if (TeamChecked13)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[12], SelectedHomeTeams[12], WeatherIds[12].ToString(), Descriptions[12], TempCollection[12], SelectedVideoInput[12]));
                //}
                //if (TeamChecked14)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[13], SelectedHomeTeams[13], WeatherIds[13].ToString(), Descriptions[13], TempCollection[13], SelectedVideoInput[13]));
                //}
                //if (TeamChecked15)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[14], SelectedHomeTeams[14], WeatherIds[14].ToString(), Descriptions[14], TempCollection[14], SelectedVideoInput[14]));
                //}
                //if (TeamChecked16)
                //{
                //    map.Append(_serviceAgent.SetMap(SelectedAwayTeams[15], SelectedHomeTeams[15], WeatherIds[15].ToString(), Descriptions[15], TempCollection[15], SelectedVideoInput[15]));
                //}

                #endregion

                string str = map.ToString().ToUpper();
                CurrentSession.VizEngine.Invoke("SetMapData \"" + str + "\"");
                CurrentSession.IPad.Invoke(String.Format("{0}3 {1}{2}", "\r\n", str, "\r\n"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #region Resets

        public void ResetMap()
        {
            WeekNumber = "0";

            TeamChecked1 = false;
            TeamChecked2 = false;
            TeamChecked3 = false;
            TeamChecked4 = false;
            TeamChecked5 = false;
            TeamChecked6 = false;
            TeamChecked7 = false;
            TeamChecked8 = false;
            TeamChecked9 = false;
            TeamChecked10 = false;
            TeamChecked11 = false;
            TeamChecked12 = false;
            TeamChecked13 = false;
            TeamChecked14 = false;
            TeamChecked15 = false;
            TeamChecked16 = false;

            if (Logo1 != null)
                Logo1.Source = null;

            if (Logo2 != null)
                Logo2.Source = null;

            if (Logo3 != null)
                Logo3.Source = null;

            if (Logo4 != null)
                Logo4.Source = null;

            if (Logo5 != null)
                Logo5.Source = null;

            if (Logo6 != null)
                Logo6.Source = null;

            if (Logo7 != null)
                Logo7.Source = null;

            if (Logo8 != null)
                Logo8.Source = null;

            if (Logo9 != null)
                Logo9.Source = null;

            if (Logo10 != null)
                Logo10.Source = null;

            if (Logo11 != null)
                Logo11.Source = null;

            if (Logo12 != null)
                Logo12.Source = null;

            if (Logo13 != null)
                Logo13.Source = null;

            if (Logo14 != null)
                Logo14.Source = null;

            if (Logo15 != null)
                Logo15.Source = null;

            if (Logo16 != null)
                Logo16.Source = null;

            Desc1 = "";
            Desc2 = "";
            Desc3 = "";
            Desc4 = "";
            Desc5 = "";
            Desc6 = "";
            Desc7 = "";
            Desc8 = "";
            Desc9 = "";
            Desc10 = "";
            Desc11 = "";
            Desc12 = "";
            Desc13 = "";
            Desc14 = "";
            Desc15 = "";
            Desc16 = "";

            Temp1 = "";
            Temp2 = "";
            Temp3 = "";
            Temp4 = "";
            Temp5 = "";
            Temp6 = "";
            Temp7 = "";
            Temp8 = "";
            Temp9 = "";
            Temp10 = "";
            Temp11 = "";
            Temp12 = "";
            Temp13 = "";
            Temp14 = "";
            Temp15 = "";
            Temp16 = "";

            IsLiveGame = false;
            SetOneInput();
        }

        public void ResetIndex()
        {
            BtnVis1 = Visibility.Hidden;
            BtnVis2 = Visibility.Hidden;
            BtnVis3 = Visibility.Hidden;
            BtnVis4 = Visibility.Hidden;
            BtnVis5 = Visibility.Hidden;
            BtnVis6 = Visibility.Hidden;
            BtnVis7 = Visibility.Hidden;
            BtnVis8 = Visibility.Hidden;
            BtnVis9 = Visibility.Hidden;
            BtnVis10 = Visibility.Hidden;
            BtnVis11 = Visibility.Hidden;
            BtnVis12 = Visibility.Hidden;
            BtnVis13 = Visibility.Hidden;
            BtnVis14 = Visibility.Hidden;
            BtnVis15 = Visibility.Hidden;
            BtnVis16 = Visibility.Hidden;

            TeamChecked1 = false;
            TeamChecked2 = false;
            TeamChecked3 = false;
            TeamChecked4 = false;
            TeamChecked5 = false;
            TeamChecked6 = false;
            TeamChecked7 = false;
            TeamChecked8 = false;
            TeamChecked9 = false;
            TeamChecked10 = false;
            TeamChecked11 = false;
            TeamChecked12 = false;
            TeamChecked13 = false;
            TeamChecked14 = false;
            TeamChecked15 = false;
            TeamChecked16 = false;

            SortIndex.Clear();

            index = 1;
        }

        #endregion

        #region Checkbox Methods
        public void SetCheck1()
        {
            SetContent(0);
        }

        public void SetCheck2()
        {
            SetContent(1);
        }

        public void SetCheck3()
        {
            SetContent(2);
        }

        public void SetCheck4()
        {
            SetContent(3);
        }

        public void SetCheck5()
        {
            SetContent(4);
        }

        public void SetCheck6()
        {
            SetContent(5);
        }

        public void SetCheck7()
        {
            SetContent(6);
        }

        public void SetCheck8()
        {
            SetContent(7);
        }

        public void SetCheck9()
        {
            SetContent(8);
        }

        public void SetCheck10()
        {
            SetContent(9);
        }

        public void SetCheck11()
        {
            SetContent(10);
        }

        public void SetCheck12()
        {
            SetContent(11);
        }

        public void SetCheck13()
        {
            SetContent(12);
        }

        public void SetCheck14()
        {
            SetContent(13);
        }

        public void SetCheck15()
        {
            SetContent(14);
        }

        public void SetCheck16()
        {
            SetContent(15);
        }
        #endregion

        // TODO: Optionally add callback methods for async calls to the service agent
        private string GetAutoDesc(Image image)
        {
            string temp, weatherId = "";

            temp = image.Source.ToString();
            temp = temp.Substring(temp.IndexOf("/Assets"));
            temp = temp.Substring(8, 2);

            foreach (var c in temp)
            {
                if (c.Equals('.'))
                    break;
                if (!c.Equals("") || !c.Equals(null))
                    weatherId += c;
            }
            return _descDict[weatherId];
        }

        private void SetContent(int number)
        {
            SortIndex.Add(number);

            switch (number)
            {
                case 0:
                    BtnContent1 = index.ToString();
                    BtnVis1 = Visibility.Visible;
                    break;
                case 1:
                    BtnContent2 = index.ToString();
                    BtnVis2 = Visibility.Visible;
                    break;
                case 2:
                    BtnContent3 = index.ToString();
                    BtnVis3 = Visibility.Visible;
                    break;
                case 3:
                    BtnContent4 = index.ToString();
                    BtnVis4 = Visibility.Visible;
                    break;
                case 4:
                    BtnContent5 = index.ToString();
                    BtnVis5 = Visibility.Visible;
                    break;
                case 5:
                    BtnContent6 = index.ToString();
                    BtnVis6 = Visibility.Visible;
                    break;
                case 6:
                    BtnContent7 = index.ToString();
                    BtnVis7 = Visibility.Visible;
                    break;
                case 7:
                    BtnContent8 = index.ToString();
                    BtnVis8 = Visibility.Visible;
                    break;
                case 8:
                    BtnContent9 = index.ToString();
                    BtnVis9 = Visibility.Visible;
                    break;
                case 9:
                    BtnContent10 = index.ToString();
                    BtnVis10 = Visibility.Visible;
                    break;
                case 10:
                    BtnContent11 = index.ToString();
                    BtnVis11 = Visibility.Visible;
                    break;
                case 11:
                    BtnContent12 = index.ToString();
                    BtnVis12 = Visibility.Visible;
                    break;
                case 12:
                    BtnContent13 = index.ToString();
                    BtnVis13 = Visibility.Visible;
                    break;
                case 13:
                    BtnContent14 = index.ToString();
                    BtnVis14 = Visibility.Visible;
                    break;
                case 14:
                    BtnContent15 = index.ToString();
                    BtnVis15 = Visibility.Visible;
                    break;
                case 15:
                    BtnContent16 = index.ToString();
                    BtnVis16 = Visibility.Visible;
                    break;
            }
            index++;
        }

        private void AddToCollection()
        {
            LogoCollection = new ObservableCollection<Image>
                {
                    Logo1,
                    Logo2,
                    Logo3,
                    Logo4,
                    Logo5,
                    Logo6,
                    Logo7,
                    Logo8,
                    Logo9,
                    Logo10,
                    Logo11,
                    Logo12,
                    Logo13,
                    Logo14,
                    Logo15,
                    Logo16
                };

            Descriptions = new ObservableCollection<string>
                {
                    Desc1,
                    Desc2,
                    Desc3,
                    Desc4,
                    Desc5,
                    Desc6,
                    Desc7,
                    Desc8,
                    Desc9,
                    Desc10,
                    Desc11,
                    Desc12,
                    Desc13,
                    Desc14,
                    Desc15,
                    Desc16,
                };

            TempCollection = new ObservableCollection<string>
                {
                    Temp1,
                    Temp2,
                    Temp3,
                    Temp4,
                    Temp5,
                    Temp6,
                    Temp7,
                    Temp8,
                    Temp9,
                    Temp10,
                    Temp11,
                    Temp12,
                    Temp13,
                    Temp14,
                    Temp15,
                    Temp16
                };

            WeatherIds = new ObservableCollection<int>
                {
                    SelectedIndex1, 
                    SelectedIndex2, 
                    SelectedIndex3, 
                    SelectedIndex4, 
                    SelectedIndex5, 
                    SelectedIndex6, 
                    SelectedIndex7, 
                    SelectedIndex8, 
                    SelectedIndex9, 
                    SelectedIndex10,
                    SelectedIndex11,
                    SelectedIndex12,
                    SelectedIndex13,
                    SelectedIndex14,
                    SelectedIndex15,
                    SelectedIndex16
                };
        }

        private void LoadFromXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("RZCData.xml");

                var week = doc.GetElementsByTagName("Week");
                for (int i = 0; i < week.Count; i++)
                    WeekNumber = week[i].InnerText;
                
                GetTeams();

                var inputs = doc.GetElementsByTagName("Input");
                SelectedIndex1 = int.Parse(inputs[0].Attributes["weatherID"].Value);
                SelectedIndex2 = int.Parse(inputs[1].Attributes["weatherID"].Value);
                SelectedIndex3 = int.Parse(inputs[2].Attributes["weatherID"].Value);
                SelectedIndex4 = int.Parse(inputs[3].Attributes["weatherID"].Value);
                SelectedIndex5 = int.Parse(inputs[4].Attributes["weatherID"].Value);
                SelectedIndex6 = int.Parse(inputs[5].Attributes["weatherID"].Value);
                SelectedIndex7 = int.Parse(inputs[6].Attributes["weatherID"].Value);
                SelectedIndex8 = int.Parse(inputs[7].Attributes["weatherID"].Value);
                SelectedIndex9 = int.Parse(inputs[8].Attributes["weatherID"].Value);
                SelectedIndex10 = int.Parse(inputs[9].Attributes["weatherID"].Value);
                SelectedIndex11 = int.Parse(inputs[10].Attributes["weatherID"].Value);
                SelectedIndex12 = int.Parse(inputs[11].Attributes["weatherID"].Value);
                SelectedIndex13 = int.Parse(inputs[12].Attributes["weatherID"].Value);
                SelectedIndex14 = int.Parse(inputs[13].Attributes["weatherID"].Value);
                SelectedIndex15 = int.Parse(inputs[14].Attributes["weatherID"].Value);
                SelectedIndex16 = int.Parse(inputs[15].Attributes["weatherID"].Value);

                Temp1 = inputs[0].Attributes["Temp"].Value;
                Temp2 = inputs[1].Attributes["Temp"].Value;
                Temp3 = inputs[2].Attributes["Temp"].Value;
                Temp4 = inputs[3].Attributes["Temp"].Value;
                Temp5 = inputs[4].Attributes["Temp"].Value;
                Temp6 = inputs[5].Attributes["Temp"].Value;
                Temp7 = inputs[6].Attributes["Temp"].Value;
                Temp8 = inputs[7].Attributes["Temp"].Value;
                Temp9 = inputs[8].Attributes["Temp"].Value;
                Temp10 = inputs[9].Attributes["Temp"].Value;
                Temp11 = inputs[10].Attributes["Temp"].Value;
                Temp12 = inputs[11].Attributes["Temp"].Value;
                Temp13 = inputs[12].Attributes["Temp"].Value;
                Temp14 = inputs[13].Attributes["Temp"].Value;
                Temp15 = inputs[14].Attributes["Temp"].Value;
                Temp16 = inputs[15].Attributes["Temp"].Value;
            }
            catch (Exception e)
            {
                Console.WriteLine("PROBLEM READING FROM XML: " + e);
            }
        }

        private void SaveToXML()
        {
            try
            {
                XDocument doc = XDocument.Load("RZCData.xml");

                if (doc.Root == null) return;
                
                IEnumerable<XElement> test = doc.Root.Descendants("Week");
                foreach (var xElement in test)
                    xElement.Value = WeekNumber;
                
                IEnumerable<XElement> map = doc.Root.Descendants("Input");
                
                int i = 0;
                foreach (var element in map)
                {
                    element.Attribute("weatherID").Value = WeatherIds[i].ToString();
                    element.Attribute("Temp").Value = TempCollection[i] ?? "";
                    i++;
                }

                doc.Save("RZCData.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine("PROBLEM SAVING TO XML: " + e);
            }
        }

        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
    }
}