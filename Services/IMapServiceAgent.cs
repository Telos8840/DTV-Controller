using System.Collections.ObjectModel;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public interface IMapServiceAgent
    {
        ObservableCollection<CoreTeams> GetSelecetedAwayTeams(string number);
        ObservableCollection<CoreTeams> GetSelectedHomeTeams(string number);
        string SetMap(CoreTeams selectedAwayTeams, CoreTeams selectedHomeTeams, string weatherId, string desc, string temp, string input);
    }
}
