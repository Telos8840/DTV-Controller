using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Elysium;
using RCS.DTV.RZC.Helpers;
using RCS.DTV.RZC.Models;
using RCS.DTV.RZC.Properties;

namespace RCS.DTV.RZC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public VizEngine VizPgm { get; set; }
        public Config TheConfig { get; set; }
        public iPad iPad { get; set; }
        private MainWindow mainWindow { get; set; }
        private FeedbackCoordinator _feedback;
        private const int MINIMUM_SPLASH_TIME = 2000;
        private const int SPLASH_FADE_TIME = 850;

        private void StartupHandler(object sender, StartupEventArgs e)
        {
            this.Apply(Theme.Dark, AccentBrushes.Red, Brushes.White);

            SplashScreen splash = new SplashScreen("Assets/rzc-splash.png");
            splash.Show(false, true);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            timer.Stop();
            int remainingTimeToShowSplash = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
            if (remainingTimeToShowSplash > 0)
                Thread.Sleep(remainingTimeToShowSplash);

            splash.Close(TimeSpan.FromMilliseconds(SPLASH_FADE_TIME));

            PrepareForTheShow();
        }

        /// <summary>
        /// It creates all the necessary object for the model to be loaded
        /// </summary>
        private void PrepareForTheShow()
        {
            TheConfig = new Config(Settings.Default.ServerIp, Settings.Default.ServerPort, Settings.Default.ScenePath, Settings.Default.FeedbackPort);
            iPad = new iPad(Settings.Default.iPadIP, Settings.Default.iPadPort);
            VizPgm = new VizEngine(TheConfig.EngineIp, TheConfig.EnginePort);
            CurrentSession.Config = TheConfig;
            CurrentSession.VizEngine = VizPgm;
            CurrentSession.IPad = iPad;
            CurrentSession.Teams = CurrentSession.GetTeams();
            _feedback = new FeedbackCoordinator(TheConfig);
            mainWindow = new MainWindow();
            mainWindow.Show();
        }

        public void Application_Exit(object sender, ExitEventArgs e)
        {
            _feedback.StopListening();
            Settings.Default.Save();
            VizPgm.DisconnectFromEngine();
            iPad.DisconnectFromiPad();
            Console.WriteLine(@"ENGINE DISCONNECTED");
        }
    }
}
