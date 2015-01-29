using SimpleMvvmToolkit;

namespace RCS.DTV.RZC.Models
{
    public class MainLogo : ModelBase<MainLogo>
    {
        private string _logo1;

        public string Logo1
        {
            get { return _logo1; }
            set
            {
                if (_logo1 == value)
                    return;
                _logo1 = value;
                NotifyPropertyChanged(m => m.Logo1);
            }
        }

        private string _logo2;

        public string Logo2
        {
            get { return _logo2; }
            set
            {
                if (_logo2 == value)
                    return;
                _logo2 = value;
                NotifyPropertyChanged(m => m.Logo2);
            }
        }
    }
}