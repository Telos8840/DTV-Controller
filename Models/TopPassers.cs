using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    public class TopPassers : ModelBase<TopPassers>
    {
        private string _picture;

        public string Picture
        {
            get { return _picture; }
            set
            {
                if (_picture == value)
                    return;
                _picture = value;
                NotifyPropertyChanged(m => m.Picture);
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

        private string _completions;

        public string Completions
        {
            get { return _completions; }
            set
            {
                if (_completions == value)
                    return;
                _completions = value;
                NotifyPropertyChanged(m => m.Completions);
            }
        }

        private string _attempts;

        public string Attempts
        {
            get { return _attempts; }
            set
            {
                if (_attempts == value)
                    return;
                _attempts = value;
                NotifyPropertyChanged(m => m.Attempts);
            }
        }

        private string _yards;

        public string Yards
        {
            get { return _yards; }
            set
            {
                if (_yards == value)
                    return;
                _yards = value;
                NotifyPropertyChanged(m => m.Yards);
            }
        }

        private string _touchdowns;

        public string Touchdowns
        {
            get { return _touchdowns; }
            set
            {
                if (_touchdowns == value)
                    return;
                _touchdowns = value;
                NotifyPropertyChanged(m => m.Touchdowns);
            }
        }

        private string _interceptions;

        public string Interceptions
        {
            get { return _interceptions; }
            set
            {
                if (_interceptions == value)
                    return;
                _interceptions = value;
                NotifyPropertyChanged(m => m.Interceptions);
            }
        }

        private string _completionPCT;

        public string CompletionPCT
        {
            get { return _completionPCT; }
            set
            {
                if (_completionPCT == value)
                    return;
                _completionPCT = value;
                NotifyPropertyChanged(m => m.CompletionPCT);
            }
        }

        private string _average;

        public string Average
        {
            get { return _average; }
            set
            {
                if (_average == value)
                    return;
                _average = value;
                NotifyPropertyChanged(m => m.Average);
            }
        }

        private string _long;

        public string Long
        {
            get { return _long; }
            set
            {
                if (_long == value)
                    return;
                _long = value;
                NotifyPropertyChanged(m => m.Long);
            }
        }
    }
}