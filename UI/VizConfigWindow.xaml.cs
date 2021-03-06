﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using RCS.DTV.RZC.Properties;

namespace RCS.DTV.RZC.UI
{
    /// <summary>
    /// Interaction logic for VizConfigWindow.xaml
    /// </summary>
    public partial class VizConfigWindow
    {
        EventHandler _closeWindow;
        public VizConfigWindow()
        {
            InitializeComponent();
            _closeWindow += (sender, args) => Close();
        }

        private void CloseConfig(object sender, RoutedEventArgs e)
        {
            AnimateConfigWindow();
            SaveConfig();
        }

        private void SaveConfig()
        {
            Settings.Default.ServerIp = IP.Text;
            Settings.Default.ServerPort = int.Parse(pPort.Text);
            Settings.Default.ScenePath = Scene.Text;
            Settings.Default.FeedbackPort = int.Parse(fPort.Text);
            Settings.Default.Save();
        }

        private void AnimateConfigWindow()
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
                From = 245,
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
