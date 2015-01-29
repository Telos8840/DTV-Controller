
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public class InjuryServiceAgent : IInjuryServiceAgent
    {
        public Injuries GetTeamData(string tricode)
        {
            Injuries injured = new Injuries();

            try
            {
                using (DtvRedZoneEntities db = new DtvRedZoneEntities())
                {
                    var t = db.Teams.Where(n => n.DtvTricode.Equals(tricode));
                    foreach (var team1 in t)
                    {
                        injured.Logo = team1.DtvTricode;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return injured;
        }

        public void SetInjuredPlayers(ObservableCollection<Injuries> injuries)
        {
            StringBuilder str = new StringBuilder();
            foreach (var injury in injuries)
            {
                if (injury != null && injury.Logo != null)
                {
                    str.Append(injury.Logo);
                    str.Append(",");
                    str.Append(injury.Position);
                    str.Append(",");
                    str.Append(injury.Name);
                    str.Append(",");
                    str.Append(injury.Injury);
                    str.Append("|");
                }
            }

            CurrentSession.VizEngine.Invoke("SetInjuryData \"" + str + "\"");
            CurrentSession.IPad.Invoke(String.Format("{0}5 {1}{2}", "\r\n", str, "\r\n"));
        }
    }
}
