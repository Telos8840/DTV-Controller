using System.Collections.ObjectModel;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public interface IPlayoffDivisionServiceAgent
    {
        string GetTeamData(string triCode);
        void SetPlayoffDivisionData(string type, ObservableCollection<PlayoffTeam> team);
    }
}