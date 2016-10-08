using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelWall
{
    class Program
    {
        static public Boolean showDebug = false;
        static public string wallpaperKeyName = "WallpaperSource";
        static public string registryLocationWin7 = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Desktop\General";

        static public string wallpaperTranscodedKeyName = "Wallpaper";
        static public string registryLocationTranscodedWin7 = @"HKEY_CURRENT_USER\Control Panel\Desktop";

        static void Main(string[] args)
        {
            Boolean consoleMode = false;
            Boolean quickValuesMode = false;
            Boolean previewMode = false;
            Boolean desktopMode = false;

            Console.WriteLine("DelWall v0.1");
            Console.WriteLine();

            foreach (string argFlags in args)
            {
                switch (argFlags)
                {
                    case "-c":
                        consoleMode = true;
                        break;
                    case "-q":
                        quickValuesMode = true;
                        break;
                    case "-p":
                        previewMode = true;
                        break;
                    case "-d":
                        desktopMode = true;
                        break;
                    default:
                        Console.WriteLine("Flags:");
                        Console.WriteLine();
                        Console.WriteLine(" -c  :   Console Mode");
                        Console.WriteLine(" -q  :   Quick Values Mode");
                        Console.WriteLine(" -p  :   Preview Mode");
                        Console.WriteLine(" -d  :   Desktop Mode");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to exit");
                        Console.Read();
                        break;
                }
            }

            List<Screen> monitors = new List<Screen>();
            foreach(var monitor in Screen.AllScreens)
            {
                monitors.Add(monitor);
            }

            string wallpaperTranscoded = readLocation(registryLocationTranscodedWin7, wallpaperTranscodedKeyName);
            string wallpaperLocationWin7 = readLocation(registryLocationWin7, wallpaperKeyName);

            /* Console Mode - For usage in console */
            if (consoleMode)
            {
                Console.WriteLine("QUERY: Do you want to delete current wallpaper? (Y/N)");
                ConsoleKeyInfo queryKey = Console.ReadKey();
                Console.WriteLine();

                if (queryKey.KeyChar.Equals('y') || queryKey.KeyChar.Equals('Y'))
                {
                    deleteFile(wallpaperLocationWin7);
                    Console.WriteLine("SUCCESS: " + wallpaperLocationWin7 + " has been deleted");
                    Console.Read();
                }
                else
                {
                    Console.WriteLine("MSG: Wallpaper not deleted");
                    Console.Read();
                }

                return;
            }

            /* Quick Values Mode - For Testing Purposes */
            if (quickValuesMode)
            {
                Console.WriteLine("QUERY: Trancoded Wallpaper Location - {0}", wallpaperTranscoded);
                Console.WriteLine("QUERY: Windows 7 Wallpaper Location - {0}", wallpaperLocationWin7);
                Console.WriteLine();
                Console.WriteLine("QUERY: No. of monitors - {0}", monitors.Count);

                for (int i = 0; i < monitors.Count; i++)
                {
                    Console.WriteLine("QUERY: Device Name of Monitor {0} - {1}", i, monitors.ElementAt(i).DeviceName);
                }

                Console.WriteLine();
                Console.WriteLine("OSVersion: {0}", Environment.OSVersion.ToString());

                Console.Read();
                return;
            }

            /* Preview Mode */
            if(previewMode)
            {
                Application.EnableVisualStyles();
                Application.Run(new WPPreview());
            }

            /* Desktop Mode - No Cmd / Console Interactions*/
            if (desktopMode)
            {
                deleteFile(wallpaperLocationWin7);
                return;
            }
        }

        public static string readLocation(string keyName, string valueName) 
        {
            string wallLocation = (string)Registry.GetValue(@keyName, valueName, null);

            if (showDebug)
            {
                if (wallLocation == null)
                {
                    Console.WriteLine("ERROR: Key returned NULL");
                }
                else
                {
                    Console.WriteLine("SUCCESS: Location - " + wallLocation);
                }
            }
            
            return wallLocation;
        }

        static Boolean deleteFile(string filePath)
        {
            if (!File.Exists(filePath)) //Check for Access
            {
                return false;
            }
            else
            {
                File.Delete(filePath);
            }

            return true;
        }
    }
}

/*
 * Adding to the Desktop Right Click Menu
 * 
 * HKEY_CLASSES_ROOT\DesktopBackground\shell
 */

