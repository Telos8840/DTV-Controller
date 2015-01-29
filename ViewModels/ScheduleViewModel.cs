using System;
using System.Collections.Generic;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using System.Windows.Documents;
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
    public class ScheduleViewModel : ViewModelBase<ScheduleViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private IScheduleServiceAgent _serviceAgent;

        // Default ctor
        public ScheduleViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public ScheduleViewModel(IScheduleServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;
            Teams = new ObservableCollection<CoreTeams>(CurrentSession.GetTeams());
            TeamNames = new ObservableCollection<CoreTeams>(CurrentSession.GetTeams());
            TeamNames.RemoveAt(0);
            Schedules = _serviceAgent.SetSchedule();
            WeekNumber = "14";
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet

        #region Properties

        private ObservableCollection<CoreTeams> _teams;

        public ObservableCollection<CoreTeams> Teams
        {
            get { return _teams; }
            set
            {
                if (_teams == value)
                    return;
                _teams = value;
                NotifyPropertyChanged(m => m.Teams);
            }
        }

        private ObservableCollection<CoreTeams> _teamNames;

        public ObservableCollection<CoreTeams> TeamNames
        {
            get { return _teamNames; }
            set
            {
                if (_teamNames == value)
                    return;
                _teamNames = value;
                NotifyPropertyChanged(m => m.TeamNames);
            }
        }


        private CoreTeams _selectedTeamTri;

        public CoreTeams SelectedTeamTri
        {
            get { return _selectedTeamTri; }
            set
            {
                if (_selectedTeamTri == value)
                    return;
                _selectedTeamTri = value;
                NotifyPropertyChanged(m => m.SelectedTeamTri);
            }
        }

        private Schedule _selectedTeam;

        public Schedule SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                if (_selectedTeam == value)
                    return;
                _selectedTeam = value;
                NotifyPropertyChanged(m => m.SelectedTeam);
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

        #endregion

        #region VsTeam Properties

        private string _vsTeam1;

        public string VsTeam1
        {
            get { return _vsTeam1; }
            set
            {
                if (_vsTeam1 == value)
                    return;
                _vsTeam1 = value;
                NotifyPropertyChanged(m => m.VsTeam1);
            }
        }

        private string _vsTeam2;

        public string VsTeam2
        {
            get { return _vsTeam2; }
            set
            {
                if (_vsTeam2 == value)
                    return;
                _vsTeam2 = value;
                NotifyPropertyChanged(m => m.VsTeam2);
            }
        }

        private string _vsTeam3;

        public string VsTeam3
        {
            get { return _vsTeam3; }
            set
            {
                if (_vsTeam3 == value)
                    return;
                _vsTeam3 = value;
                NotifyPropertyChanged(m => m.VsTeam3);
            }
        }

        private string _vsTeam4;

        public string VsTeam4
        {
            get { return _vsTeam4; }
            set
            {
                if (_vsTeam4 == value)
                    return;
                _vsTeam4 = value;
                NotifyPropertyChanged(m => m.VsTeam4);
            }
        }

        private string _vsTeam5;

        public string VsTeam5
        {
            get { return _vsTeam5; }
            set
            {
                if (_vsTeam5 == value)
                    return;
                _vsTeam5 = value;
                NotifyPropertyChanged(m => m.VsTeam5);
            }
        }

        private string _vsTeam6;

        public string VsTeam6
        {
            get { return _vsTeam6; }
            set
            {
                if (_vsTeam6 == value)
                    return;
                _vsTeam6 = value;
                NotifyPropertyChanged(m => m.VsTeam6);
            }
        }

        private string _vsTeam7;

        public string VsTeam7
        {
            get { return _vsTeam7; }
            set
            {
                if (_vsTeam7 == value)
                    return;
                _vsTeam7 = value;
                NotifyPropertyChanged(m => m.VsTeam7);
            }
        }

        #endregion

        #region HomeAway Properties

        private Boolean _homeAway1;

        public Boolean HomeAway1
        {
            get { return _homeAway1; }
            set
            {
                if (_homeAway1 == value)
                    return;
                _homeAway1 = value;
                NotifyPropertyChanged(m => m.HomeAway1);
            }
        }

        private Boolean _homeAway2;

        public Boolean HomeAway2
        {
            get { return _homeAway2; }
            set
            {
                if (_homeAway2 == value)
                    return;
                _homeAway2 = value;
                NotifyPropertyChanged(m => m.HomeAway2);
            }
        }

        private Boolean _homeAway3;

        public Boolean HomeAway3
        {
            get { return _homeAway3; }
            set
            {
                if (_homeAway3 == value)
                    return;
                _homeAway3 = value;
                NotifyPropertyChanged(m => m.HomeAway3);
            }
        }

        private Boolean _homeAway4;

        public Boolean HomeAway4
        {
            get { return _homeAway4; }
            set
            {
                if (_homeAway4 == value)
                    return;
                _homeAway4 = value;
                NotifyPropertyChanged(m => m.HomeAway4);
            }
        }

        private Boolean _homeAway5;

        public Boolean HomeAway5
        {
            get { return _homeAway5; }
            set
            {
                if (_homeAway5 == value)
                    return;
                _homeAway5 = value;
                NotifyPropertyChanged(m => m.HomeAway5);
            }
        }

        private Boolean _homeAway6;

        public Boolean HomeAway6
        {
            get { return _homeAway6; }
            set
            {
                if (_homeAway6 == value)
                    return;
                _homeAway6 = value;
                NotifyPropertyChanged(m => m.HomeAway6);
            }
        }

        private Boolean _homeAway7;

        public Boolean HomeAway7
        {
            get { return _homeAway7; }
            set
            {
                if (_homeAway7 == value)
                    return;
                _homeAway7 = value;
                NotifyPropertyChanged(m => m.HomeAway7);
            }
        }

        #endregion

        private List<Schedule> _schedules;

        public List<Schedule> Schedules
        {
            get { return _schedules; }
            set
            {
                if (_schedules == value)
                    return;
                _schedules = value;
                NotifyPropertyChanged(m => m.Schedules);
            }
        }

        // TODO: Add methods that will be called by the view
        public void SaveXML()
        {
            throw new NotImplementedException();
        }

        public void SendSchedule()
        {
            _serviceAgent.SendSchedule(Schedules, Convert.ToInt16(WeekNumber));
        }

        public void GetSchedule()
        {
            ClearData();
            SelectedTeam = _serviceAgent.GetSchedule(SelectedTeamTri, Schedules);
            bool set1 = false, set2 = false, set3 = false, set4 = false, set5 = false, set6 = false, set7 = false;

            if (SelectedTeam == null) return;
            for (int i = Convert.ToInt16(WeekNumber); i <= 17; i++)
            {
                if (!set1)
                {
                    SetData1(i - 2);
                    set1 = true;
                    continue;
                }
                if (!set2)
                {
                    SetData2(i - 2);
                    set2 = true;
                    continue;
                }
                if (!set3)
                {
                    SetData3(i - 2);
                    set3 = true;
                    continue;
                }
                if (!set4)
                {
                    SetData4(i - 2);
                    set4 = true;
                    continue;
                }
                if (!set5)
                {
                    SetData5(i - 2);
                    set5 = true;
                    continue;
                }
                if (!set6)
                {
                    SetData6(i - 2);
                    set6 = true;
                    continue;
                }
                if (!set7)
                {
                    SetData7(i - 2);
                    set7 = true;
                }
            }
        }

        // TODO: Optionally add callback methods for async calls to the service agent

        #region SetData Functions

        private void SetData1(int index)
        {
            HomeAway1 = Convert.ToBoolean(SelectedTeam.UpcomingTeam[index].Item1);
            VsTeam1 = SelectedTeam.UpcomingTeam[index].Item2;
        }

        private void SetData2(int index)
        {
            HomeAway2 = Convert.ToBoolean(SelectedTeam.UpcomingTeam[index].Item1);
            VsTeam2 = SelectedTeam.UpcomingTeam[index].Item2;
        }

        private void SetData3(int index)
        {
            HomeAway3 = Convert.ToBoolean(SelectedTeam.UpcomingTeam[index].Item1);
            VsTeam3 = SelectedTeam.UpcomingTeam[index].Item2;
        }

        private void SetData4(int index)
        {
            HomeAway4 = Convert.ToBoolean(SelectedTeam.UpcomingTeam[index].Item1);
            VsTeam4 = SelectedTeam.UpcomingTeam[index].Item2;
        }

        private void SetData5(int index)
        {
            HomeAway5 = Convert.ToBoolean(SelectedTeam.UpcomingTeam[index].Item1);
            VsTeam5 = SelectedTeam.UpcomingTeam[index].Item2;
        }

        private void SetData6(int index)
        {
            HomeAway6 = Convert.ToBoolean(SelectedTeam.UpcomingTeam[index].Item1);
            VsTeam6 = SelectedTeam.UpcomingTeam[index].Item2;
        }

        private void SetData7(int index)
        {
            HomeAway7 = Convert.ToBoolean(SelectedTeam.UpcomingTeam[index].Item1);
            VsTeam7 = SelectedTeam.UpcomingTeam[index].Item2;
        }

        #endregion

        private void ClearData()
        {
            HomeAway1 = false;
            HomeAway2 = false;
            HomeAway3 = false;
            HomeAway4 = false;
            HomeAway5 = false;
            HomeAway6 = false;
            HomeAway7 = false;

            VsTeam1 = "";
            VsTeam2 = "";
            VsTeam3 = "";
            VsTeam4 = "";
            VsTeam5 = "";
            VsTeam6 = "";
            VsTeam7 = "";
        }

        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
    }
}