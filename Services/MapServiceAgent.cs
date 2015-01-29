using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using Elysium.Notifications;
using RCS.DTV.RZC.Models;
using MessageBox = System.Windows.MessageBox;

namespace RCS.DTV.RZC.Services
{
    public class MapServiceAgent : IMapServiceAgent
    {
        private MessageBoxResult box;
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

                if (root != null)
                {
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

        public string SetMap(CoreTeams selectedAwayTeams, CoreTeams selectedHomeTeams, string weatherId, string desc, string temp, string input)
        {
            StringBuilder mapString = new StringBuilder();
            Team tempAway = null, tempHome = null, realAway = null, realHome = null;
            try
            {
                if (!selectedAwayTeams.Tricode.Equals("") && !selectedHomeTeams.Tricode.Equals(""))
                {
                    using (DtvRedZoneEntities db = new DtvRedZoneEntities())
                    {
                        List<Team> AllTeams = db.Teams.Where(t => t.TeamName != null).OrderBy(n => n.TeamName).ToList();
                        foreach (var team in AllTeams)
                        {
                            if (team.DtvTricode.Equals(selectedAwayTeams.Tricode))
                                tempAway = team;
                            if (team.DtvTricode.Equals(selectedHomeTeams.Tricode))
                                tempHome = team;
                        }

                        if (tempHome != null && !tempHome.TeamName.Equals(selectedHomeTeams.Name.Trim()))
                        {
                            realHome = AllTeams.FirstOrDefault(n => n.TeamName.Equals(selectedHomeTeams.Name.Trim()));

                            if (realHome != null)
                            {
                                mapString.Append(realHome.DtvTricode);
                                mapString.Append(",");
                            }
                            else
                            {
                                box = MessageBox.Show(String.Format("{0} has been spelled wrong.", selectedHomeTeams.Name), "Misspelled Team Name", MessageBoxButton.OK);
                                mapString.Append("");
                                mapString.Append(",");
                            }
                        }
                        else
                        {
                            mapString.Append(selectedHomeTeams.Tricode);
                            mapString.Append(",");
                        }

                        if (tempAway != null && !tempAway.TeamName.Equals(selectedAwayTeams.Name.Trim()))
                        {
                            realAway = AllTeams.FirstOrDefault(n => n.TeamName.Equals(selectedAwayTeams.Name.Trim()));

                            if (realAway != null)
                            {
                                mapString.Append(realAway.DtvTricode);
                                mapString.Append(",");
                            }
                            else
                            {
                                box = MessageBox.Show(String.Format("{0} has been spelled wrong.", selectedAwayTeams.Name), "Misspelled Team Name", MessageBoxButton.OK);
                                mapString.Append("");
                                mapString.Append(",");
                            }
                        }
                        else
                        {
                            mapString.Append(selectedAwayTeams.Tricode);
                            mapString.Append(",");
                        }
                    }

                    mapString.Append(weatherId.Equals("0") ? "" : weatherId);
                    mapString.Append(",");
                    mapString.Append(desc);
                    mapString.Append(",");
                    mapString.Append(temp);
                    mapString.Append(",");
                    mapString.Append(selectedHomeTeams.Stadium);

                    if (input != null && !input.Equals(""))
                    {
                        string[] inputs = input.Split('-');
                        mapString.Append(",");
                        mapString.Append(inputs[0]);
                        mapString.Append(",");
                        mapString.Append(inputs[1].Equals("EARLY") ? "0" : "1");
                    }
                    else
                    {
                        mapString.Append(",");
                        mapString.Append("0");
                        mapString.Append(",");
                        mapString.Append("0");
                    }

                    mapString.Append("|");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return mapString.ToString();
        }
    }
}
