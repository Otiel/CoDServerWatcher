using System;
using System.Text;
using System.Runtime.InteropServices;

namespace CoDServerWatcher {

    /// <summary>
    /// Provides methods for the creation, modification and deletion of sections and keys in an INI 
    /// file.
    /// </summary>
    public class IniFile {

        // Import Windows API
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(String section, String key, String def, 
            StringBuilder retVal, int size, String filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSection(String section, IntPtr lpReturnedString, 
            int nSize, String lpFileName);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, int nSize, 
            String lpFileName);
        [DllImport("kernel32")]
        private static extern int WritePrivateProfileSection(String section, String value, 
            String lpFileName);
        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(String section, String key, 
            String value, String lpFileName);

        #region Fields
        private String file;
        #endregion

        #region Properties
        /// <summary>
        /// Absolute path of the INI file.
        /// </summary>
        public String File {
            get { return file; }
            set { file = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the INI class.
        /// </summary>
        /// <param name="file">The absolute file path of the INI file.</param>
        public IniFile(String file) {
            this.file = file;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Removes a section and all its keys.
        /// </summary>
        /// <param name="section">The section to remove.</param>
        public void RemoveSection(String section) {
            int success = WritePrivateProfileSection(section, null, this.file);
            if (success == 0) {
                // Process failed, throw exception
                throw new ApplicationException("Failed to remove the Ini section.");
            }
        }

        /// <summary>
        /// Removes a key.
        /// </summary>
        /// <param name="section">The section containing the key to delete.</param>
        /// <param name="key">The key to delete.</param>
        public void RemoveKey(String section, String key) {
            int success = WritePrivateProfileString(section, key, null, this.file);
            if (success == 0) {
                // Process failed, throw exception
                throw new ApplicationException("Failed to remove the Ini key.");
            }
        }

        /// <summary>
        /// Writes a new key and its value. If the section does not already exist, create 
        /// it. If the key already exists, modify its value.
        /// </summary>
        /// <param name="section">The section to write the key in.</param>
        /// <param name="key">Name of the key.</param>
        /// <param name="value">Value of the key.</param>
        public void WriteKey(String section, String key, String value) {
            int success = WritePrivateProfileString(section, key, value, this.file);
            if (success == 0) {
                // Process failed, throw exception
                throw new ApplicationException("Failed to create or modify the Ini key.");
            }
        }

        /// <summary>
        /// Returns the value of a key.
        /// </summary>
        /// <param name="section">The section containing the key.</param>
        /// <param name="key">The key to read in.</param>
        public String ReadKey(String section, String key) {
            int bufferSize = 255;
            StringBuilder sb = new StringBuilder(bufferSize);
            GetPrivateProfileString(section, key, "", sb, bufferSize, this.file);
            return sb.ToString();
        }

        /// <summary>
        /// Returns all keys value of a section.
        /// </summary>
        /// <param name="section">The section to read in.</param>
        public String[] ReadSection(String section) {
            int bufferSize = 2048;
            StringBuilder returnedString = new StringBuilder();
            IntPtr pReturnedString = Marshal.AllocCoTaskMem(bufferSize);
            try {
                int bytesReturned = GetPrivateProfileSection(section, pReturnedString, bufferSize, 
                    this.file);
                for (int i = 0; i < bytesReturned - 1; i++) {
                    // We go until bytesReturned -1 to remove the last \0
                    returnedString.Append((char) Marshal.ReadByte(
                        new IntPtr((uint) pReturnedString + (uint) i)));
                }
            } finally {
                Marshal.FreeCoTaskMem(pReturnedString);
            }
            String sectionData = returnedString.ToString();
            return sectionData.Split('\0');
        }

        /// <summary>
        /// Returns all sections name.
        /// </summary>
        public String[] ReadSections() {
            int bufferSize = 2048;
            StringBuilder returnedString = new StringBuilder();
            IntPtr pReturnedString = Marshal.AllocCoTaskMem(bufferSize);
            try {
                int bytesReturned = GetPrivateProfileSectionNames(
                    pReturnedString, bufferSize, this.file);
                for (int i = 0; i < bytesReturned - 1; i++) {
                    // We go until bytesReturned -1 to remove the last \0
                    returnedString.Append((char) Marshal.ReadByte(
                        new IntPtr((uint) pReturnedString + (uint) i)));
                }
            } finally {
                Marshal.FreeCoTaskMem(pReturnedString);
            }
            String sectionData = returnedString.ToString();
            return sectionData.Split('\0');
        }
        #endregion
    }
}