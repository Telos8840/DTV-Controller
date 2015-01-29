using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using RCS.DTV.RZC.Properties;

namespace RCS.DTV.RZC.UI
{
    /// <summary>
    /// Interaction logic for IPadWindow.xaml
    /// </summary>
    public partial class IPadWindow
    {
        EventHandler _closeWindow;
        public IPadWindow()
        {
            InitializeComponent();
            _closeWindow += (sender, args) => Close();
        }

        private void CloseIPad(object sender, RoutedEventArgs e)
        {
            AnimateAboutWindow();
            SaveIPad();
        }

        private void SaveIPad()
        {
            Settings.Default.iPadIP = IP.Text;
            Settings.Default.iPadPort = Port.Text;
            Settings.Default.Save();
        }

        private void AnimateAboutWindow()
        {
            var windowOpacity = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(.1))
            };

            windowOpacity.Completed += _closeWindow;

            var heightAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(.1)),
                From = 187,
                To = 0,
                FillBehavior = FillBehavior.HoldEnd
            };

            ResizeMode = ResizeMode.CanResize;
            BeginAnimation(HeightProperty, heightAnimation);
            BeginAnimation(OpacityProperty, windowOpacity);
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
