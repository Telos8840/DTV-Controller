using System.Collections.ObjectModel;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public interface IInjuryServiceAgent
    {
        void SetInjuredPlayers(ObservableCollection<Injuries> injuries);
        Injuries GetTeamData(string tricode);
    }
}
