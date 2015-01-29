using System;
using System.Xml.Serialization;
using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    [Serializable]
    public class Route : ModelBase<Route>
    {
        private string _id;
        [XmlAttribute]
        public string Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                    return;
                _id = value;
                NotifyPropertyChanged(m => m.Id);
            }
        }

        private string  _description;
        [XmlAttribute]
        public string  Description
        {
            get { return _description; }
            set
            {
                if (_description == value)
                    return;
                _description = value;
                NotifyPropertyChanged(m => m.Description);
            }
        }

        private string _customDescription;
        [XmlAttribute]
        public string CustomDescription
        {
            get { return _customDescription; }
            set
            {
                if (_customDescription == value)
                    return;
                _customDescription = value;
                NotifyPropertyChanged(m => m.CustomDescription);
            }
        }

        [XmlIgnore]
        public string DisplayDescription
        {
            get
            {
                return String.IsNullOrEmpty(CustomDescription) ?
                    Description : CustomDescription;
            }
        }

        private bool? _isSelected;
        [XmlIgnore]
        public bool? IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value)
                    return;
                _isSelected = value;
                NotifyPropertyChanged(m => m.IsSelected);
            }
        }


    }
}
