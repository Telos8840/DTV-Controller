using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    public class SponsorLogo : ModelBase<SponsorLogo>
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
    }
}
