using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
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
    public class InjuryViewModel : ViewModelBase<InjuryViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private IInjuryServiceAgent _serviceAgent;

        // Default ctor
        public InjuryViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public InjuryViewModel(IInjuryServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;
            Teams = new ObservableCollection<CoreTeams>(CurrentSession.GetTeams());

            InjuredPlayers = new ObservableCollection<Injuries>();

            for (int i = 0; i < 7; i++)
                InjuredPlayers.Add(new Injuries());

            LoadFromXML();
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet
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

        private ObservableCollection<Injuries> _injuredPlayers;

        public ObservableCollection<Injuries> InjuredPlayers
        {
            get { return _injuredPlayers; }
            set
            {
                if (_injuredPlayers == value)
                    return;
                _injuredPlayers = value;
                NotifyPropertyChanged(m => m.InjuredPlayers);
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

        #endregion

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
        #endregion

        // TODO: Add methods that will be called by the view
        public void SetInjuredPlayers()
        {
            SaveToXML();
            _serviceAgent.SetInjuredPlayers(InjuredPlayers);
        }

        public void ResetData()
        {
            SelectedIndex1 = 0;
            SelectedIndex2 = 0;
            SelectedIndex3 = 0;
            SelectedIndex4 = 0;
            SelectedIndex5 = 0;
            SelectedIndex6 = 0;
            SelectedIndex7 = 0;

            for (int i = 0; i < InjuredPlayers.Count; i++)
                InjuredPlayers[i] = new Injuries();
        }

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
        #endregion

        private void SetTeamData(CoreTeams selectedTeam)
        {
            var team = _serviceAgent.GetTeamData(selectedTeam.Tricode);
            InjuredPlayers[Index] = team;
        }

        private void LoadFromXML()
        {
            try
            {
                XDocument doc = XDocument.Load("RZCData.xml");
                var player = doc.Root.Descendants("Player");

                int i = 0;
                foreach (var element in player)
                {
                    if (!element.Attribute("Tricode").Value.Equals(""))
                        InjuredPlayers[i].Logo = element.Attribute("Tricode").Value;
                    
                    InjuredPlayers[i].Position = element.Attribute("Position").Value;
                    InjuredPlayers[i].Name = element.Attribute("Name").Value;
                    InjuredPlayers[i].Injury = element.Attribute("Injury").Value;
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        private void SaveToXML()
        {
            try
            {
                XDocument doc = XDocument.Load("RZCData.xml");
                var player = doc.Root.Descendants("Player");

                int i = 0;
                foreach (var element in player)
                {
                    if (InjuredPlayers[i].Logo != null)
                    {
                        element.Attribute("Tricode").Value = InjuredPlayers[i].Logo;
                        element.Attribute("Position").Value = InjuredPlayers[i].Position;
                        element.Attribute("Name").Value = InjuredPlayers[i].Name;
                        element.Attribute("Injury").Value = InjuredPlayers[i].Injury;
                    }
                    else
                    {
                        element.Attribute("Tricode").Value = "";
                        element.Attribute("Position").Value = "";
                        element.Attribute("Name").Value = "";
                        element.Attribute("Injury").Value = "";
                    }
                    i++;
                }
                doc.Save("RZCData.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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