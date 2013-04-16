using System;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoDServerWatcher {

    /// <summary>
    /// Holds data relative to a server (current map, players...).
    /// </summary>
    internal class Server {

        #region Fields
        /// <summary>
        /// The status of the server.
        /// </summary>
        private ServerStatus status;

        /// <summary>
        /// The status of the server.
        /// </summary>
        private String host;

        /// <summary>
        /// The port of the server.
        /// </summary>
        private int port;

        /// <summary>
        /// The name of the server.
        /// </summary>
        private String name;

        /// <summary>
        /// The players currently on the server.
        /// </summary>
        private List<Player> players;

        /// <summary>
        /// The number of players currently on the server. This is usually equal to Players.Count, except on some 
        /// servers where the players list is not retrieved by qstat. This is why using this property instead of 
        /// Players.Count is advised.
        /// </summary>
        private int playersCount;

        /// <summary>
        /// The maximum number of slots for players.
        /// </summary>
        private int maxPlayers;

        /// <summary>
        /// The number of slots for players with password.
        /// </summary>
        private int privateClients;

        /// <summary>
        /// The map currently played.
        /// </summary>
        private Map map;

        /// <summary>
        /// The current ping to the server.
        /// </summary>
        private int ping;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the status of the server.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public ServerStatus Status {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Gets or sets the status of the server.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public String Host {
            get { return host; }
            set { host = value; }
        }

        /// <summary>
        /// Gets or sets the port of the server.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port {
            get { return port; }
            set { port = value; }
        }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the players currently on the server.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public List<Player> Players {
            get { return players; }
            set { players = value; }
        }

        /// <summary>
        /// Gets or sets the number of players currently on the server. This is usually equal to Players.Count, except 
        /// on some servers where the players list is not retrieved by qstat. This is why using this property instead of
        /// Players.Count is advised.
        /// </summary>
        /// <value>
        /// The the number of players currently on the server.
        /// </value>
        public int PlayersCount {
            get { return playersCount; }
            set { playersCount = value; }
        }

        /// <summary>
        /// Gets or sets the maximum number of slots for players.
        /// </summary>
        /// <value>
        /// The maximum number of slots for players.
        /// </value>
        public int MaxPlayers {
            get { return maxPlayers; }
            set { maxPlayers = value; }
        }

        /// <summary>
        /// Gets or sets the number of slots for players with password.
        /// </summary>
        /// <value>
        /// The number of slots for players with password.
        /// </value>
        public int PrivateClients {
            get { return privateClients; }
            set { privateClients = value; }
        }

        /// <summary>
        /// Gets or sets the map currently played.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public Map Map {
            get { return map; }
            set { map = value; }
        }

        /// <summary>
        /// Gets or sets the current ping to the server.
        /// </summary>
        /// <value>
        /// The ping.
        /// </value>
        public int Ping {
            get { return ping; }
            set { ping = value; }
        }

        /// <summary>
        /// True if a there is a free slot; false otherwise.
        /// </summary>
        /// <value>
        /// True or false.
        /// </value>
        public Boolean FreeSlot {
            get { return this.maxPlayers - this.privateClients > this.playersCount; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        /// <param name="host">The host of the server.</param>
        /// <param name="port">The port of the server.</param>
        public Server(String host, int port) {
            this.host = host;
            this.port = port;

            this.players = new List<Player>();
            ResetData();
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Sends a request to the server to refresh the fields value of this Server instance.
        /// </summary>
        public void Refresh() {
            ResetData();

            String qstatXml = QStatUtil.GetQStatOutput(this.host, this.port);

            var xdoc = XDocument.Parse(qstatXml);
            XElement xserver;
            try {
                xserver = xdoc.Elements().Elements().ElementAt(0);
            } catch {
                // Server host or server port is probably in the wrong format, thus the XML response is not complete

                this.status = ServerStatus.Down;
                return;
            }

            // Get server status
            this.status = xserver.Attribute("status").Value == "UP" ? ServerStatus.Up : ServerStatus.Down;

            if (this.status != ServerStatus.Up) {
                // Server is not up, no need to continue process
                return;
            }

            // Server is up, load the rest of the data
            this.name         = xserver.Element("name").Value;
            this.map          = new Map(xserver.Element("map").Value);
            this.playersCount = int.Parse(xserver.Element("numplayers").Value);
            this.maxPlayers   = int.Parse(xserver.Element("maxplayers").Value);
            this.ping         = int.Parse(xserver.Element("ping").Value);
            
            // Private clients
            foreach (XElement xrule in xserver.Element("rules").Elements()) {
                if (xrule.Attribute("name").Value == "sv_privateClients") {
                    // Found the right rule!
                    this.privateClients = int.Parse(xrule.Value);
                }
            }

            // Players
            foreach (XElement xplayer in xserver.Element("players").Elements()) {
                this.players.Add(new Player(
                    int.Parse(xplayer.Element("score").Value), 
                    int.Parse(xplayer.Element("ping").Value), 
                    xplayer.Element("name").Value));
            }
        }

        /// <summary>
        /// Starts Call Of Duty and connects to the server. Returns false if starting Call Of Duty failed.
        /// </summary>
        public Boolean Connect() {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName         = IniValues.CoDMPExePath;
            psi.Arguments        = ( IniValues.CoDMPExeAttributes != "" ? "+ " + IniValues.CoDMPExeAttributes : "" ) + 
                "+ connect " + this.host + ":" + this.port + "";
            psi.WorkingDirectory = Path.GetDirectoryName(IniValues.CoDMPExePath);

            try {
                Process.Start(psi);
            } catch (Exception) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Resets the data.
        /// </summary>
        private void ResetData() {
            this.status         = ServerStatus.Down;
            this.name           = "";
            this.players.Clear();
            this.maxPlayers     = 0;
            this.privateClients = 0;
            this.map            = null;
            this.ping           = 0;
        }
        #endregion
    }

    /// <summary>
    /// Represents the possible statuses of a server.
    /// </summary>
    internal enum ServerStatus {
        /// <summary>
        /// Indicates that the server is down.
        /// </summary>
        Down,
        /// <summary>
        /// Indicates that the server is up.
        /// </summary>
        Up
    }
}