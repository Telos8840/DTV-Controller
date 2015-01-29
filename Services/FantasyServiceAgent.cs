using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using RCS.DTV.RZC.Models;
using Elysium.Notifications;

namespace RCS.DTV.RZC.Services
{
    public class FantasyServiceAgent : IFantasyServiceAgent
    {
        string _pic, _name, _path, tri = "";
        Dictionary<int, string> diffTri = new Dictionary<int, string>
            {
                {0, "HST"},
                {1, "BLT"},
                {2, "CLV"},
                {3, "SL"},
                {4, "ARZ"},
                {5, "JAX"}
            };
        Dictionary<int, string> realTri = new Dictionary<int, string>
            {
                {0, "HOU"},
                {1, "BAL"},
                {2, "CLE"},
                {3, "STL"},
                {4, "ARI"},
                {5, "JAC"}
            };

        private Boolean _pathExists = true;
        // NFL GETTY AND ACTION SHOTS\
        public List<TopPassers> LoadPassers()
        {
            List<TopPassers> passers = new List<TopPassers>();
            tri = "";
            try
            {
                using (DtvRedZoneEntities db = new DtvRedZoneEntities())
                {
                    CurrentWeek cw = db.CurrentWeeks.FirstOrDefault();
                    //List<GamePasser> gamePassers = db.GamePassers.Where(g => g.GameKey != null).ToList();
                    List<GetWeekFantasyPassingLeaders_Result> gamePassers = db.GetWeekFantasyPassingLeaders(cw.Season, cw.SeasonType, cw.Week).ToList();

                    for (int i = 0; i < gamePassers.Count && i < 5; i++)
                    {
                        tri = gamePassers[i].Tricode.ToUpper();
                        _pic = String.Format("{0}_{1}_{2}_Action.png", gamePassers[i].Tricode.ToUpper(), gamePassers[i].LastName.ToUpper(),
                                             gamePassers[i].FirstName.ToUpper());

                        foreach (var key in diffTri)
                        {
                            if (tri.Equals(key.Value))
                            {
                                tri = realTri[key.Key];

                                _pic = String.Format("{0}_{1}_{2}_Action.png", tri.ToUpper(), gamePassers[i].LastName.ToUpper(),
                                             gamePassers[i].FirstName.ToUpper());
                            }

                        }
                        
                        _path = String.Format(@"U:\NFL GETTY AND ACTION SHOTS\{0}", _pic);

                        if (!File.Exists(_path))
                        {
                            _pic = String.Format(@"U:\RedZone\Headshots\{0}\{1}_{2}_{3}_B.png", tri, tri, gamePassers[i].LastName.ToUpper(),
                                             gamePassers[i].FirstName.ToUpper());
                        }
                        else
                        {
                            _pic = String.Format(@"U:\NFL GETTY AND ACTION SHOTS\{0}_{1}_{2}_Action.png", tri, gamePassers[i].LastName.ToUpper(),
                                             gamePassers[i].FirstName.ToUpper());
                        }

                        _name = String.Format("{0}, {1}", gamePassers[i].LastName, gamePassers[i].FirstName);

                        passers.Add( new TopPassers
                            {
                                Picture = _pic,
                                Name = _name,
                                Tricode = tri,
                                Position = gamePassers[i].Position,
                                Completions = gamePassers[i].Completions.ToString(),
                                Attempts = gamePassers[i].Attempts.ToString(),
                                Yards = gamePassers[i].Yards.ToString(),
                                Touchdowns = gamePassers[i].Touchdowns.ToString(),
                                Interceptions = gamePassers[i].Interceptions.ToString(),
                                CompletionPCT = gamePassers[i].CompletionPct,
                                Average = gamePassers[i].YardsPerAttempt,
                                Long = gamePassers[i].Long.ToString()
                            });
                    }
                    //passers.AddRange(game.Select(dtvGame => new TopPassers()
                    //    {
                    //        Picture = dtvGame.Channel,
                    //        Name = dtvGame.DtvTricodeAway,
                    //        Position = dtvGame.DtvTricodeHome,
                    //        Stats = dtvGame.GameDate
                    //    }));
                }
            }
            catch (Exception e)
            {
                //NotificationManager.Push("Error", "There was an error reading the database");
                Console.WriteLine(e.ToString());
            }
            return passers;
        }

        public List<TopRushers> LoadRushers()
        {
            tri = "";
            List<TopRushers> rushers = new List<TopRushers>();
            try
            {
                using (DtvRedZoneEntities db = new DtvRedZoneEntities())
                {
                    CurrentWeek cw = db.CurrentWeeks.FirstOrDefault();
                    //List<GameRusher> gameRushers = db.GameRushers.Where(g => g.GameKey != null).ToList();
                    List<GetWeekFantasyRushingLeaders_Result> gameRushers = db.GetWeekFantasyRushingLeaders(cw.Season, cw.SeasonType, cw.Week).ToList();
                    
                    for (int i = 0; i < gameRushers.Count && i < 5; i++)
                    {
                        tri = gameRushers[i].Tricode.ToUpper();
                        _pic = String.Format("{0}_{1}_{2}_Action.png", tri, gameRushers[i].LastName,
                                             gameRushers[i].FirstName);

                        foreach (var key in diffTri)
                        {
                            if (tri.Equals(key.Value))
                            {
                                tri = realTri[key.Key];

                                _pic = String.Format("{0}_{1}_{2}_Action.png", tri, gameRushers[i].LastName,
                                             gameRushers[i].FirstName);
                            }
                        }

                        _path = String.Format(@"U:\NFL GETTY AND ACTION SHOTS\{0}", _pic);

                        if (!File.Exists(_path))
                        {
                            _pic = String.Format(@"U:\RedZone\Headshots\{0}\{1}_{2}_{3}_B.png", tri, tri, gameRushers[i].LastName,
                                             gameRushers[i].FirstName);
                        }
                        else
                        {
                            _pic = String.Format(@"U:\NFL GETTY AND ACTION SHOTS\{0}_{1}_{2}_Action.png", tri, gameRushers[i].LastName,
                                             gameRushers[i].FirstName);
                        }

                        _name = String.Format("{0}, {1}", gameRushers[i].LastName, gameRushers[i].FirstName);

                        rushers.Add(new TopRushers
                        {
                            Picture = _pic,
                            Name = _name,
                            Tricode = tri,
                            Position = gameRushers[i].Position,
                            Attempts = gameRushers[i].Attempts.ToString(),
                            Yards = gameRushers[i].Yards.ToString(),
                            Touchdowns = gameRushers[i].Touchdowns.ToString(),
                            Average = gameRushers[i].Average,
                            Long = gameRushers[i].Long.ToString()
                        });
                    }
                    //rushers.AddRange(game.Select(dtvGame => new TopRushers()
                    //{
                    //    Picture = dtvGame.Channel,
                    //    Name = dtvGame.DtvTricodeAway,
                    //    Position = dtvGame.DtvTricodeHome,
                    //    Stats = dtvGame.GameDate
                    //}));
                }
            }
            catch (Exception e)
            {
                //NotificationManager.Push("Error", "There was an error reading the database");
                Console.WriteLine(e.ToString());
            }
            return rushers;
        }

        public List<TopReceivers> LoadReceivers()
        {
            tri = "";
            List<TopReceivers> receivers = new List<TopReceivers>();
            try
            {
                using (DtvRedZoneEntities db = new DtvRedZoneEntities())
                {
                    CurrentWeek cw = db.CurrentWeeks.FirstOrDefault();
                    //List<GameReceiver> gameReceivers = db.GameReceivers.Where(g => g.GameKey != null).ToList();
                    List<GetWeekFantasyReceivingLeaders_Result> gameReceivers = db.GetWeekFantasyReceivingLeaders(cw.Season, cw.SeasonType, cw.Week).ToList();

                    for (int i = 0; i < gameReceivers.Count && i < 5; i++)
                    {
                        tri = gameReceivers[i].Tricode.ToUpper();
                        _pic = String.Format("{0}_{1}_{2}_Action.png", tri, gameReceivers[i].LastName,
                                         gameReceivers[i].FirstName);

                        foreach (var key in diffTri)
                        {
                            if (tri.Equals(key.Value))
                            {
                                tri = realTri[key.Key];

                                _pic = String.Format("{0}_{1}_{2}_Action.png", tri, gameReceivers[i].LastName,
                                             gameReceivers[i].FirstName);
                            }
                        }

                        _path = String.Format(@"U:\NFL GETTY AND ACTION SHOTS\{0}", _pic);

                        if (!File.Exists(_path))
                        {
                            _pic = String.Format(@"U:\RedZone\Headshots\{0}\{1}_{2}_{3}_B.png", tri, tri, gameReceivers[i].LastName,
                                             gameReceivers[i].FirstName);
                        }
                        else
                        {
                            _pic = String.Format(@"U:\NFL GETTY AND ACTION SHOTS\{0}_{1}_{2}_Action.png", tri, gameReceivers[i].LastName,
                                             gameReceivers[i].FirstName);
                        }

                        _name = String.Format("{0}, {1}", gameReceivers[i].LastName, gameReceivers[i].FirstName);

                        receivers.Add(new TopReceivers
                        {
                            Picture = _pic,
                            Name = _name,
                            Tricode = tri,
                            Position = gameReceivers[i].Position,
                            Receptions = gameReceivers[i].Receptions.ToString(),
                            Yards = gameReceivers[i].Yards.ToString(),
                            Touchdowns = gameReceivers[i].Touchdowns.ToString(),
                            Average = gameReceivers[i].Average,
                            Long = gameReceivers[i].Long.ToString()
                        });
                    }
                    //receivers.AddRange(game.Select(dtvGame => new TopReceivers()
                    //{
                    //    Picture = dtvGame.Channel,
                    //    Name = dtvGame.DtvTricodeAway,
                    //    Position = dtvGame.DtvTricodeHome,
                    //    Stats = dtvGame.GameDate
                    //}));
                }
            }
            catch (Exception e)
            {
                //NotificationManager.Push("Error", "There was an error reading the database");
                Console.WriteLine(e.ToString());
            }
            return receivers;
        }

        public string LoadPicture()
        {
            var dlg = new OpenFileDialog();
            try
            {

                dlg.InitialDirectory = _pathExists ? @"U:\RedZone\" : @"C:\";

                dlg.DefaultExt = ".txt";
                dlg.Filter =
                    "Image Files(*.TGA;*.TIF;*.TIFF;*.JPG;*.JPEG;*.PNG;*.BMP)|*.TGA;*.TIF;*.TIFf;*.JPG;*.JPEG;*.PNG;.BMP|All files (*.*)|*.*";

                var result = dlg.ShowDialog();

                if (result == true)
                    return dlg.FileName;

            }
            catch (Exception)
            {
                Console.WriteLine("\n ERROR: CANNOT FIND FILE DIRECTORY \n");
                _pathExists = false;
                LoadPicture();
            }

            return null;
        }

        public void SetTopPlayers(string PasserPic, string RusherPic, string ReceiverPic, ObservableCollection<TopPassers> topPassers, ObservableCollection<TopRushers> topRushers, ObservableCollection<TopReceivers> topReceivers)
        {
            StringBuilder topPlayers = new StringBuilder();

            try
            {
                for (int i = 0; i < 5; i++ )
                {
                    if (i >= topPassers.Count)
                    {
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("|");
                    }
                    else
                    {
                        topPlayers.Append(topPassers[i].Tricode);
                        topPlayers.Append("~");
                        topPlayers.Append(topPassers[i].Name);
                        topPlayers.Append("~");
                        topPlayers.Append(topPassers[i].Picture.Replace(@"\", "/"));
                        topPlayers.Append("~");
                        topPlayers.Append(topPassers[i].Position);
                        topPlayers.Append("~");
                        topPlayers.Append(String.Format("{0}/{1}", topPassers[i].Completions, topPassers[i].Attempts));
                        topPlayers.Append("~");
                        topPlayers.Append(topPassers[i].Yards);
                        topPlayers.Append("~");
                        topPlayers.Append(topPassers[i].Touchdowns);
                        topPlayers.Append("~");
                        topPlayers.Append(topPassers[i].Interceptions);
                        topPlayers.Append("~");
                        topPlayers.Append(String.Format("{0}%", topPassers[i].CompletionPCT));
                        topPlayers.Append("~");
                        topPlayers.Append(topPassers[i].Average);
                        topPlayers.Append("~");
                        topPlayers.Append(topPassers[i].Long);
                        topPlayers.Append("|");
                    }
                
                }

                for (int i = 0; i < 5; i++)
                {
                    if (i >= topRushers.Count)
                    {
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("|");
                    }
                    else
                    {
                        topPlayers.Append(topRushers[i].Tricode);
                        topPlayers.Append("~");
                        topPlayers.Append(topRushers[i].Name);
                        topPlayers.Append("~");
                        topPlayers.Append(topRushers[i].Picture.Replace(@"\", "/"));
                        topPlayers.Append("~");
                        topPlayers.Append(topRushers[i].Position);
                        topPlayers.Append("~");
                        topPlayers.Append(topRushers[i].Attempts);
                        topPlayers.Append("~");
                        topPlayers.Append(topRushers[i].Yards);
                        topPlayers.Append("~");
                        topPlayers.Append(topRushers[i].Touchdowns);
                        topPlayers.Append("~");
                        topPlayers.Append(topRushers[i].Average);
                        topPlayers.Append("~");
                        topPlayers.Append(topRushers[i].Long);
                        topPlayers.Append("|");
                    }
                
                }

                for (int i = 0; i < 5; i++)
                {
                    if (i >= topReceivers.Count)
                    {
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("~");
                        topPlayers.Append("");
                        topPlayers.Append("|");
                    }
                    else
                    {
                        topPlayers.Append(topReceivers[i].Tricode);
                        topPlayers.Append("~");
                        topPlayers.Append(topReceivers[i].Name);
                        topPlayers.Append("~");
                        topPlayers.Append(topReceivers[i].Picture.Replace(@"\", "/"));
                        topPlayers.Append("~");
                        topPlayers.Append(topReceivers[i].Position);
                        topPlayers.Append("~");
                        topPlayers.Append(topReceivers[i].Receptions);
                        topPlayers.Append("~");
                        topPlayers.Append(topReceivers[i].Yards);
                        topPlayers.Append("~");
                        topPlayers.Append(topReceivers[i].Touchdowns);
                        topPlayers.Append("~");
                        topPlayers.Append(topReceivers[i].Average);
                        topPlayers.Append("~");
                        topPlayers.Append(topReceivers[i].Long);
                        topPlayers.Append("|");
                    }
                
                }

                //if (PasserPic != null && !PasserPic.Equals(topPassers[0].Picture))
                //{
                //    Console.WriteLine("asdf");
                //}
                //if (RusherPic.Equals(topRushers[0].Picture))
                //{
                //    Console.WriteLine();
                //}
                //if (ReceiverPic.Equals(topReceivers[0].Picture))
                //{
                //    Console.WriteLine();
                //}

                CurrentSession.VizEngine.Invoke("SetFantasyData \"" + topPlayers + "\"");
                CurrentSession.IPad.Invoke(String.Format("{0}8 {1}{2}","\r\n", topPlayers, "\r\n"));


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

//add a blank field on top of live video input