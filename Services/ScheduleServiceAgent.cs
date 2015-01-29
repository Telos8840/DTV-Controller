using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public class ScheduleServiceAgent : IScheduleServiceAgent
    {
        public void SaveXML()
        {
            throw new NotImplementedException();
        }

        public void SendSchedule(List<Schedule> schedules, int index)
        {
            try
            {
                StringBuilder str = new StringBuilder();

                foreach (var schedule in schedules)
                {
                    str.Append(schedule.Team + ",");

                    for (int i = index; i <= 17; i++)
                    {
                        str.Append(schedule.UpcomingTeam[i-2].Item1);
                        str.Append(schedule.UpcomingTeam[i-2].Item2 + ",");
                    }
                    str.Length -= 1;
                    str.Append("|");
                }

                CurrentSession.VizEngine.Invoke("SetScheduleData \"" + str + "\"");
                //CurrentSession.IPad.Invoke(String.Format("{0}8 {1}{2}", "\r\n", str, "\r\n"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CreateXML()
        {
            XElement root = XDocument.Load("Schedule.xml").Root;
            XElement schedule = XDocument.Load("TeamSchedule.xml").Root;

            var teams = root.Descendants("Team");

            var mathes = root.Descendants("MatchUps");

            string tri, hOa;
            XElement match;
            foreach (var team in teams)
            {
                tri = team.Attribute("abbr").Value;
                schedule.Add(new XElement("Team", new XAttribute("tri", tri)));
                match = schedule.Descendants("Team").FirstOrDefault(a => a.Attribute("tri").Value.Equals(tri));

                hOa = "";
                for (int i = 1; i <= 17; i++) 
                {
                    var homeMatch = (from xml in mathes.Descendants("Match")
                                   where xml.Attribute("week").Value.Equals(i.ToString()) &&
                                   xml.Attribute("homeTeam").Value.Equals(tri)
                                   select xml).FirstOrDefault();

                    var awayMatch = (from xml in mathes.Descendants("Match")
                                   where xml.Attribute("week").Value.Equals(i.ToString()) &&
                                   xml.Attribute("awayTeam").Value.Equals(tri)
                                   select xml).FirstOrDefault();

                    if (homeMatch != null)
                        match.Add(new XElement("Match", new XAttribute("HomeOrAway", "0"), 
                            new XAttribute("tri", homeMatch.Attribute("awayTeam").Value)));
                    else if (awayMatch != null)
                        match.Add(new XElement("Match", new XAttribute("HomeOrAway", "1"),
                            new XAttribute("tri", awayMatch.Attribute("homeTeam").Value)));
                }

                schedule.Save("TeamSchedule.xml");
            }
        }

        public Schedule GetSchedule(CoreTeams selTeam, List<Schedule> schedules)
        {
            return schedules.FirstOrDefault(t => t.Team.Equals(selTeam.Tricode));
        }

        public List<Schedule> SetSchedule()
        {
            List<Schedule> schedule = new List<Schedule>();
            Schedule tempSched = new Schedule();

            try
            {
                XElement root = XDocument.Load("TeamSchedule.xml").Root;
                
                if (root != null)
                {
                    var teams = root.Descendants("Team");

                    foreach (var team in teams)
                    {
                        tempSched.Team = team.Attribute("tri").Value;
                        tempSched.UpcomingTeam = new List<Tuple<int, string>>();
                        var matches = team.Descendants("Match");

                        foreach (var match in matches)
                            tempSched.UpcomingTeam.Add(new Tuple<int, string>(Convert.ToInt32(match.Attribute("HomeOrAway").Value), match.Attribute("tri").Value));

                        schedule.Add(tempSched);
                        tempSched = new Schedule();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return schedule;
        }
    }
}
