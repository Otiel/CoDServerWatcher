using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoDServerWatcher {

    /// <summary>
    /// Represents a player.
    /// </summary>
    internal class Player {

        #region Fields
        /// <summary>
        /// The score of the player.
        /// </summary>
        private int score;

        /// <summary>
        /// The ping of the player.
        /// </summary>
        private int ping;

        /// <summary>
        /// The name of the player.
        /// </summary>
        private String name; 
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the score of the player.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public int Score {
            get { return score; }
            set { score = value; }
        }

        /// <summary>
        /// Gets or sets the ping of the player.
        /// </summary>
        /// <value>
        /// The ping.
        /// </value>
        public int Ping {
            get { return ping; }
            set { ping = value; }
        }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name {
            get { return name; }
            set { name = value; }
        } 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="score">The score.</param>
        /// <param name="ping">The ping.</param>
        /// <param name="name">The name.</param>
        public Player(int score, int ping, String name) {
            this.score = score;
            this.ping = ping;
            this.name = name;
        } 
        #endregion
    }
}