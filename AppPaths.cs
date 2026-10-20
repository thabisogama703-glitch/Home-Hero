using System;
using System.IO;

namespace Home_Hero
{
    /// <summary>
    /// One place that decides where HomeHero keeps its data files (customers, requests, providers ...).
    ///
    /// The files live in the current user's own folder (%LocalAppData%\HomeHero) so that the app
    /// works no matter where it is launched from or installed - a shortcut, a USB stick, a
    /// published single-file .exe, or "Program Files" (which a normal user is not allowed to write to).
    /// Files that an older version saved next to the program are copied across the first time they are needed.
    /// </summary>
    public static class AppPaths
    {
        public static string DataDirectory { get; }

        static AppPaths()
        {
            string dir;
            try
            {
                dir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "HomeHero");
                Directory.CreateDirectory(dir);
            }
            catch
            {
                // Last resort: next to the program (e.g. a locked-down profile).
                dir = AppContext.BaseDirectory;
            }

            DataDirectory = dir;
        }

        /// <summary>Full path of a data file, e.g. DataFile("customers.txt").</summary>
        public static string DataFile(string fileName)
        {
            string target = Path.Combine(DataDirectory, fileName);

            try
            {
                if (!File.Exists(target))
                {
                    // bring over data saved by an earlier build (next to the exe, or in the working folder)
                    string[] legacyLocations =
                    {
                        Path.Combine(AppContext.BaseDirectory, fileName),
                        Path.Combine(Environment.CurrentDirectory, fileName)
                    };

                    foreach (string legacy in legacyLocations)
                    {
                        if (!string.Equals(legacy, target, StringComparison.OrdinalIgnoreCase) && File.Exists(legacy))
                        {
                            File.Copy(legacy, target, false);
                            break;
                        }
                    }
                }
            }
            catch
            {
                // migration is a convenience only
            }

            return target;
        }
    }
}
