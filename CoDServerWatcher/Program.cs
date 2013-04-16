using System;
using System.Windows.Forms;

namespace CoDServerWatcher {

    internal static class Program {

        #region Fields
        /// <summary>
        /// The server watched.
        /// </summary>
        public static Server Server; 
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main() {
            // Visual styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // INI file
            IniUtils.CreateKeys();
            IniValues.LoadFromFile();

            // Initialize CoD server
            Program.Server = new Server(IniValues.Host, IniValues.Port);

            // Start application
            new FormSystray();
            Application.Run();
        }
    }
}