using System;
using Microsoft.Win32;

namespace RCS.DTV.RZC.Services
{
    public class MainLogoServiceAgent : IMainLogoServiceAgent
    {
        private Boolean _pathExists = true;

        public string LoadLogo1()
        {
            var dlg = new OpenFileDialog();

            try
            {

                dlg.InitialDirectory = _pathExists ? @"U:\RedZone\" : @"C:\";

                dlg.DefaultExt = ".txt";
                dlg.Filter =
                    "Image Files(*.TGA;*.TIF;*.TIFF;*.JPG;*.JPEG;*.PNG;*.BMP)|*.TGA;*.TIF;*.TIFf;*.JPG;*.JPEG;*.PNG;.BMP|All files (*.*)|*.*";
                
                var result = dlg.ShowDialog();

                if (result == true)
                    return dlg.FileName;

            }
            catch (Exception)
            {
                Console.WriteLine("\n ERROR: CANNOT FIND FILE DIRECTORY \n");
                _pathExists = false;
                LoadLogo1();
            }

            return @"/Assets/LogoPlaceholder.png";
        }

        public string LoadLogo2()
        {
            var dlg = new OpenFileDialog();

            try
            {

                dlg.InitialDirectory = _pathExists ? @"U:\RedZone\" : @"C:\";

                dlg.DefaultExt = ".txt";
                dlg.Filter =
                    "Image Files(*.TGA;*.TIF;*.TIFF;*.JPG;*.JPEG;*.PNG;*.BMP)|*.TGA;*.TIF;*.TIFf;*.JPG;*.JPEG;*.PNG;.BMP|All files (*.*)|*.*";

                var result = dlg.ShowDialog();

                if (result == true)
                    return dlg.FileName;

            }
            catch (Exception)
            {
                Console.WriteLine("\n ERROR: CANNOT FIND FILE DIRECTORY \n");
                _pathExists = false;
                LoadLogo1();
            }

            return @"/Assets/LogoPlaceholder.png";
        }
    }
}