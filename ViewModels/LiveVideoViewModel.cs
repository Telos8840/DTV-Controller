using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using Elysium.Notifications;
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
    public class LiveVideoViewModel : ViewModelBase<LiveVideoViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private ILiveVideoServiceAgent _serviceAgent;

        // Default ctor
        public LiveVideoViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public LiveVideoViewModel(ILiveVideoServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;

            IsGroupSet = false;
            IsAllSet = false;
            AreBothSet = false;
            EnableButton = false;
            Inputs = new ObservableCollection<string> {string.Empty};
            Groups = new ObservableCollection<string> {string.Empty};
            SelectedVideoInput = new ObservableCollection<string>();
            Brushes = new ObservableCollection<string>();

            WeekNumber = "0";
            GroupNumber = "0";

            for (int i = 2; i <= 8; i++)
            {
                Inputs.Add(i.ToString());
                Groups.Add((i-1).ToString());
            }
            Groups.Add("8");

            for (int i = 0; i <= 15; i++)
            {
                SelectedVideoInput.Add(null);
                Brushes.Add("#FF848484");
            }

            LoadFromXML();
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet

        #region Properties

        private string _selectedInput;

        public string SelectedInput
        {
            get { return _selectedInput; }
            set
            {
                if (_selectedInput == value)
                    return;
                _selectedInput = value;
                NotifyPropertyChanged(m => m.SelectedInput);
            }
        }

        private string _selectedGroup;

        public string SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                if (_selectedGroup == value)
                    return;
                _selectedGroup = value;
                NotifyPropertyChanged(m => m.SelectedGroup);
            }
        }

        private Boolean _isInputSet;

        public Boolean IsInputSet
        {
            get { return _isInputSet; }
            set
            {
                if (_isInputSet == value)
                    return;
                _isInputSet = value;
                NotifyPropertyChanged(m => m.IsInputSet);
            }
        }

        private Boolean _isGroupSet;

        public Boolean IsGroupSet
        {
            get { return _isGroupSet; }
            set
            {
                if (_isGroupSet == value)
                    return;
                _isGroupSet = value;
                NotifyPropertyChanged(m => m.IsGroupSet);
            }
        }

        private Boolean _isAllSet;

        public Boolean IsAllSet
        {
            get { return _isAllSet; }
            set
            {
                if (_isAllSet == value)
                    return;
                _isAllSet = value;
                NotifyPropertyChanged(m => m.IsAllSet);
            }
        }

        private Boolean _areBothSet;

        public Boolean AreBothSet
        {
            get { return _areBothSet; }
            set
            {
                if (_areBothSet == value)
                    return;
                _areBothSet = value;
                NotifyPropertyChanged(m => m.AreBothSet);
            }
        }

        private ObservableCollection<string> _inputs;

        public ObservableCollection<string> Inputs
        {
            get { return _inputs; }
            set
            {
                if (_inputs == value)
                    return;
                _inputs = value;
                NotifyPropertyChanged(m => m.Inputs);
            }
        }

        private ObservableCollection<string> _groups;

        public ObservableCollection<string> Groups
        {
            get { return _groups; }
            set
            {
                if (_groups == value)
                    return;
                _groups = value;
                NotifyPropertyChanged(m => m.Groups);
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

        private string _groupNumber;

        public string GroupNumber
        {
            get { return _groupNumber; }
            set
            {
                if (_groupNumber == value)
                    return;
                _groupNumber = value;
                NotifyPropertyChanged(m => m.GroupNumber);
            }
        }

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

        private ObservableCollection<string> _brushes;

        public ObservableCollection<string> Brushes
        {
            get { return _brushes; }
            set
            {
                if (_brushes == value)
                    return;
                _brushes = value;
                NotifyPropertyChanged(m => m.Brushes);
            }
        }

        private Boolean _enableButton;

        public Boolean EnableButton
        {
            get { return _enableButton; }
            set
            {
                if (_enableButton == value)
                    return;
                _enableButton = value;
                NotifyPropertyChanged(m => m.EnableButton);
            }
        }

        #endregion

        // TODO: Add methods that will be called by the view
        public void GetTeams()
        {
            EnableButton = !WeekNumber.Equals("0") && !GroupNumber.Equals("0");
            SelectedAwayTeams = _serviceAgent.GetSelecetedAwayTeams(WeekNumber);
            SelectedHomeTeams = _serviceAgent.GetSelectedHomeTeams(WeekNumber);
        }

        public void EnableGroups()
        {
            IsGroupSet = !SelectedGroup.Equals(string.Empty);
            EnableVideoInputs();
            GroupNumber = "0";
            ChangeColors();
        }

        public void EnableInputs()
        {
            IsInputSet = !SelectedInput.Equals(string.Empty);
            EnableVideoInputs();
            GroupNumber = "0";
            ChangeColors();
        }

        public void ChangeColors()
        {
            const string DarkGreen = "#FF006400";
            const string DarkRed = "#FF8B0000";
            string group = "-" + GroupNumber;
            const string reset = "-0";
            EnableButton = !WeekNumber.Equals("0") && !GroupNumber.Equals("0");

            if (group.Equals(reset))
            {
                ResetColor();
                return;
            }

            for (int i = 0; i <= 15; i++)
                if (SelectedVideoInput[i] != null)
                    Brushes[i] = SelectedVideoInput[i].Contains(@group) ? DarkGreen : DarkRed;
        }

        public void ResetData()
        {
            ResetColor();
            IsAllSet = false;
            IsGroupSet = false;
            IsInputSet = false;
            AreBothSet = false;
            WeekNumber = "0";
            GroupNumber = "0";
            SelectedInput = "";
            SelectedGroup = "";

            for (int i = 0; i < SelectedVideoInput.Count; i++)
            {
                SelectedVideoInput[i] = "";
            }
        }

        private void ResetColor()
        {
            for (int i = 0; i <= 15; i++)
                Brushes[i] = "#FF848484";
        }

        private void EnableVideoInputs()
        {
            IsAllSet = IsInputSet && IsGroupSet;
            AreBothSet = IsInputSet && IsGroupSet;

            if (IsAllSet)
            {
                VideoInputs = new ObservableCollection<string>();
                VideoInputs.Add(String.Empty);

                for (int i = 1; i <= Convert.ToInt16(SelectedInput); i++)
                    for (int j = 1; j <= Convert.ToInt16(SelectedGroup); j++)
                        VideoInputs.Add(i.ToString() + "-" + j.ToString());
            }
        }

        public void SetLiveVideos()
        {
            if (GroupNumber.Equals("0") || WeekNumber.Equals("0"))
                return;

            _serviceAgent.SetLiveVideos(GroupNumber, WeekNumber, SelectedVideoInput, SelectedHomeTeams, SelectedAwayTeams);
        }

        private void LoadFromXML()
        {
            XDocument doc = XDocument.Load("RZCData.xml");

            var week = doc.Root.Descendants("Week");
            foreach (var element in week)
                WeekNumber = element.Value;

            GetTeams();
        }

        // TODO: Optionally add callback methods for async calls to the service agent
        
        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
    }
}