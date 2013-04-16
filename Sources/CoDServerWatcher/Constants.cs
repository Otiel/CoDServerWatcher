using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoDServerWatcher {

    internal static class Constants {

        /// <summary>
        /// The contact website.
        /// </summary>
        public static readonly String Website = "https://github.com/Otiel/CoDServerWatcher";

        /// <summary>
        /// The path to the INI file.
        /// </summary>
        public static readonly String IniPath = ".\\CoDServerWatcher.ini";

        /// <summary>
        /// The default path to the qstat.exe file.
        /// </summary>
        public static readonly String DefaultQstatExePath = ".\\qstat.exe";

        /// <summary>
        /// The default path to the CoD MP exe file.
        /// </summary>
        public static readonly String DefaultCoDMPExePath = 
            @"C:\Program Files\Activision\Call of Duty 4 - Modern Warfare\iw3mp.exe";

        /// <summary>
        /// The interval (in milliseconds) of the timer used to refresh the status of the server.
        /// </summary>
        public static readonly int RefreshTimerInterval = 3000;

        /// <summary>
        /// The default server host.
        /// </summary>
        public static readonly String DefaultServerHost = "tact.greenlabeltactical.com";

        /// <summary>
        /// The default server port.
        /// </summary>
        public static readonly int DefaultServerPort = 28960;
    }
}