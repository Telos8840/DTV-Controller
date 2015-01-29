using System;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace RCS.DTV.RZC.Converters
{
    public class PathToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value is string && !String.IsNullOrEmpty(value.ToString()))
                {
                    string imgPath = value.ToString();

                    if (String.IsNullOrEmpty(imgPath) || !File.Exists(imgPath))
                    {
                        return new BitmapImage(new Uri(@"/Assets/HeadshotPlaceholder.png", UriKind.Relative));
                    }//if -- headshot image
                    else
                    {
                        if (File.Exists(imgPath))
                        {
                            if (imgPath.ToLower().Contains(".tga"))
                            {
                                //Get targa file
                                var bitImage = Paloma.TargaImage.LoadTargaImage(imgPath);

                                //Convert targe file to BitMapSource
                                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitImage.GetHbitmap(),
                                                                                                                          IntPtr.Zero,
                                                                                                                          System.Windows.Int32Rect.Empty,
                                                                                                                          BitmapSizeOptions.FromWidthAndHeight(bitImage.Width, bitImage.Height));
                            }
                            else
                            {
                                return new BitmapImage(new Uri(@imgPath, UriKind.Absolute));
                            }
                        }

                    }//else -- headshot image
                }
            }
            catch (Exception xe)
            {
                Console.WriteLine(xe.ToString());
            }

            return new BitmapImage(new Uri(@"/Assets/HeadshotPlaceholder.png", UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "";
        }
    }
}
