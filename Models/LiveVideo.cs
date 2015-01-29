using System.Collections.ObjectModel;
using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    public class LiveVideo : ModelBase<LiveVideo>
    {
        private string _input;

        public string Input
        {
            get { return _input; }
            set
            {
                if (_input == value)
                    return;
                _input = value;
                NotifyPropertyChanged(m => m.Input);
            }
        }

        private ObservableCollection<CoreTeams> _selectedAwayMatches;

        public ObservableCollection<CoreTeams> SelectedAwayMatches
        {
            get { return _selectedAwayMatches; }
            set
            {
                if (_selectedAwayMatches == value)
                    return;
                _selectedAwayMatches = value;
                NotifyPropertyChanged(m => m.SelectedAwayMatches);
            }
        }

        private ObservableCollection<CoreTeams> _selectedHomeMatches;

        public ObservableCollection<CoreTeams> SelectedHomeMatches
        {
            get { return _selectedHomeMatches; }
            set
            {
                if (_selectedHomeMatches == value)
                    return;
                _selectedHomeMatches = value;
                NotifyPropertyChanged(m => m.SelectedHomeMatches);
            }
        }
    }
}