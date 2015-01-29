using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Elysium.Notifications;
using RCS.DTV.RZC.UI;

namespace RCS.DTV.RZC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Notifications(object sender, RoutedEventArgs e)
        {
            //NotificationManager.Push("Notification", "Testing the notifications");
        }

        private void OpenAboutWindow(object sender, RoutedEventArgs e)
        {
            var windowOpacity = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = new Duration(TimeSpan.FromSeconds(.1))
                };

            var heightAnimation = new DoubleAnimation
                {
                    Duration = new Duration(TimeSpan.FromSeconds(.1)),
                    From = 0,
                    To = 400,
                    FillBehavior = FillBehavior.HoldEnd
                };
            
            var about = new AboutWindow();
            about.ResizeMode = ResizeMode.CanResize;
            about.BeginAnimation(HeightProperty, heightAnimation);
            about.BeginAnimation(OpacityProperty, windowOpacity);
            about.ResizeMode = ResizeMode.NoResize;
            about.ShowDialog();
        }

        private void OpenConfigWindow(object sender, RoutedEventArgs e)
        {
            var windowOpacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(.1))
            };

            var heightAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(.1)),
                From = 0,
                To = 245,
                FillBehavior = FillBehavior.HoldEnd
            };

            var config = new VizConfigWindow();
            config.ResizeMode = ResizeMode.CanResize;
            config.BeginAnimation(HeightProperty, heightAnimation);
            config.BeginAnimation(OpacityProperty, windowOpacity);
            config.ResizeMode = ResizeMode.NoResize;
            config.ShowDialog();
        }


        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void OpenIPadWindow(object sender, RoutedEventArgs e)
        {
            var windowOpacity = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(.1))
            };

            var heightAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(.1)),
                From = 0,
                To = 187,
                FillBehavior = FillBehavior.HoldEnd
            };

            var iPad = new IPadWindow();
            iPad.ResizeMode = ResizeMode.CanResize;
            iPad.BeginAnimation(HeightProperty, heightAnimation);
            iPad.BeginAnimation(OpacityProperty, windowOpacity);
            iPad.ResizeMode = ResizeMode.NoResize;
            iPad.ShowDialog();
        }
    }
}