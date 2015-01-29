using System;
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
    public class SponsorLogoViewModel : ViewModelBase<SponsorLogoViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private ISponsorLogoServiceAgent _serviceAgent;

        // Default ctor
        public SponsorLogoViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public SponsorLogoViewModel(ISponsorLogoServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet
        private string _logo;

        public string Logo
        {
            get { return _logo; }
            set
            {
                if (_logo == value)
                    return;
                _logo = value;
                NotifyPropertyChanged(m => m.Logo);
            }
        }

        // TODO: Add methods that will be called by the view
        public void LoadLogo()
        {
            var logo = _serviceAgent.LoadLogo();
            Logo = logo;
            string temp = Logo.Replace(@"\", @"/");

            CurrentSession.VizEngine.Invoke("SetSponsorLogo \"" + temp + "\"");
            //CurrentSession.IPad.Invoke(String.Format("{0}3 {1}{2}", "\r\n", Logo, "\r\n"));
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