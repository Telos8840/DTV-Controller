using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    public class CoreTeams : ModelBase<CoreTeams>
    {
        private string _tricode;

        public string Tricode
        {
            get { return _tricode; }
            set
            {
                if (_tricode == value)
                    return;
                _tricode = value;
                NotifyPropertyChanged(m => m.Tricode);
            }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set
            {
                if (_city == value)
                    return;
                _city = value;
                NotifyPropertyChanged(m => m.City);
            }
        }

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

        private string _conference;

        public string Conference
        {
            get { return _conference; }
            set
            {
                if (_conference == value)
                    return;
                _conference = value;
                NotifyPropertyChanged(m => m.Conference);
            }
        }

        private string _division;

        public string Division
        {
            get { return _division; }
            set
            {
                if (_division == value)
                    return;
                _division = value;
                NotifyPropertyChanged(m => m.Division);
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
    }
}
