using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    public class SponsorPicks : ModelBase<SponsorPicks>
    {
        private AwaySponsorPick _awaySponsorPick;

        public AwaySponsorPick AwaySponsorPick
        {
            get { return _awaySponsorPick; }
            set
            {
                if (_awaySponsorPick == value)
                    return;
                _awaySponsorPick = value;
                NotifyPropertyChanged(m => m.AwaySponsorPick);
            }
        }

        private string _vsAt;

        public string VsAt
        {
            get { return _vsAt; }
            set
            {
                if (_vsAt == value)
                    return;
                _vsAt = value;
                NotifyPropertyChanged(m => m.VsAt);
            }
        }

        private HomeSponsorPick _homeSponsorPick;

        public HomeSponsorPick HomeSponsorPick
        {
            get { return _homeSponsorPick; }
            set
            {
                if (_homeSponsorPick == value)
                    return;
                _homeSponsorPick = value;
                NotifyPropertyChanged(m => m.HomeSponsorPick);
            }
        }
    }

    public class AwaySponsorPick : ModelBase<AwaySponsorPick>
    {
        private string _teamLogo;

        public string TeamLogo
        {
            get { return _teamLogo; }
            set
            {
                if (_teamLogo == value)
                    return;
                _teamLogo = value;
                NotifyPropertyChanged(m => m.TeamLogo);
            }
        }

        private string _playerLogo;

        public string PlayerLogo
        {
            get { return _playerLogo; }
            set
            {
                if (_playerLogo == value)
                    return;
                _playerLogo = value;
                NotifyPropertyChanged(m => m.PlayerLogo);
            }
        }

        private string _playerName;

        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                if (_playerName == value)
                    return;
                _playerName = value;
                NotifyPropertyChanged(m => m.PlayerName);
            }
        }

        private string _position;

        public string Position
        {
            get { return _position; }
            set
            {
                if (_position == value)
                    return;
                _position = value;
                NotifyPropertyChanged(m => m.Position);
            }
        }

        private string _stat;

        public string Stat
        {
            get { return _stat; }
            set
            {
                if (_stat == value)
                    return;
                _stat = value;
                NotifyPropertyChanged(m => m.Stat);
            }
        }

        private string _cityName;

        public string CityName
        {
            get { return _cityName; }
            set
            {
                if (_cityName == value)
                    return;
                _cityName = value;
                NotifyPropertyChanged(m => m.CityName);
            }
        }

        private string _teamName;

        public string TeamName
        {
            get { return _teamName; }
            set
            {
                if (_teamName == value)
                    return;
                _teamName = value;
                NotifyPropertyChanged(m => m.TeamName);
            }
        }

        private string _record;

        public string Record
        {
            get { return _record; }
            set
            {
                if (_record == value)
                    return;
                _record = value;
                NotifyPropertyChanged(m => m.Record);
            }
        }
    }

    public class HomeSponsorPick : ModelBase<HomeSponsorPick>
    {
        private string _teamLogo;

        public string TeamLogo
        {
            get { return _teamLogo; }
            set
            {
                if (_teamLogo == value)
                    return;
                _teamLogo = value;
                NotifyPropertyChanged(m => m.TeamLogo);
            }
        }

        private string _playerLogo;

        public string PlayerLogo
        {
            get { return _playerLogo; }
            set
            {
                if (_playerLogo == value)
                    return;
                _playerLogo = value;
                NotifyPropertyChanged(m => m.PlayerLogo);
            }
        }

        private string _playerName;

        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                if (_playerName == value)
                    return;
                _playerName = value;
                NotifyPropertyChanged(m => m.PlayerName);
            }
        }

        private string _position;

        public string Position
        {
            get { return _position; }
            set
            {
                if (_position == value)
                    return;
                _position = value;
                NotifyPropertyChanged(m => m.Position);
            }
        }

        private string _stat;

        public string Stat
        {
            get { return _stat; }
            set
            {
                if (_stat == value)
                    return;
                _stat = value;
                NotifyPropertyChanged(m => m.Stat);
            }
        }

        private string _cityName;

        public string CityName
        {
            get { return _cityName; }
            set
            {
                if (_cityName == value)
                    return;
                _cityName = value;
                NotifyPropertyChanged(m => m.CityName);
            }
        }

        private string _teamName;

        public string TeamName
        {
            get { return _teamName; }
            set
            {
                if (_teamName == value)
                    return;
                _teamName = value;
                NotifyPropertyChanged(m => m.TeamName);
            }
        }

        private string _record;

        public string Record
        {
            get { return _record; }
            set
            {
                if (_record == value)
                    return;
                _record = value;
                NotifyPropertyChanged(m => m.Record);
            }
        }
    }

    public class SponsorTeam : ModelBase<SponsorTeam>
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                NotifyPropertyChanged(m => m.Name);
            }
        }
    }
}