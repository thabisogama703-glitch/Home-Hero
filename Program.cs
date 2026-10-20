using MessageBox = System.Windows.Forms.MessageBox;

namespace Home_Hero
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Same behaviour as the original project: crisp text, Windows handles scaling per screen.
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show a readable message (and keep a log) instead of the app silently closing on an unexpected error.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => ReportError(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => ReportError(e.ExceptionObject as Exception);

            Application.Run(new HomeHeroContext());
        }

        /// <summary>Starts on the homepage; the app closes when the last visible window closes (see FitForm).</summary>
        private sealed class HomeHeroContext : ApplicationContext
        {
            public HomeHeroContext()
            {
                new frmHomeHeroHomepage().Show();
            }
        }

        private static void ReportError(Exception? ex)
        {
            try
            {
                string log = AppPaths.DataFile("error.log");
                File.AppendAllText(log, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + ex + Environment.NewLine + Environment.NewLine);
                MessageBox.Show(
                    "Something unexpected happened:\n\n" + (ex?.Message ?? "Unknown error") +
                    "\n\nDetails were saved to:\n" + log,
                    "HomeHero", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                // nothing more we can do
            }
        }
    }
}
