using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    public class Injuries : ModelBase<Injuries>
    {
        private string _logo;

        public string Logo
        {
            get { return _logo; }
            set
            {
                if (_logo == value)
                    return;
                _logo = value;
                NotifyPropertyChanged(m => m.Logo);
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

        private string _injury;

        public string Injury
        {
            get { return _injury; }
            set
            {
                if (_injury == value)
                    return;
                _injury = value;
                NotifyPropertyChanged(m => m.Injury);
            }
        }
    }
}
