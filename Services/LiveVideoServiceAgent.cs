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
    public class LiveVideoServiceAgent : ILiveVideoServiceAgent
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
                //NotificationManager.Push("Error", "File cannot be found");
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
            Team tempAway = null, tempHome = null, realAway = null, realHome = null;
            Dictionary<int, string> teams = new Dictionary<int, string>();
            string tempTeam = "";

            for (int i = 0; i < selectedInput.Count; i++)
            {
                if (groupNum != null)
                {
                    if (selectedInput[i] != null)
                    {
                        if (selectedInput[i].EndsWith(groupNum))
                        {
                            using (DtvRedZoneEntities db = new DtvRedZoneEntities())
                            {
                                List<Team> AllTeams = db.Teams.Where(t => t.TeamName != null).OrderBy(n => n.TeamName).ToList();
                                foreach (var team in AllTeams)
                                {
                                    if (team.DtvTricode.Equals(away[i].Tricode))
                                        tempAway = team;
                                    if (team.DtvTricode.Equals(home[i].Tricode))
                                        tempHome = team;
                                }

                                if (tempHome != null && !tempHome.TeamName.Equals(home[i].Name.Trim()))
                                {
                                    realHome = AllTeams.FirstOrDefault(n => n.TeamName.Equals(home[i].Name.Trim()));

                                    //teamStr.Append(realHome.DtvTricode);
                                    //teamStr.Append(",");
                                    tempTeam += realHome.DtvTricode;
                                    tempTeam += ",";
                                }
                                else
                                {
                                    //teamStr.Append(home[i].Tricode);
                                    //teamStr.Append(",");
                                    tempTeam += home[i].Tricode;
                                    tempTeam += ",";
                                }

                                if (tempAway != null && !tempAway.TeamName.Equals(away[i].Name.Trim()))
                                {
                                    realAway = AllTeams.FirstOrDefault(n => n.TeamName.Equals(away[i].Name.Trim()));

                                    //teamStr.Append(realAway.DtvTricode);
                                    tempTeam += realAway.DtvTricode;
                                }
                                else
                                {
                                    //teamStr.Append(away[i].Tricode);
                                    tempTeam += away[i].Tricode;
                                }
                            }

                            //teamStr.Append("|");
                            tempTeam += "|";
                            teams.Add(int.Parse(selectedInput[i][0].ToString()), tempTeam);
                            tempTeam = "";
                        }
                    }
                }
            }

            var sortedDict = (from entry in teams orderby entry.Key ascending select entry).ToDictionary(k => k.Key, v => v.Value);

            foreach (var pair in sortedDict)
                teamStr.Append(pair.Value);
            
            CurrentSession.VizEngine.Invoke("SetVideoData \"" + String.Format("{0}|{1}", weekNumber, teamStr) + "\"");
            CurrentSession.IPad.Invoke(String.Format("{0}4 {1}|{2}{3}", "\r\n", weekNumber, teamStr, "\r\n"));
        }
    }
}