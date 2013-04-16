using System;
using System.IO;

namespace CoDServerWatcher {

    /// <summary>
    /// Holds the values stored in the INI file.
    /// </summary>
    public static class IniValues {

        #region Fields
        // CallofDuty section
        private static String coDMPExePath;
        private static String coDMPExeAttributes;

        // CallofDuty section
        private static String qStatExePath;

        // Server section
        private static String host;
        private static int port;
        #endregion Fields

        #region Properties
        /// <summary>
        /// Gets or sets the path to the CoD MP exe.
        /// </summary>
        /// <value>
        /// The path to the CoD MP exe.
        /// </value>
        public static String CoDMPExePath {
            get { return coDMPExePath; }
            set { coDMPExePath = value; }
        }

        /// <summary>
        /// Gets or sets the attributes for the CoD MP exe.
        /// </summary>
        /// <value>
        /// The attributes for the CoD MP exe.
        /// </value>
        public static String CoDMPExeAttributes {
            get { return coDMPExeAttributes; }
            set { coDMPExeAttributes = value; }
        }

        /// <summary>
        /// Gets or sets the path to the QStat exe.
        /// </summary>
        /// <value>
        /// The path to the QStat exe.
        /// </value>
        public static String QStatExePath {
            get { return qStatExePath; }
            set { qStatExePath = value; }
        }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public static String Host {
            get { return host; }
            set { host = value; }
        }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public static int Port {
            get { return port; }
            set { port = value; }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Loads the INI values by reading the INI file. Returns true if all fields are filled and at the good format, 
        /// false if at least of them is not filled or at the wrong format.
        /// </summary>
        public static void LoadFromFile() {
            IniFile iniFile = new IniFile(Constants.IniPath);

            coDMPExePath       = iniFile.ReadKey("CallofDuty", "CoDMPExePath");
            coDMPExeAttributes = iniFile.ReadKey("CallofDuty", "CoDMPExeAttributes");
            qStatExePath       = iniFile.ReadKey("QStat", "QStatExePath");
            host               = iniFile.ReadKey("Server", "Host");
            port               = int.Parse(iniFile.ReadKey("Server", "Port"));
        }

        /// <summary>
        /// Checks for all fields to be present in the INI file and checks for the format of some fields. Returns true 
        /// if all fields are filled and at the good format, false if at least one of them is not filled or at the 
        /// wrong format.
        /// </summary>
        private static Boolean AreKeysCorrect() {
            IniFile iniFile = new IniFile(Constants.IniPath);
            int x;                          // Used to test integer keys in the INI file
            Boolean allKeysCorrect = true;  // Indicates if at least a key is incorrect

            // Check if each field is not empty
            if (iniFile.ReadKey("CallofDuty", "CoDMPExePath") == "") {
                allKeysCorrect = false;
            }
            if (iniFile.ReadKey("CallofDuty", "CoDMPExeAttributes") == "") {
                allKeysCorrect = false;
            }
            if (iniFile.ReadKey("QStat", "QStatExePath") == "") {
                allKeysCorrect = false;
            }
            if (iniFile.ReadKey("Server", "Host") == "") {
                allKeysCorrect = false;
            }
            if (iniFile.ReadKey("Server", "Port") == "") {
                allKeysCorrect = false;
            }

            if (!allKeysCorrect) {
                // No need to check for values format if they are possibly not filled, return now
                return false;
            }

            // Check formats
            if (!int.TryParse(iniFile.ReadKey("Server", "Port"), out x)) {
                allKeysCorrect = false;
            }

            if (!allKeysCorrect) {
                return false;
            } else {
                return true;
            }
        }
        #endregion Methods
    }
}