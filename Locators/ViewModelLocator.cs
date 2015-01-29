/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:delete"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

// Toolkit namespace

using RCS.DTV.RZC.Models;
using RCS.DTV.RZC.Services;
using RCS.DTV.RZC.ViewModels;

namespace RCS.DTV.RZC
{
    /// <summary>
    /// This class creates ViewModels on demand for Views, supplying a
    /// ServiceAgent to the ViewModel if required.
    /// <para>
    /// Place the ViewModelLocator in the App.xaml resources:
    /// </para>
    /// <code>
    /// &lt;Application.Resources&gt;
    ///     &lt;vm:ViewModelLocator xmlns:vm="clr-namespace:delete"
    ///                                  x:Key="Locator" /&gt;
    /// &lt;/Application.Resources&gt;
    /// </code>
    /// <para>
    /// Then use:
    /// </para>
    /// <code>
    /// DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
    /// </code>
    /// <para>
    /// Use the <strong>mvvmlocator</strong> or <strong>mvvmlocatornosa</strong>
    /// code snippets to add ViewModels to this locator.
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        // Create MainPageViewModel on demand
        public MainPageViewModel MainPageViewModel
        {
            get { return new MainPageViewModel(); }
        }

        // Create ConfigViewModel on demand
        public ConfigViewModel ConfigViewModel
        {
            get
            {
                IConfigServiceAgent configServiceAgent = new ConfigServiceAgent();
                return new ConfigViewModel(configServiceAgent);
            }
        }

        // Create FantasyViewModel on demand
        public FantasyViewModel FantasyViewModel
        {
            get
            {
                IFantasyServiceAgent fantasyServiceAgent = new FantasyServiceAgent();
                return new FantasyViewModel(fantasyServiceAgent);
            }
        }

        // Create MainLogoViewModel on demand
        public MainLogoViewModel MainLogoViewModel
        {
            get
            {
                IMainLogoServiceAgent mainLogoServiceAgent = new MainLogoServiceAgent();
                return new MainLogoViewModel(mainLogoServiceAgent);
            }
        }

        // Create SponsorLogoViewModel on demand
        public SponsorLogoViewModel SponsorLogoViewModel
        {
            get
            {
                ISponsorLogoServiceAgent sponsorLogoServiceAgent = new SponsorLogoServiceAgent();
                return new SponsorLogoViewModel(sponsorLogoServiceAgent);
            }
        }

        // Create PlayoffViewModel on demand
        public PlayoffViewModel PlayoffViewModel
        {
            get
            {
                IPlayoffServiceAgent playoffServiceAgent = new PlayoffServiceAgent();
                return new PlayoffViewModel(playoffServiceAgent);
            }
        }

        // Create SponsorPickViewModel on demand
        public SponsorPickViewModel SponsorPickViewModel
        {
            get
            {
                ISponsorPickServiceAgent sponsorPickServiceAgent = new SponsorPickServiceAgent();
                return new SponsorPickViewModel(sponsorPickServiceAgent);
            }
        }

        // Create AfcDivisionViewModel on demand
        public AfcDivisionViewModel AfcDivisionViewModel
        {
            get
            {
                IPlayoffDivisionServiceAgent playoffDivisionServiceAgent = new PlayoffDivisionServiceAgent();
                return new AfcDivisionViewModel(playoffDivisionServiceAgent);
            }
        }

        // Create NfcDivisionViewModel on demand
        public NfcDivisionViewModel NfcDivisionViewModel
        {
            get
            {
                IPlayoffDivisionServiceAgent playoffDivisionServiceAgent = new PlayoffDivisionServiceAgent();
                return new NfcDivisionViewModel(playoffDivisionServiceAgent);
            }
        }

        // Create LiveVideoViewModel on demand
        public LiveVideoViewModel LiveVideoViewModel
        {
            get
            {
                ILiveVideoServiceAgent liveVideoServiceAgent = new LiveVideoServiceAgent();
                return new LiveVideoViewModel(liveVideoServiceAgent);
            }
        }

        // Create MapViewModel on demand
        public MapViewModel MapViewModel
        {
            get
            {
                IMapServiceAgent mapServiceAgent = new MapServiceAgent();
                return new MapViewModel(mapServiceAgent);
            }
        }

        // Create IPadViewModel on demand
        public IPadViewModel IPadViewModel
        {
            get
            {
                IiPadServiceAgent iPadServiceAgent = new iPadServiceAgent();
                return new IPadViewModel(iPadServiceAgent);
            }
        }

        // Create ReplayViewModel on demand
        public ReplayViewModel ReplayViewModel
        {
            get
            {
                IReplayServiceAgent replayServiceAgent = new ReplayServiceAgent();
                return new ReplayViewModel(replayServiceAgent);
            }
        }

        // Create InjuryViewModel on demand
        public InjuryViewModel InjuryViewModel
        {
            get
            {
                IInjuryServiceAgent injuryServiceAgent = new InjuryServiceAgent();
                return new InjuryViewModel(injuryServiceAgent);
            }
        }

        // Create ScheduleViewModel on demand
        public ScheduleViewModel ScheduleViewModel
        {
            get
            {
                IScheduleServiceAgent scheduleServiceAgent = new ScheduleServiceAgent();
                return new ScheduleViewModel(scheduleServiceAgent);
            }
        }
    }
}