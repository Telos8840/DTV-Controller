using System;
using System.Collections.ObjectModel;
using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    public class Map : ModelBase<Map>
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

        private string _stadium;

        public string Stadium
        {
            get { return _stadium; }
            set
            {
                if (_stadium == value)
                    return;
                _stadium = value;
                NotifyPropertyChanged(m => m.Stadium);
            }
        }

        private ObservableCollection<Boolean> _isChecked;

        public ObservableCollection<Boolean> IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked == value)
                    return;
                _isChecked = value;
                NotifyPropertyChanged(m => m.IsChecked);
            }
        }

        private Boolean _isWeekSet;

        public Boolean IsWeekSet
        {
            get { return _isWeekSet; }
            set
            {
                if (_isWeekSet == value)
                    return;
                _isWeekSet = value;
                NotifyPropertyChanged(m => m.IsWeekSet);
            }
        }
    }
}
