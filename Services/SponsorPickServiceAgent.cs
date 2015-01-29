using System;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using RCS.DTV.RZC.Models;

namespace RCS.DTV.RZC.Services
{
    public class SponsorPickServiceAgent : ISponsorPickServiceAgent
    {
        private Boolean _pathExists = true;

        public AwaySponsorPick LoadAwayTeam(string name)
        {
            AwaySponsorPick awaySponsorPick = new AwaySponsorPick();

            try
            {
                using (DtvRedZoneEntities db = new DtvRedZoneEntities())
                {
                    var team = db.Teams.Where(t => t.TeamName.Equals(name));
                    foreach (var t in team)
                    {
                        awaySponsorPick.CityName = t.City;
                        awaySponsorPick.TeamLogo = t.DtvTricode;
                        awaySponsorPick.TeamName = t.TeamName;
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return awaySponsorPick;
        }

        public string LoadAwayLogo()
        {
            var dlg = new OpenFileDialog();
            try
            {

                dlg.InitialDirectory = _pathExists ? @"C:\Users\s.guardado\Pictures" : @"C:\";

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
                LoadAwayLogo();
            }

            return null;

        }

        public HomeSponsorPick LoadHomeTeam(string name)
        {
            HomeSponsorPick homeSponsorPick = new HomeSponsorPick();

            try
            {
                using (DtvRedZoneEntities db = new DtvRedZoneEntities())
                {
                    var team = db.Teams.Where(t => t.TeamName == name);
                    foreach (var t in team)
                    {
                        homeSponsorPick.CityName = t.City;
                        homeSponsorPick.TeamLogo = t.DtvTricode;
                        homeSponsorPick.TeamName = t.TeamName;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return homeSponsorPick;
        }

        public string LoadHomeLogo()
        {
            var dlg = new OpenFileDialog();
            try
            {

                dlg.InitialDirectory = _pathExists ? @"C:\Users\s.guardado\Pictures" : @"C:\";

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
                LoadAwayLogo();
            }

            return null;
            //return @"/Assets/LogoPlaceholder.png";
        }

        public void SetSponsorPicks(AwaySponsorPick awaySponsorPick, HomeSponsorPick homeSponsorPicks)
        {
            StringBuilder str = new StringBuilder();

            str.Append(awaySponsorPick.TeamLogo);
            str.Append("~");
            str.Append(awaySponsorPick.CityName);
            str.Append("~");
            str.Append(awaySponsorPick.TeamName);
            str.Append("~");
            str.Append(awaySponsorPick.Record);
            str.Append("|");
            str.Append(homeSponsorPicks.TeamLogo);
            str.Append("~");
            str.Append(homeSponsorPicks.CityName);
            str.Append("~");
            str.Append(homeSponsorPicks.TeamName);
            str.Append("~");
            str.Append(homeSponsorPicks.Record);

            Console.WriteLine(str);
        }

    }
}
