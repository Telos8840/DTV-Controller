using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using RCS.DTV.RZC.Helpers;
using RCS.DTV.RZC.Services;
using RCS.DTV.RZC.ViewModels;

namespace RCS.DTV.RZC.Models
{
    public static class CurrentSession
    {
        private static Config _config;

        public static Config Config
        {
            get { return _config; }
            set
            {
                if (_config == value)
                    return;
                _config = value;
            }
        }

        private static VizEngine _vizEngine;

        public static VizEngine VizEngine
        {
            get { return _vizEngine; }
            set
            {
                if (_vizEngine == value)
                    return;
                _vizEngine = value;
            }
        }

        private static iPad _iPad;

        public static iPad IPad
        {
            get { return _iPad; }
            set
            {
                if (_iPad == value)
                    return;
                _iPad = value;
            }
        }

        private static string _localIp;

        public static string LocalIp
        {
            get
            {
                if (_localIp == null)
                    _localIp = GetLocalIp();
                return _localIp;
            }
            set
            {
                if (_localIp == value)
                    return;
                _localIp = value;
            }
        }

        private static List<CoreTeams> _teams;

        public static List<CoreTeams> Teams
        {
            get { return _teams; }
            set
            {
                if (_teams == value)
                    return;
                _teams = value;
            }
        }

        public static string GetLocalIp()
        {
            string sHostName = Dns.GetHostName();
            IPHostEntry ipE = Dns.GetHostByName(sHostName);
            IPAddress[] IpA = ipE.AddressList;
            return IpA.Count() > 0 ? IpA[0].ToString() : "";
        }

        public static string ConnectionString()
        {
#if DEBUG
            return @"Server=10.10.2.30;Database=DtvRedZone;Uid=sa;Pwd=rcg;";
#else
			return @"Server=172.31.66.20;Database=DtvRedZone;Uid=sa;Pwd=rcs;";
#endif
        }

        public static List<CoreTeams> GetTeams()
        {
            List<CoreTeams> teams = new List<CoreTeams>();
            try
            {
                using (DtvRedZoneEntities db = new DtvRedZoneEntities())
                {
                    List<Team> team = db.Teams.Where(t => t.TeamName != null).OrderBy(n => n.TeamName).ToList();
                    List<GameLocation> location = db.GameLocations.Where(g => g.Location != null).OrderBy(n => n.Tri).ToList();
                    teams.Add(new CoreTeams
                    {
                        Tricode = "",
                        Name = "",
                        City = "",
                        Conference = "",
                        Division = "",
                        Stadium = ""
                    });

                    teams.AddRange(team.Select(t => new CoreTeams
                    {
                        Tricode = t.DtvTricode,
                        Name = t.TeamName,
                        City = t.City,
                        Conference = t.Conference,
                        Division = t.Division,
                    }));

                    foreach (var t in teams)
                    {
                        t.Stadium = location.Where(l => l.Tri.Equals(t.Tricode)).Select(s => s.Stadium).FirstOrDefault();
                    }
                }

            }
            catch (Exception e)
            {
                //NotificationManager.Push("Error", "There was an error reading the database");
                Console.WriteLine(e);
            }

            return teams;
        }
    }
}
