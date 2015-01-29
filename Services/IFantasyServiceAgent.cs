using System.Collections.Generic;
using System.Collections.ObjectModel;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public interface IFantasyServiceAgent
    {
        List<TopPassers> LoadPassers();
        List<TopRushers> LoadRushers();
        List<TopReceivers> LoadReceivers();
        string LoadPicture();
        void SetTopPlayers(string PasserPic, string RusherPic, string ReceiverPic, ObservableCollection<TopPassers> topPassers, ObservableCollection<TopRushers> topRushers, ObservableCollection<TopReceivers> topReceivers);
    }
}