using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    public class Playoff : ModelBase<Playoff>
    {
        private string _awayTeam;

        public string AwayTeam
        {
            get { return _awayTeam; }
            set
            {
                if (_awayTeam == value)
                    return;
                _awayTeam = value;
                NotifyPropertyChanged(m => m.AwayTeam);
            }
        }

        private string _homeTeam;

        public string HomeTeam
        {
            get { return _homeTeam; }
            set
            {
                if (_homeTeam == value)
                    return;
                _homeTeam = value;
                NotifyPropertyChanged(m => m.HomeTeam);
            }
        }
    }
}