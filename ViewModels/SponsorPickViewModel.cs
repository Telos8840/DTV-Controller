using System;
using System.Collections.ObjectModel;
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
    public class SponsorPickViewModel : ViewModelBase<SponsorPickViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private ISponsorPickServiceAgent _serviceAgent;

        // Default ctor
        public SponsorPickViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public SponsorPickViewModel(ISponsorPickServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;
            Teams = new ObservableCollection<CoreTeams>(CurrentSession.Teams);
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        #region Properties

        // TODO: Add properties using the mvvmprop code snippet
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

        private CoreTeams _selectedAwayTeam;

        public CoreTeams SelectedAwayTeam
        {
            get { return _selectedAwayTeam; }
            set
            {
                if (_selectedAwayTeam == value)
                    return;
                _selectedAwayTeam = value;
                NotifyPropertyChanged(m => m.SelectedAwayTeam);
            }
        }

        private CoreTeams _selectedHomeTeam;

        public CoreTeams SelectedHomeTeam
        {
            get { return _selectedHomeTeam; }
            set
            {
                if (_selectedHomeTeam == value)
                    return;
                _selectedHomeTeam = value;
                NotifyPropertyChanged(m => m.SelectedHomeTeam);
            }
        }

        private AwaySponsorPick _awaySponsorPick;

        public AwaySponsorPick AwaySponsorPick
        {
            get { return _awaySponsorPick; }
            set
            {
                if (_awaySponsorPick == value)
                    return;
                _awaySponsorPick = value;
                NotifyPropertyChanged(m => m.AwaySponsorPick);
            }
        }

        private string _awayPlayerLogo;

        public string AwayPlayerLogo
        {
            get { return _awayPlayerLogo; }
            set
            {
                if (_awayPlayerLogo == value)
                    return;
                _awayPlayerLogo = value;
                NotifyPropertyChanged(m => m.AwayPlayerLogo);
            }
        }

        private string _awayTeamLogo;

        public string AwayTeamLogo
        {
            get { return _awayTeamLogo; }
            set
            {
                if (_awayTeamLogo == value)
                    return;
                _awayTeamLogo = value;
                NotifyPropertyChanged(m => m.AwayTeamLogo);
            }
        }

        private HomeSponsorPick _homeSponsorPicks;

        public HomeSponsorPick HomeSponsorPicks
        {
            get { return _homeSponsorPicks; }
            set
            {
                if (_homeSponsorPicks == value)
                    return;
                _homeSponsorPicks = value;
                NotifyPropertyChanged(m => m.HomeSponsorPicks);
            }
        }

        private string _homePlayerLogo;

        public string HomePlayerLogo
        {
            get { return _homePlayerLogo; }
            set
            {
                if (_homePlayerLogo == value)
                    return;
                _homePlayerLogo = value;
                NotifyPropertyChanged(m => m.HomePlayerLogo);
            }
        }

        private string _homeTeamLogo;

        public string HomeTeamLogo
        {
            get { return _homeTeamLogo; }
            set
            {
                if (_homeTeamLogo == value)
                    return;
                _homeTeamLogo = value;
                NotifyPropertyChanged(m => m.HomeTeamLogo);
            }
        }

        #endregion

        // TODO: Add methods that will be called by the view
        public void LoadAwayTeam()
        {
            var away = _serviceAgent.LoadAwayTeam(SelectedAwayTeam.Name);
            AwaySponsorPick = away;
            AwayTeamLogo = AwaySponsorPick.TeamLogo;
        }

        public void LoadAwayLogo()
        {
            var pic = _serviceAgent.LoadAwayLogo();
            if (pic != null)
                AwayPlayerLogo = pic;
        }

        public void LoadHomeTeam()
        {
            var home = _serviceAgent.LoadHomeTeam(SelectedHomeTeam.Name);
            HomeSponsorPicks = home;
            HomeTeamLogo = HomeSponsorPicks.TeamLogo;
        }

        public void LoadHomeLogo()
        {
            var pic = _serviceAgent.LoadHomeLogo();
            if (pic != null)
                HomePlayerLogo = pic;
        }

        public void SetSponsorPicks()
        {
            _serviceAgent.SetSponsorPicks(AwaySponsorPick, HomeSponsorPicks);
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