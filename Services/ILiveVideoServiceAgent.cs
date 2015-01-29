using System.Collections.ObjectModel;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public interface ILiveVideoServiceAgent
    {
        ObservableCollection<CoreTeams> GetSelecetedAwayTeams(string number);
        ObservableCollection<CoreTeams> GetSelectedHomeTeams(string number);
        void SetLiveVideos(string groupNum, string weekNumber, ObservableCollection<string> selectedInput, ObservableCollection<CoreTeams> home, ObservableCollection<CoreTeams> away);
    }
}
