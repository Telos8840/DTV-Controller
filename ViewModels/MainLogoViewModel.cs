using System;
using System.Windows;
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
    public class MainLogoViewModel : ViewModelBase<MainLogoViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private IMainLogoServiceAgent _serviceAgent;

        // Default ctor
        public MainLogoViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public MainLogoViewModel(IMainLogoServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;
            Logo1Checked = true;
            Btn1Alignment = HorizontalAlignment.Center;
            Logo1Alignment = HorizontalAlignment.Center;
            Toggle1Alignment = HorizontalAlignment.Center;
            Btn2Visibility = Visibility.Hidden;
            Logo2Visibility = Visibility.Hidden;
            Toggle2Visibility = Visibility.Hidden;
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet
        private string _logo1;

        public string Logo1
        {
            get { return _logo1; }
            set
            {
                if (_logo1 == value)
                    return;
                _logo1 = value;
                NotifyPropertyChanged(m => m.Logo1);
            }
        }

        private string _logo2;

        public string Logo2
        {
            get { return _logo2; }
            set
            {
                if (_logo2 == value)
                    return;
                _logo2 = value;
                NotifyPropertyChanged(m => m.Logo2);
            }
        }

        private Boolean _logo1Checked;

        public Boolean Logo1Checked
        {
            get { return _logo1Checked; }
            set
            {
                if (_logo1Checked == value)
                    return;
                _logo1Checked = value;
                NotifyPropertyChanged(m => m.Logo1Checked);
            }
        }

        private Boolean _logo2Checked;

        public Boolean Logo2Checked
        {
            get { return _logo2Checked; }
            set
            {
                if (_logo2Checked == value)
                    return;
                _logo2Checked = value;
                NotifyPropertyChanged(m => m.Logo2Checked);
            }
        }

        private Boolean _logo1DimChecked;

        public Boolean Logo1DimChecked
        {
            get { return _logo1DimChecked; }
            set
            {
                if (_logo1DimChecked == value)
                    return;
                _logo1DimChecked = value;
                NotifyPropertyChanged(m => m.Logo1DimChecked);
            }
        }

        private Boolean _logo2DimChecked;

        public Boolean Logo2DimChecked
        {
            get { return _logo2DimChecked; }
            set
            {
                if (_logo2DimChecked == value)
                    return;
                _logo2DimChecked = value;
                NotifyPropertyChanged(m => m.Logo2DimChecked);
            }
        }

        private HorizontalAlignment _toggle1Alignment;

        public HorizontalAlignment Toggle1Alignment
        {
            get { return _toggle1Alignment; }
            set
            {
                if (_toggle1Alignment == value)
                    return;
                _toggle1Alignment = value;
                NotifyPropertyChanged(m => m.Toggle1Alignment);
            }
        }

        private HorizontalAlignment _btn1Btn1Alignment;

        public HorizontalAlignment Btn1Alignment
        {
            get { return _btn1Btn1Alignment; }
            set
            {
                if (_btn1Btn1Alignment == value)
                    return;
                _btn1Btn1Alignment = value;
                NotifyPropertyChanged(m => m.Btn1Alignment);
            }
        }

        private HorizontalAlignment _logo1Alignment;

        public HorizontalAlignment Logo1Alignment
        {
            get { return _logo1Alignment; }
            set
            {
                if (_logo1Alignment == value)
                    return;
                _logo1Alignment = value;
                NotifyPropertyChanged(m => m.Logo1Alignment);
            }
        }

        private Visibility _toggle2Visibility;

        public Visibility Toggle2Visibility
        {
            get { return _toggle2Visibility; }
            set
            {
                if (_toggle2Visibility == value)
                    return;
                _toggle2Visibility = value;
                NotifyPropertyChanged(m => m.Toggle2Visibility);
            }
        }

        private Visibility _btn2Visibility;

        public Visibility Btn2Visibility
        {
            get { return _btn2Visibility; }
            set
            {
                if (_btn2Visibility == value)
                    return;
                _btn2Visibility = value;
                NotifyPropertyChanged(m => m.Btn2Visibility);
            }
        }

        private Visibility _logo2Visibility;

        public Visibility Logo2Visibility
        {
            get { return _logo2Visibility; }
            set
            {
                if (_logo2Visibility == value)
                    return;
                _logo2Visibility = value;
                NotifyPropertyChanged(m => m.Logo2Visibility);
            }
        }

        // TODO: Add methods that will be called by the view
        public void LoadLogo1()
        {
            var logo1 = _serviceAgent.LoadLogo1();
            Logo1 = logo1;

            if (Logo1DimChecked)
                CurrentSession.VizEngine.Invoke("SetLogo \"main3d|" + Logo1.Replace(@"\", @"/") + "\"");
            else
                CurrentSession.VizEngine.Invoke("SetLogo \"main2d|" + Logo1.Replace(@"\", @"/") + "\"");
        }

        public void LoadLogo2()
        {
            var logo2 = _serviceAgent.LoadLogo2();
            Logo2 = logo2;

            if (Logo2DimChecked)
                CurrentSession.VizEngine.Invoke("SetLogo \"main3d|" + Logo1.Replace(@"\", @"/") + 
                    "|" + Logo2.Replace(@"\", @"/") + "\"");
            else
                CurrentSession.VizEngine.Invoke("SetLogo \"main2d|" + Logo1.Replace(@"\", @"/") +
                    "|" + Logo2.Replace(@"\", @"/") + "\"");
        }

        public void ChangeFormat()
        {
            if (Logo1Checked)
            {
                Btn1Alignment = HorizontalAlignment.Center;
                Logo1Alignment = HorizontalAlignment.Center;
                Toggle1Alignment = HorizontalAlignment.Center;
                Btn2Visibility = Visibility.Hidden;
                Logo2Visibility = Visibility.Hidden;
                Toggle2Visibility = Visibility.Hidden;
            }
            else if (Logo2Checked)
            {
                Btn1Alignment = HorizontalAlignment.Left;
                Logo1Alignment = HorizontalAlignment.Left;
                Toggle1Alignment = HorizontalAlignment.Left;
                Btn2Visibility = Visibility.Visible;
                Logo2Visibility = Visibility.Visible;
                Toggle2Visibility = Visibility.Visible;
            }
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