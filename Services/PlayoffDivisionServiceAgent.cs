using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public class PlayoffDivisionServiceAgent : IPlayoffDivisionServiceAgent
    {
        public string GetTeamData(string triCode)
        {
            PlayoffTeam team = new PlayoffTeam();

            try
            {
                using (DtvRedZoneEntities db = new DtvRedZoneEntities())
                {
                    var t = db.Teams.Where(n => n.DtvTricode.Equals(triCode));
                    foreach (var team1 in t)
                    {
                        team.TriCode = team1.DtvTricode;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return team.TriCode;
        }

        public void SetPlayoffDivisionData(string type, ObservableCollection<PlayoffTeam> team)
        {
            StringBuilder str = new StringBuilder();

            foreach (var t in team)
            {
                if (t.TriCode != null && !t.TriCode.Equals(""))
                {
                    str.Append(t.TriCode);
                    str.Append(",");
                    str.Append(t.Tag);
                    str.Append(",");
                    str.Append(t.Record);
                    str.Append("|");
                }
            }

            CurrentSession.VizEngine.Invoke("SetPlayoffData \"" + type + "\" \"" + str + "\"");
            //CurrentSession.IPad.Invoke(String.Format("{0}6 {1}{2}", "\r\n", str, "\r\n"));
        }
    }
}
