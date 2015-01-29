using System.Collections.ObjectModel;
using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    public class PlayoffDivisions : ModelBase<PlayoffDivisions>
    {

        private ObservableCollection<Categories> _afc;

        public ObservableCollection<Categories> Afc
        {
            get { return _afc; }
            set
            {
                if (_afc == value)
                    return;
                _afc = value;
                NotifyPropertyChanged(m => m.Afc);
            }
        }

        private ObservableCollection<Categories> _nfc;

        public ObservableCollection<Categories> Nfc
        {
            get { return _nfc; }
            set
            {
                if (_nfc == value)
                    return;
                _nfc = value;
                NotifyPropertyChanged(m => m.Nfc);
            }
        }
    }

    public class Categories : ModelBase<Categories>
    {
        private ObservableCollection<PlayoffTeam> _divLeaders;

        public ObservableCollection<PlayoffTeam> DivLeaders
        {
            get { return _divLeaders; }
            set
            {
                if (_divLeaders == value)
                    return;
                _divLeaders = value;
                NotifyPropertyChanged(m => m.DivLeaders);
            }
        }

        private ObservableCollection<PlayoffTeam> _wildLeaders;

        public ObservableCollection<PlayoffTeam> WildLeaders
        {
            get { return _wildLeaders; }
            set
            {
                if (_wildLeaders == value)
                    return;
                _wildLeaders = value;
                NotifyPropertyChanged(m => m.WildLeaders);
            }
        }

        private ObservableCollection<PlayoffTeam> _hunters;

        public ObservableCollection<PlayoffTeam> Hunters
        {
            get { return _hunters; }
            set
            {
                if (_hunters == value)
                    return;
                _hunters = value;
                NotifyPropertyChanged(m => m.Hunters);
            }
        }
    }

    public class PlayoffTeam : ModelBase<PlayoffTeam>
    {
        private string _triCode;

        public string TriCode
        {
            get { return _triCode; }
            set
            {
                if (_triCode == value)
                    return;
                _triCode = value;
                NotifyPropertyChanged(m => m.TriCode);
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

        private string _tag;

        public string Tag
        {
            get { return _tag; }
            set
            {
                if (_tag == value)
                    return;
                _tag = value;
                NotifyPropertyChanged(m => m.Tag);
            }
        }
    }
}