using System;
using System.Windows.Data;

namespace RCS.DTV.RZC.Converters
{
    public class TeamLogoImgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                if (value != "" && value != null)
                    return "../Assets/" + value + ".png";

                return "../Assets/LogoPlaceholder.png";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}