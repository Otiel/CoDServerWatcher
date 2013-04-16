using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace CoDServerWatcher {

    public partial class FormAbout: Form {

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FormAbout"/> class.
        /// </summary>
        public FormAbout() {
            InitializeComponent();
            this.Icon = Properties.Resources.IcoStarGreen;
            this.BackColor = Color.FromArgb(67, 87, 123);
            labelTitle.Text = "CoD Server Watcher " + Assembly.GetEntryAssembly().GetName().Version;

            linkLabel.Links.Add(0, linkLabel.Text.Length, Constants.Website);
            linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_LinkClicked);
        } 
        #endregion

        #region Events
        /// <summary>
        /// Handles the LinkClicked event of the linkLabel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs" /> instance containing the event data.</param>
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            linkLabel.LinkVisited = true;
            Process.Start(Constants.Website);
        } 
        #endregion
    }
}