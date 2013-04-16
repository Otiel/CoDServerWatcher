using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoDServerWatcher {

    /// <summary>
    /// Represents a Call of Duty map.
    /// </summary>
    internal class Map {

        #region Fields
        /// <summary>
        /// The code name of the map.
        /// </summary>
        private String codeName;

        /// <summary>
        /// The display name of the map.
        /// </summary>
        private String displayName;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the code name of the map.
        /// </summary>
        /// <value>
        /// The name of the code.
        /// </value>
        public String CodeName {
            get { return codeName; }
            set { codeName = value; }
        }

        /// <summary>
        /// Gets or sets the display name of the map.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public String DisplayName {
            get { return displayName; }
            set { displayName = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        /// <param name="codeName">Code name of the map.</param>
        public Map(String codeName) {
            this.codeName = codeName;
            this.displayName = GetDisplayName(codeName);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns the display name of the map, given its code name.
        /// </summary>
        /// <param name="codeName">Code name of the map.</param>
        private String GetDisplayName(String codeName) {
            String displayName;

            switch (codeName) {
                case "mp_convoy":      displayName = "Ambush";       break;
                case "mp_backlot":     displayName = "Backlot";      break;
                case "mp_bloc":        displayName = "Bloc";         break;
                case "mp_bog":         displayName = "Bog";          break;
                case "mp_countdown":   displayName = "Countdown";    break;
                case "mp_crash":       displayName = "Crash";        break;
                case "mp_creek":       displayName = "Creek";        break;
                case "mp_crossfire":   displayName = "Crossfire";    break;
                case "mp_citystreets": displayName = "District";     break;
                case "mp_farm":        displayName = "Downpour";     break;
                case "mp_overgrown":   displayName = "Overgrown";    break;
                case "mp_pipeline":    displayName = "Pipeline";     break;
                case "mp_shipment":    displayName = "Shipment";     break;
                case "mp_showdown":    displayName = "Showdown";     break;
                case "mp_strike":      displayName = "Strike";       break;
                case "mp_vacant":      displayName = "Vacant";       break;
                case "mp_cargoship":   displayName = "Wet Work";     break;
                case "mp_crash_snow":  displayName = "Winter Crash"; break;
                case "mp_broadcast":   displayName = "Broadcast";    break;
                case "mp_carentan":    displayName = "Chinatown";    break;
                default:               displayName = codeName;       break;
            }

            return displayName;
        }
        #endregion
    }
}