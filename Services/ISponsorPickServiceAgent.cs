using System.Collections.Generic;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public interface ISponsorPickServiceAgent
    {
        AwaySponsorPick LoadAwayTeam(string name);
        string LoadAwayLogo();
        HomeSponsorPick LoadHomeTeam(string name);
        string LoadHomeLogo();
        void SetSponsorPicks(AwaySponsorPick awaySponsorPick, HomeSponsorPick homeSponsorPicks);
    }
}
