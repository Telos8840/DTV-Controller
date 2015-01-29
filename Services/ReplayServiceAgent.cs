using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Elysium.Notifications;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public class ReplayServiceAgent : IReplayServiceAgent
    {
        public ObservableCollection<CoreTeams> GetSelecetedAwayTeams(string number)
        {
            ObservableCollection<CoreTeams> awayTeams = new ObservableCollection<CoreTeams>();
            try
            {
                XElement root = XDocument.Load("Schedule.xml").Root;

                IEnumerable<XElement> teams = root.Descendants("MatchUps");

                var team = (from xml in teams.Descendants("Match")
                            where xml.Attribute("week").Value.Equals(number)
                            select xml);

                foreach (CoreTeams away in team.
                    Select(t => CurrentSession.Teams.
                        FirstOrDefault(a => a.Tricode.Equals(t.Attribute("awayTeam").Value))))
                {
                    awayTeams.Add(away);
                }

                return awayTeams;
            }
            catch (Exception e)
            {
               // NotificationManager.Push("Error", "File cannot be found");
                Console.WriteLine(e);
            }

            return awayTeams;
        }

        public ObservableCollection<CoreTeams> GetSelectedHomeTeams(string number)
        {
            ObservableCollection<CoreTeams> homeTeams = new ObservableCollection<CoreTeams>();
            try
            {
                XElement root = XDocument.Load("Schedule.xml").Root;

                IEnumerable<XElement> teams = root.Descendants("MatchUps");

                var team = (from xml in teams.Descendants("Match")
                            where xml.Attribute("week").Value.Equals(number)
                            select xml);

                foreach (CoreTeams away in team.
                    Select(t => CurrentSession.Teams.
                        FirstOrDefault(a => a.Tricode.Equals(t.Attribute("homeTeam").Value))))
                {
                    homeTeams.Add(away);
                }

                return homeTeams;
            }
            catch (Exception e)
            {
                //NotificationManager.Push("Error", "File cannot be found");
                Console.WriteLine(e);
            }

            return homeTeams;
        }

        public void SetLiveVideos(string groupNum, string weekNumber, ObservableCollection<string> selectedInput, ObservableCollection<CoreTeams> home,
                                  ObservableCollection<CoreTeams> away)
        {
            StringBuilder teamStr = new StringBuilder();
            for (int i = 0; i < selectedInput.Count; i++)
            {
                if (groupNum != null)
                {
                    if (selectedInput[i] != null)
                    {
                        if (selectedInput[i].EndsWith(groupNum))
                        {
                            teamStr.Append(home[i].Tricode);
                            teamStr.Append(",");
                            teamStr.Append(away[i].Tricode);
                            teamStr.Append("|");
                        }
                    }
                }
            }

            CurrentSession.VizEngine.Invoke("SetVideoData \"" + "1" + "\" \"" + String.Format("{0}|{1}", weekNumber, teamStr) + "\"");
            CurrentSession.IPad.Invoke(String.Format("{0}5 {1}|{2}{3}", "\r\n", weekNumber, teamStr, "\r\n"));
        }
    }
}
