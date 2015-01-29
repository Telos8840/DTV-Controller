using System;
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
    public class PlayoffViewModel : ViewModelBase<PlayoffViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private IPlayoffServiceAgent _serviceAgent;

        // Default ctor
        public PlayoffViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public PlayoffViewModel(IPlayoffServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet
        private string _awayTeam;

        public string AwayTeam
        {
            get { return _awayTeam; }
            set
            {
                if (_awayTeam == value)
                    return;
                _awayTeam = value;
                NotifyPropertyChanged(m => m.AwayTeam);
            }
        }

        private string _homeTeam;

        public string HomeTeam
        {
            get { return _homeTeam; }
            set
            {
                if (_homeTeam == value)
                    return;
                _homeTeam = value;
                NotifyPropertyChanged(m => m.HomeTeam);
            }
        }

        // TODO: Add methods that will be called by the view
        public void LoadAwayTeam()
        {
            var awayTeam = _serviceAgent.LoadAwayTeam();
            AwayTeam = awayTeam;
        }

        public void LoadHomeTeam()
        {
            var homeTeam = _serviceAgent.LoadHomeTeam();
            HomeTeam = homeTeam;
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