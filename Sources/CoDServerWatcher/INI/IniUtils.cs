using System;

namespace CoDServerWatcher {

    internal class IniUtils {

        /// <summary>
        /// Creates the INI file if it doesn't already exist and creates all fields if they don't already exist in the 
        /// INI file.
        /// </summary>
        public static void CreateKeys() {
            IniFile iniFile = new IniFile(Constants.IniPath);

            // CallofDuty
            if (String.IsNullOrEmpty(iniFile.ReadKey("CallofDuty", "CoDMPExePath"))) {
                iniFile.WriteKey("CallofDuty", "CoDMPExePath", Constants.DefaultCoDMPExePath);
            }
            if (String.IsNullOrEmpty(iniFile.ReadKey("CallofDuty", "CoDMPExeAttributes"))) {
                iniFile.WriteKey("CallofDuty", "CoDMPExeAttributes", "");
            }

            // QStat
            if (String.IsNullOrEmpty(iniFile.ReadKey("QStat", "QStatExePath"))) {
                iniFile.WriteKey("QStat", "QStatExePath", Constants.DefaultQstatExePath);
            }

            // Server
            if (String.IsNullOrEmpty(iniFile.ReadKey("Server", "Host"))) {
                iniFile.WriteKey("Server", "Host", Constants.DefaultServerHost);
            }
            if (String.IsNullOrEmpty(iniFile.ReadKey("Server", "Port"))) {
                iniFile.WriteKey("Server", "Port", Constants.DefaultServerPort.ToString());
            }
        }
    }
}