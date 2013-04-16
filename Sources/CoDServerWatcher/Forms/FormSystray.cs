using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CoDServerWatcher {

    public partial class FormSystray: Form {

        #region Fields
        /// <summary>
        /// The timer used to refresh the status of the server
        /// </summary>
        private System.Timers.Timer refreshTimer;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the timer used to refresh the status of the server.
        /// </summary>
        /// <value>
        /// The timer used to refresh the status of the server.
        /// </value>
        public System.Timers.Timer RefreshTimer {
            get { return refreshTimer; }
            set { refreshTimer = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FormSystray"/> class.
        /// </summary>
        public FormSystray() {
            InitializeComponent();

            // HACK: if the handle is not created, we will get an exception later while refreshing the notify icon. 
            // Thus, we need to show the form briefly in order to be able to create the handle.
            // (But the form is minimized by default and do not appear in taskbar, so... it won't show :)
            Show();
            CreateControl();
            Hide();

            this.Icon = Properties.Resources.IcoStarGreen;

            notifyIcon.Icon = Properties.Resources.IcoStarGreenWarning;
            notifyIcon.Text = Program.Server.Host + ":" + Program.Server.Port + " not reachable";

            this.refreshTimer = new System.Timers.Timer(Constants.RefreshTimerInterval);
            this.refreshTimer.AutoReset = true;
            this.refreshTimer.Elapsed += new ElapsedEventHandler(refreshTimer_Elapsed);
            this.refreshTimer.Start();

            Task.Factory.StartNew(() => RefreshDisplay());
        }
        #endregion

        #region Methods
        /// <summary>
        /// Refreshes the display.
        /// </summary>
        private void RefreshDisplay() {
            try {
                if (!this.IsHandleCreated) {
                    // Form has been closed (by user). Stop process or an exception will occur.
                    return;
                }

                if (Program.Server.Port == 0) {
                    // Error!

                    Invoke((MethodInvoker) delegate {
                        notifyIcon.Icon = Properties.Resources.IcoStarGreenWarning;
                        notifyIcon.Text = "Port must be > 0";
                    });
                } else {

                    Invoke((MethodInvoker) delegate {
                        connectToToolStripMenuItem.Text = "&Connect to " + Program.Server.Host + ":" + 
                            Program.Server.Port;
                    });

                    Program.Server.Refresh();

                    if (!this.IsHandleCreated) {
                        // Form has been closed (by user). Stop process or an exception will occur.
                        return;
                    }

                    if (Program.Server.Status == ServerStatus.Up) {
                        // Server is up

                        if (Program.Server.FreeSlot) {
                            // There is at least one free slot

                            Invoke((MethodInvoker) delegate {
                                notifyIcon.Icon = Properties.Resources.IcoStarGreen;
                            });

                            if (autoConnectToolStripMenuItem.Checked) {
                                // Auto connect is set

                                // Disable auto connect
                                autoConnectToolStripMenuItem.Checked = false;
                                // Connect server
                                if (!Program.Server.Connect()) {
                                    MessageBox.Show("An error occured. Make sure the path of the Call of Duty exe " +
                                        "file registered in the configuration file (" + 
                                        Path.GetFullPath(Constants.IniPath) + ") is correct.",
                                        "Could not start Call of Duty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        } else {
                            // No free slot

                            Invoke((MethodInvoker) delegate {
                                notifyIcon.Icon = Properties.Resources.IcoStarRed;
                            });
                        }

                        Invoke((MethodInvoker) delegate {
                            notifyIcon.Text = TrimLongServerName(Program.Server.Name) + " - " +
                                Program.Server.Map.DisplayName + " (" + Program.Server.PlayersCount + "/" +
                                ( Program.Server.MaxPlayers - Program.Server.PrivateClients ) + ")";
                        });

                    } else {
                        // Server is not reachable

                        Invoke((MethodInvoker) delegate {
                            notifyIcon.Icon = Properties.Resources.IcoStarGreenWarning;
                            notifyIcon.Text = Program.Server.Host + ":" + Program.Server.Port + " not reachable";
                        });
                    }
                }
            } catch (Exception ex) {
                if (ex is ObjectDisposedException || ex is InvalidOperationException) {
                    // Form has been closed (more likely by the user). Stop process.
                    return;
                } else {
                    throw;
                }
            }
        }

        /// <summary>
        /// Trims the name of the server if it is too long to fit in the notifyIcon.Text property (64 characters max).
        /// </summary>
        /// <param name="name">The name of the server.</param>
        /// <returns></returns>
        private String TrimLongServerName(String name) {
            int maxChars = 39; // 64 - " - Winter Crash (xxx/xxx)".Length = 64-25 = 39
            // 64 is max length of notifyIcon.Text property
            // "Winter Crash" is the longest name possible for the map

            if (name.Length > maxChars) {
                return name.Remove(maxChars - 1 - 3) + "..."; // -1 to get index, -3 cause we're adding "..."

            } else {
                return name;
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Handles the Elapsed event of the refreshTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void refreshTimer_Elapsed(object sender, ElapsedEventArgs e) {
            if (refreshTimer == null) {
                // If refreshTimer == null, it means that it has been disposed somewhere
                return;
            }

            this.refreshTimer.Stop();

            RefreshDisplay();

            if (refreshTimer != null) {
                // If refreshTimer == null, it means that it has been disposed somewhere
                this.refreshTimer.Start();
            }
        }

        /// <summary>
        /// Handles the MouseClick event of the notifyIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // Left button

                // Show main form
                FormUtil.ShowOnce<FormMain>();
            } else if (e.Button == MouseButtons.Middle) {
                // Middle button

                // Exit
                Application.Exit();
            }
        }

        /// <summary>
        /// Handles the Click event of the exitToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            // As the notify icon will stay until the user hover its mouse over it (well known Windows bug...), we 
            // will "solve" this bug here by hiding the icon
            // This will not solve the bug if the user kills our application of course, but that's a start
            notifyIcon.Visible = false;
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the connectToToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void connectToToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!Program.Server.Connect()) {
                MessageBox.Show("An error occured. Make sure the path of the Call of Duty exe " +
                    "file registered in the configuration file (" +
                    Path.GetFullPath(Constants.IniPath) + ") is correct.",
                    "Could not start Call of Duty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the openToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            FormUtil.ShowOnce<FormMain>();
        }

        /// <summary>
        /// Handles the Click event of the autoConnectToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void autoConnectToolStripMenuItem_Click(object sender, EventArgs e) {
            if (autoConnectToolStripMenuItem.Checked) {
                autoConnectToolStripMenuItem.Checked = false;
            } else {
                if (Program.Server.FreeSlot) {
                    // There is a free slot

                    DialogResult result = MessageBox.Show("There is currently a free slot, would you like \n" +
                        "to connect now to " + Program.Server.Host + "?",
                        "Connect now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) {
                        autoConnectToolStripMenuItem.Checked = false;
                        if (!Program.Server.Connect()) {
                            MessageBox.Show("An error occured. Make sure the path of the Call of Duty exe " +
                                "file registered in the configuration file (" +
                                Path.GetFullPath(Constants.IniPath) + ") is correct.",
                                "Could not start Call of Duty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                } else {
                    autoConnectToolStripMenuItem.Checked = true;
                }
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the FormSystray control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void FormSystray_FormClosing(object sender, FormClosingEventArgs e) {
            this.refreshTimer.Stop();
            this.refreshTimer.Dispose();
            this.refreshTimer = null;
        }
        #endregion
    }
}