using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// Toolkit namespace
using System.Linq;
using System.Xml.Linq;
using RCS.DTV.RZC.Models;
using RCS.DTV.RZC.Services;
using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class NfcDivisionViewModel : ViewModelBase<NfcDivisionViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private IPlayoffDivisionServiceAgent _serviceAgent;

        // Default ctor
        public NfcDivisionViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public NfcDivisionViewModel(IPlayoffDivisionServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;
            Teams = new ObservableCollection<CoreTeams>(CurrentSession.GetTeams());
            PlayoffTeams = new ObservableCollection<PlayoffTeam>();
            Tags = new ObservableCollection<string> { "", "X", "Y", "Z" };

            for (int i = 0; i < 14; i++)
                PlayoffTeams.Add(new PlayoffTeam());

            LoadFromXML();
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // Binding Properties
        private ObservableCollection<CoreTeams> _teams;

        public ObservableCollection<CoreTeams> Teams
        {
            get { return _teams; }
            set
            {
                if (_teams == value)
                    return;
                _teams = value;
                NotifyPropertyChanged(m => m.Teams);
            }
        }

        private ObservableCollection<PlayoffTeam> _playoffTeams;

        public ObservableCollection<PlayoffTeam> PlayoffTeams
        {
            get { return _playoffTeams; }
            set
            {
                if (_playoffTeams == value)
                    return;
                _playoffTeams = value;
                NotifyPropertyChanged(m => m.PlayoffTeams);
            }
        }

        private ObservableCollection<string> _tags;

        public ObservableCollection<string> Tags
        {
            get { return _tags; }
            set
            {
                if (_tags == value)
                    return;
                _tags = value;
                NotifyPropertyChanged(m => m.Tags);
            }
        }

        private int _index;

        public int Index
        {
            get { return _index; }
            set
            {
                if (_index == value)
                    return;
                _index = value;
                NotifyPropertyChanged(m => m.Index);
            }
        }

        #region SelectedTeam Properties

        private CoreTeams _selectedTeam1;

        public CoreTeams SelectedTeam1
        {
            get { return _selectedTeam1; }
            set
            {
                if (_selectedTeam1 == value)
                    return;
                _selectedTeam1 = value;
                NotifyPropertyChanged(m => m.SelectedTeam1);
            }
        }

        private CoreTeams _selectedTeam2;

        public CoreTeams SelectedTeam2
        {
            get { return _selectedTeam2; }
            set
            {
                if (_selectedTeam2 == value)
                    return;
                _selectedTeam2 = value;
                NotifyPropertyChanged(m => m.SelectedTeam2);
            }
        }

        private CoreTeams _selectedTeam3;

        public CoreTeams SelectedTeam3
        {
            get { return _selectedTeam3; }
            set
            {
                if (_selectedTeam3 == value)
                    return;
                _selectedTeam3 = value;
                NotifyPropertyChanged(m => m.SelectedTeam3);
            }
        }

        private CoreTeams _selectedTeam4;

        public CoreTeams SelectedTeam4
        {
            get { return _selectedTeam4; }
            set
            {
                if (_selectedTeam4 == value)
                    return;
                _selectedTeam4 = value;
                NotifyPropertyChanged(m => m.SelectedTeam4);
            }
        }

        private CoreTeams _selectedTeam5;

        public CoreTeams SelectedTeam5
        {
            get { return _selectedTeam5; }
            set
            {
                if (_selectedTeam5 == value)
                    return;
                _selectedTeam5 = value;
                NotifyPropertyChanged(m => m.SelectedTeam5);
            }
        }

        private CoreTeams _selectedTeam6;

        public CoreTeams SelectedTeam6
        {
            get { return _selectedTeam6; }
            set
            {
                if (_selectedTeam6 == value)
                    return;
                _selectedTeam6 = value;
                NotifyPropertyChanged(m => m.SelectedTeam6);
            }
        }

        private CoreTeams _selectedTeam7;

        public CoreTeams SelectedTeam7
        {
            get { return _selectedTeam7; }
            set
            {
                if (_selectedTeam7 == value)
                    return;
                _selectedTeam7 = value;
                NotifyPropertyChanged(m => m.SelectedTeam7);
            }
        }

        private CoreTeams _selectedTeam8;

        public CoreTeams SelectedTeam8
        {
            get { return _selectedTeam8; }
            set
            {
                if (_selectedTeam8 == value)
                    return;
                _selectedTeam8 = value;
                NotifyPropertyChanged(m => m.SelectedTeam8);
            }
        }

        private CoreTeams _selectedTeam9;

        public CoreTeams SelectedTeam9
        {
            get { return _selectedTeam9; }
            set
            {
                if (_selectedTeam9 == value)
                    return;
                _selectedTeam9 = value;
                NotifyPropertyChanged(m => m.SelectedTeam9);
            }
        }

        private CoreTeams _selectedTeam10;

        public CoreTeams SelectedTeam10
        {
            get { return _selectedTeam10; }
            set
            {
                if (_selectedTeam10 == value)
                    return;
                _selectedTeam10 = value;
                NotifyPropertyChanged(m => m.SelectedTeam10);
            }
        }

        private CoreTeams _selectedTeam11;

        public CoreTeams SelectedTeam11
        {
            get { return _selectedTeam11; }
            set
            {
                if (_selectedTeam11 == value)
                    return;
                _selectedTeam11 = value;
                NotifyPropertyChanged(m => m.SelectedTeam11);
            }
        }

        private CoreTeams _selectedTeam12;

        public CoreTeams SelectedTeam12
        {
            get { return _selectedTeam12; }
            set
            {
                if (_selectedTeam12 == value)
                    return;
                _selectedTeam12 = value;
                NotifyPropertyChanged(m => m.SelectedTeam12);
            }
        }

        private CoreTeams _selectedTeam13;

        public CoreTeams SelectedTeam13
        {
            get { return _selectedTeam13; }
            set
            {
                if (_selectedTeam13 == value)
                    return;
                _selectedTeam13 = value;
                NotifyPropertyChanged(m => m.SelectedTeam13);
            }
        }

        private CoreTeams _selectedTeam14;

        public CoreTeams SelectedTeam14
        {
            get { return _selectedTeam14; }
            set
            {
                if (_selectedTeam14 == value)
                    return;
                _selectedTeam14 = value;
                NotifyPropertyChanged(m => m.SelectedTeam14);
            }
        }

        #endregion

        #region Selected Index

        private int _selectedIndex1;

        public int SelectedIndex1
        {
            get { return _selectedIndex1; }
            set
            {
                if (_selectedIndex1 == value)
                    return;
                _selectedIndex1 = value;
                NotifyPropertyChanged(m => m.SelectedIndex1);
            }
        }

        private int _selectedIndex2;

        public int SelectedIndex2
        {
            get { return _selectedIndex2; }
            set
            {
                if (_selectedIndex2 == value)
                    return;
                _selectedIndex2 = value;
                NotifyPropertyChanged(m => m.SelectedIndex2);
            }
        }

        private int _selectedIndex3;

        public int SelectedIndex3
        {
            get { return _selectedIndex3; }
            set
            {
                if (_selectedIndex3 == value)
                    return;
                _selectedIndex3 = value;
                NotifyPropertyChanged(m => m.SelectedIndex3);
            }
        }

        private int _selectedIndex4;

        public int SelectedIndex4
        {
            get { return _selectedIndex4; }
            set
            {
                if (_selectedIndex4 == value)
                    return;
                _selectedIndex4 = value;
                NotifyPropertyChanged(m => m.SelectedIndex4);
            }
        }

        private int _selectedIndex5;

        public int SelectedIndex5
        {
            get { return _selectedIndex5; }
            set
            {
                if (_selectedIndex5 == value)
                    return;
                _selectedIndex5 = value;
                NotifyPropertyChanged(m => m.SelectedIndex5);
            }
        }

        private int _selectedIndex6;

        public int SelectedIndex6
        {
            get { return _selectedIndex6; }
            set
            {
                if (_selectedIndex6 == value)
                    return;
                _selectedIndex6 = value;
                NotifyPropertyChanged(m => m.SelectedIndex6);
            }
        }

        private int _selectedIndex7;

        public int SelectedIndex7
        {
            get { return _selectedIndex7; }
            set
            {
                if (_selectedIndex7 == value)
                    return;
                _selectedIndex7 = value;
                NotifyPropertyChanged(m => m.SelectedIndex7);
            }
        }

        private int _selectedIndex8;

        public int SelectedIndex8
        {
            get { return _selectedIndex8; }
            set
            {
                if (_selectedIndex8 == value)
                    return;
                _selectedIndex8 = value;
                NotifyPropertyChanged(m => m.SelectedIndex8);
            }
        }

        private int _selectedIndex9;

        public int SelectedIndex9
        {
            get { return _selectedIndex9; }
            set
            {
                if (_selectedIndex9 == value)
                    return;
                _selectedIndex9 = value;
                NotifyPropertyChanged(m => m.SelectedIndex9);
            }
        }

        private int _selectedIndex10;

        public int SelectedIndex10
        {
            get { return _selectedIndex10; }
            set
            {
                if (_selectedIndex10 == value)
                    return;
                _selectedIndex10 = value;
                NotifyPropertyChanged(m => m.SelectedIndex10);
            }
        }

        private int _selectedIndex11;

        public int SelectedIndex11
        {
            get { return _selectedIndex11; }
            set
            {
                if (_selectedIndex11 == value)
                    return;
                _selectedIndex11 = value;
                NotifyPropertyChanged(m => m.SelectedIndex11);
            }
        }

        private int _selectedIndex12;

        public int SelectedIndex12
        {
            get { return _selectedIndex12; }
            set
            {
                if (_selectedIndex12 == value)
                    return;
                _selectedIndex12 = value;
                NotifyPropertyChanged(m => m.SelectedIndex12);
            }
        }

        private int _selectedIndex13;

        public int SelectedIndex13
        {
            get { return _selectedIndex13; }
            set
            {
                if (_selectedIndex13 == value)
                    return;
                _selectedIndex13 = value;
                NotifyPropertyChanged(m => m.SelectedIndex13);
            }
        }

        private int _selectedIndex14;

        public int SelectedIndex14
        {
            get { return _selectedIndex14; }
            set
            {
                if (_selectedIndex14 == value)
                    return;
                _selectedIndex14 = value;
                NotifyPropertyChanged(m => m.SelectedIndex14);
            }
        }

        #endregion

        private List<int> _indexes;

        public List<int> Indexes
        {
            get { return _indexes; }
            set
            {
                if (_indexes == value)
                    return;
                _indexes = value;
                NotifyPropertyChanged(m => m.Indexes);
            }
        }

        // Methods that will be called by the view

        #region Combobox Commands

        public void SetTeam1()
        {
            Index = 0;
            SetTeamData(SelectedTeam1);
        }

        public void SetTeam2()
        {
            Index = 1;
            SetTeamData(SelectedTeam2);
        }

        public void SetTeam3()
        {
            Index = 2;
            SetTeamData(SelectedTeam3);
        }

        public void SetTeam4()
        {
            Index = 3;
            SetTeamData(SelectedTeam4);
        }

        public void SetTeam5()
        {
            Index = 4;
            SetTeamData(SelectedTeam5);
        }

        public void SetTeam6()
        {
            Index = 5;
            SetTeamData(SelectedTeam6);
        }

        public void SetTeam7()
        {
            Index = 6;
            SetTeamData(SelectedTeam7);
        }

        public void SetTeam8()
        {
            Index = 7;
            SetTeamData(SelectedTeam8);
        }

        public void SetTeam9()
        {
            Index = 8;
            SetTeamData(SelectedTeam9);
        }

        public void SetTeam10()
        {
            Index = 9;
            SetTeamData(SelectedTeam10);
        }

        public void SetTeam11()
        {
            Index = 10;
            SetTeamData(SelectedTeam11);
        }

        public void SetTeam12()
        {
            Index = 11;
            SetTeamData(SelectedTeam12);
        }

        public void SetTeam13()
        {
            Index = 12;
            SetTeamData(SelectedTeam13);
        }

        public void SetTeam14()
        {
            Index = 13;
            SetTeamData(SelectedTeam14);
        }

        #endregion

        public void ResetBoard()
        {
            SelectedIndex1 = 0;
            SelectedIndex2 = 0;
            SelectedIndex3 = 0;
            SelectedIndex4 = 0;
            SelectedIndex5 = 0;
            SelectedIndex6 = 0;
            SelectedIndex7 = 0;
            SelectedIndex8 = 0;
            SelectedIndex9 = 0;
            SelectedIndex10 = 0;
            SelectedIndex11 = 0;
            SelectedIndex12 = 0;
            SelectedIndex13 = 0;
            SelectedIndex14 = 0;

            for (int i = 0; i < PlayoffTeams.Count; i++)
                PlayoffTeams[i] = new PlayoffTeam();
        }

        public void SetPlayoffDivisionData()
        {
            SaveToXML();
            _serviceAgent.SetPlayoffDivisionData("NFC", PlayoffTeams);
        }

        private void SetTeamData(CoreTeams selectedTeam)
        {
            //var tri = _serviceAgent.GetTeamData(selectedTeam.Tricode);
            PlayoffTeams[Index].TriCode = selectedTeam.Tricode;
        }

        private void SaveToXML()
        {
            AddToCollection();
            try
            {
                XDocument doc = XDocument.Load("RZCData.xml");
                var afc = doc.Root.Descendants("NFC");

                foreach (var element in afc)
                {
                    int i = 0;

                    var leaders = element.Descendants("Leaders").Descendants("Team");
                    foreach (var leader in leaders)
                    {
                        leader.Attribute("Tag").Value = !String.IsNullOrEmpty(PlayoffTeams[i].Tag) ? PlayoffTeams[i].Tag : "";
                        leader.Attribute("Tricode").Value = !String.IsNullOrEmpty(PlayoffTeams[i].TriCode) ? PlayoffTeams[i].TriCode : "";
                        leader.Attribute("Record").Value = !String.IsNullOrEmpty(PlayoffTeams[i].Record) ? PlayoffTeams[i].Record : "";
                        leader.Attribute("Index").Value = Indexes[i].ToString();
                        i++;
                    }

                    var wilds = element.Descendants("Wild").Descendants("Team");
                    foreach (var wild in wilds)
                    {
                        wild.Attribute("Tag").Value = !String.IsNullOrEmpty(PlayoffTeams[i].Tag) ? PlayoffTeams[i].Tag : "";
                        wild.Attribute("Tricode").Value = !String.IsNullOrEmpty(PlayoffTeams[i].TriCode) ? PlayoffTeams[i].TriCode : "";
                        wild.Attribute("Record").Value = !String.IsNullOrEmpty(PlayoffTeams[i].Record) ? PlayoffTeams[i].Record : "";
                        wild.Attribute("Index").Value = Indexes[i].ToString();
                        i++;
                    }

                    var hunts = element.Descendants("Hunt").Descendants("Team");
                    foreach (var hunt in hunts)
                    {
                        hunt.Attribute("Tag").Value = !String.IsNullOrEmpty(PlayoffTeams[i].Tag) ? PlayoffTeams[i].Tag : "";
                        hunt.Attribute("Tricode").Value = !String.IsNullOrEmpty(PlayoffTeams[i].TriCode) ? PlayoffTeams[i].TriCode : "";
                        hunt.Attribute("Record").Value = !String.IsNullOrEmpty(PlayoffTeams[i].Record) ? PlayoffTeams[i].Record : "";
                        hunt.Attribute("Index").Value = Indexes[i].ToString();
                        i++;
                    }
                }
                doc.Save("RZCData.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void LoadFromXML()
        {
            try
            {
                XDocument doc = XDocument.Load("RZCData.xml");
                var afc = doc.Root.Descendants("NFC");
                var indices = afc.Descendants("Team").ToList();

                foreach (var element in afc)
                {
                    int i = 0;

                    var leaders = element.Descendants("Leaders").Descendants("Team");
                    foreach (var leader in leaders)
                    {
                        PlayoffTeams[i].Tag = leader.Attribute("Tag").Value;
                        PlayoffTeams[i].TriCode = leader.Attribute("Tricode").Value;
                        PlayoffTeams[i].Record = leader.Attribute("Record").Value;
                        i++;
                    }

                    var wilds = element.Descendants("Wild").Descendants("Team");
                    foreach (var wild in wilds)
                    {
                        PlayoffTeams[i].Tag = wild.Attribute("Tag").Value;
                        PlayoffTeams[i].TriCode = wild.Attribute("Tricode").Value;
                        PlayoffTeams[i].Record = wild.Attribute("Record").Value;
                        i++;
                    }

                    var hunts = element.Descendants("Hunt").Descendants("Team");
                    foreach (var hunt in hunts)
                    {
                        PlayoffTeams[i].Tag = hunt.Attribute("Tag").Value;
                        PlayoffTeams[i].TriCode = hunt.Attribute("Tricode").Value;
                        PlayoffTeams[i].Record = hunt.Attribute("Record").Value;
                        i++;
                    }
                }

                SelectedIndex1 = int.Parse(indices[0].Attribute("Index").Value);
                SelectedIndex2 = int.Parse(indices[1].Attribute("Index").Value);
                SelectedIndex3 = int.Parse(indices[2].Attribute("Index").Value);
                SelectedIndex4 = int.Parse(indices[3].Attribute("Index").Value);
                SelectedIndex5 = int.Parse(indices[4].Attribute("Index").Value);
                SelectedIndex6 = int.Parse(indices[5].Attribute("Index").Value);
                SelectedIndex7 = int.Parse(indices[6].Attribute("Index").Value);
                SelectedIndex8 = int.Parse(indices[7].Attribute("Index").Value);
                SelectedIndex9 = int.Parse(indices[8].Attribute("Index").Value);
                SelectedIndex10 = int.Parse(indices[9].Attribute("Index").Value);
                SelectedIndex11 = int.Parse(indices[10].Attribute("Index").Value);
                SelectedIndex12 = int.Parse(indices[11].Attribute("Index").Value);
                SelectedIndex13 = int.Parse(indices[12].Attribute("Index").Value);
                SelectedIndex14 = int.Parse(indices[13].Attribute("Index").Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void AddToCollection()
        {
            Indexes = new List<int>
            {
                SelectedIndex1,
                SelectedIndex2,
                SelectedIndex3,
                SelectedIndex4,
                SelectedIndex5,
                SelectedIndex6,
                SelectedIndex7,
                SelectedIndex8,
                SelectedIndex9,
                SelectedIndex10,
                SelectedIndex11,
                SelectedIndex12,
                SelectedIndex13,
                SelectedIndex14
            };
        }

        // TODO: Optionally add callback methods for async calls to the service agent
        
        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
    }
}