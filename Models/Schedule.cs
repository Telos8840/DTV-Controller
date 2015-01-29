using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    public class Schedule : ModelBase<Schedule>
    {
        private string _team;

        public string Team
        {
            get { return _team; }
            set
            {
                if (_team == value)
                    return;
                _team = value;
                NotifyPropertyChanged(m => m.Team);
            }
        }

        private List<Tuple<int, string>> _upcomingTeam;

        public List<Tuple<int, string>> UpcomingTeam
        {
            get { return _upcomingTeam; }
            set
            {
                if (_upcomingTeam == value)
                    return;
                _upcomingTeam = value;
                NotifyPropertyChanged(m => m.UpcomingTeam);
            }
        }
    }
}