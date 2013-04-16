using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoDServerWatcher {

    internal static class QStatUtil {

        /// <summary>
        /// Returns the qstat command line output performed on a server.
        /// </summary>
        /// <param name="host">The host of the server to scan.</param>
        /// <param name="port">The port of the server to scan.</param>
        /// <returns></returns>
        public static String GetQStatOutput(String host, int port) {
            var psi = new ProcessStartInfo();
            psi.FileName = IniValues.QStatExePath;
            psi.Arguments = "-cods " + host + ":" + port + " -P -R -xml"; // -P:players -R:server rules
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;

            Process process = Process.Start(psi);
            StreamReader reader = process.StandardOutput;
            String output = reader.ReadToEnd();

            return output;
        }
    }
}