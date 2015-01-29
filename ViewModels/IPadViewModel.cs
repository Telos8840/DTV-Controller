using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
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
    public class IPadViewModel : ViewModelBase<IPadViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private IiPadServiceAgent _serviceAgent;

        // Default ctor
        public IPadViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public IPadViewModel(IiPadServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;
            GetiPad();
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet
        private iPad _iPad;

        public iPad IPad
        {
            get { return _iPad; }
            set
            {
                if (_iPad == value)
                    return;
                _iPad = value;
                NotifyPropertyChanged(m => m.IPad);
            }
        }

        // TODO: Add methods that will be called by the view
        private void GetiPad()
        {
            IPad = CurrentSession.IPad;
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