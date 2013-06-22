using System;
using System.Net;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Timers;

namespace CoDServerWatcher {

    public partial class FormMain: Form {

        #region Fields
        /// <summary>
        /// The timer used to refresh the display.
        /// </summary>
        private System.Timers.Timer refreshTimer;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        public FormMain() {
            InitializeComponent();

            // HACK: if the handle is not created, we will get an exception later while refreshing the notify icon. 
            // Thus, we need to show the form now in order to be able to create the handle.
            Show();
            CreateControl();

            this.Icon = Properties.Resources.IcoStarGreen;
            this.BackColor = Color.FromArgb(67, 87, 123);
            //dataGridView.BackgroundColor = Color.FromArgb(67, 87, 123);
            labelMap.ForeColor = Color.GreenYellow;

            textBoxHost.Text = Program.Server.Host;
            textBoxPort.Text = Program.Server.Port.ToString();

            this.refreshTimer = new System.Timers.Timer(Constants.RefreshTimerInterval);
            this.refreshTimer.AutoReset = true;
            this.refreshTimer.Elapsed += new ElapsedEventHandler(refreshTimer_Elapsed);
            this.refreshTimer.Start();

            SetToolTips();

            SetDataGridViewColumns();

            Task.Factory.StartNew(() => RefreshDisplay());
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets the tooltips texts.
        /// </summary>
        private void SetToolTips() {
            toolTip.SetToolTip(pictureBoxHelp, "About...");
            toolTip.SetToolTip(buttonConnect, "Launch game and connect to server");
            toolTip.SetToolTip(textBoxHost, "IP address or name");
            toolTip.SetToolTip(textBoxPort, "Port");
        }

        /// <summary>
        /// Refreshes the display.
        /// </summary>
        private void RefreshDisplay() {
            try {
                if (Program.Server.Port == 0) {
                    // Error!

                    Invoke((MethodInvoker) delegate {
                        labelServerTitle.Text = "Port must be > 0";
                        labelServerTitle.ForeColor = Color.Orange;
                        labelMap.Text = "";
                        this.Icon = Properties.Resources.IcoStarGreenWarning;
                        dataGridView.DataSource = null;
                    });
                } else {

                    Program.Server.Refresh();

                    if (Program.Server.Status == ServerStatus.Up) {
                        // Server is up

                        if (Program.Server.FreeSlot) {
                            // There is at least one free slot

                            Invoke((MethodInvoker) delegate {
                                this.Icon = Properties.Resources.IcoStarGreen;
                            });
                        } else {
                            // No free slot

                            Invoke((MethodInvoker) delegate {
                                this.Icon = Properties.Resources.IcoStarRed;
                            });
                        }

                        Invoke((MethodInvoker) delegate {
                            labelServerTitle.Text = Program.Server.Name + " - " + Program.Server.Ping + " ms";
                            labelServerTitle.ForeColor = Color.GreenYellow;
                            labelMap.Text = Program.Server.Map.DisplayName + " (" + Program.Server.PlayersCount + "/" +
                                ( Program.Server.MaxPlayers - Program.Server.PrivateClients ) + " players)";

                            // Sometimes (probably due to the timer and the different threads), the datagridview 
                            // contains all the players in duplicate
                            // Make sure we refresh the datagridview with an empty datasource to clear it
                            //dataGridView.DataSource = null;
                            //dataGridView.Refresh();

                            dataGridView.DataSource = new List<Player>(Program.Server.Players);
                        });
                    } else {
                        // Server is not reachable

                        Invoke((MethodInvoker) delegate {
                            labelServerTitle.Text = "Unable to reach server";
                            labelServerTitle.ForeColor = Color.Orange;
                            labelMap.Text = "";
                            this.Icon = Properties.Resources.IcoStarGreenWarning;
                            dataGridView.DataSource = null;
                        });
                    }
                }

                // Center labels
                Invoke((MethodInvoker) delegate {
                    labelServerTitle.Left = ( this.ClientSize.Width - labelServerTitle.Width ) / 2;
                    labelMap.Left = ( this.ClientSize.Width - labelMap.Width ) / 2;
                });
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
        /// Sets the datagridview columns.
        /// </summary>
        private void SetDataGridViewColumns() {
            dataGridView.AutoGenerateColumns = false;
            // Add columns
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {
                DataPropertyName = "Score",
                Name = "Score",
                HeaderText = "Score",
                Width = 45,
                SortMode = DataGridViewColumnSortMode.Automatic
            });
            dataGridView.Columns["Score"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {
                DataPropertyName = "Name",
                Name = "Name",
                HeaderText = "Name",
                Width = 217,
                SortMode = DataGridViewColumnSortMode.Automatic
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() {
                DataPropertyName = "Ping",
                Name = "Ping",
                HeaderText = "Ping",
                Width = 38,
                SortMode = DataGridViewColumnSortMode.Automatic
            });
            dataGridView.Columns["Ping"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        #endregion

        #region Events
        /// <summary>
        /// Handles the TextChanged event of the textBoxHost control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBoxHost_TextChanged(object sender, EventArgs e) {
            int port = 0;
            int.TryParse(textBoxPort.Text, out port);

            Program.Server.Host = textBoxHost.Text;
            Program.Server.Port = port;
        }

        /// <summary>
        /// Handles the TextChanged event of the textBoxPort control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBoxPort_TextChanged(object sender, EventArgs e) {
            int port = 0;
            int.TryParse(textBoxPort.Text, out port);

            Program.Server.Host = textBoxHost.Text;
            Program.Server.Port = port;
        }

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

            // Stop the timer while we work
            this.refreshTimer.Stop();

            // Save the host and the port in the INI file if they have changed
            if (IniValues.Host != Program.Server.Host) {
                IniFile iniFile = new IniFile(Constants.IniPath);
                iniFile.WriteKey("Server", "Host", Program.Server.Host);
                IniValues.Host = Program.Server.Host;
            }
            if (IniValues.Port != Program.Server.Port) {
                IniFile iniFile = new IniFile(Constants.IniPath);
                iniFile.WriteKey("Server", "Port", Program.Server.Port.ToString());
                IniValues.Port = Program.Server.Port;
            }

            // Refresh the display
            RefreshDisplay();

            // Now we can restart the timer
            if (refreshTimer != null) {
                // If refreshTimer == null, it means that it has been disposed somewhere
                this.refreshTimer.Start();
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonConnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonConnect_Click(object sender, EventArgs e) {
            if (!Program.Server.Connect()) {
                MessageBox.Show("An error occured. Make sure the path to the Call of Duty exe " +
                    "file registered in the configuration file (" +
                    Path.GetFullPath(Constants.IniPath) + ") is correct.",
                    "Could not start Call of Duty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                Close();
            }
        }

        /// <summary>
        /// Handles the Click event of the pictureBoxHelp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pictureBoxHelp_Click(object sender, EventArgs e) {
            var formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        /// <summary>
        /// Handles the FormClosing event of the FormMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
            this.refreshTimer.Stop();
            this.refreshTimer.Dispose();
            this.refreshTimer = null;
        }
        #endregion
    }
}
