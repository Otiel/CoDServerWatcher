namespace CoDServerWatcher {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelColon = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelServerTitle = new System.Windows.Forms.Label();
            this.pictureBoxHelp = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelMap = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxHost
            // 
            this.textBoxHost.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxHost.Location = new System.Drawing.Point(18, 12);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(177, 22);
            this.textBoxHost.TabIndex = 0;
            this.textBoxHost.Text = "tact.greenlabeltactical.com";
            this.textBoxHost.TextChanged += new System.EventHandler(this.textBoxHost_TextChanged);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxPort.Location = new System.Drawing.Point(206, 12);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(50, 22);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "28960";
            this.textBoxPort.TextChanged += new System.EventHandler(this.textBoxPort_TextChanged);
            // 
            // labelColon
            // 
            this.labelColon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelColon.AutoSize = true;
            this.labelColon.ForeColor = System.Drawing.Color.White;
            this.labelColon.Location = new System.Drawing.Point(196, 15);
            this.labelColon.Name = "labelColon";
            this.labelColon.Size = new System.Drawing.Size(10, 13);
            this.labelColon.TabIndex = 0;
            this.labelColon.Text = ":";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(19, 82);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(317, 248);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.TabStop = false;
            // 
            // labelServerTitle
            // 
            this.labelServerTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelServerTitle.AutoSize = true;
            this.labelServerTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerTitle.Location = new System.Drawing.Point(170, 36);
            this.labelServerTitle.Name = "labelServerTitle";
            this.labelServerTitle.Size = new System.Drawing.Size(15, 20);
            this.labelServerTitle.TabIndex = 0;
            this.labelServerTitle.Text = "-";
            // 
            // pictureBoxHelp
            // 
            this.pictureBoxHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxHelp.Image = global::CoDServerWatcher.Properties.Resources.PngHelp;
            this.pictureBoxHelp.Location = new System.Drawing.Point(338, 332);
            this.pictureBoxHelp.Name = "pictureBoxHelp";
            this.pictureBoxHelp.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxHelp.TabIndex = 10;
            this.pictureBoxHelp.TabStop = false;
            this.pictureBoxHelp.Click += new System.EventHandler(this.pictureBoxHelp_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonConnect.Location = new System.Drawing.Point(261, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(76, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelMap
            // 
            this.labelMap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelMap.AutoSize = true;
            this.labelMap.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMap.Location = new System.Drawing.Point(170, 57);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(15, 20);
            this.labelMap.TabIndex = 11;
            this.labelMap.Text = "-";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(355, 349);
            this.Controls.Add(this.textBoxHost);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelColon);
            this.Controls.Add(this.labelServerTitle);
            this.Controls.Add(this.labelMap);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.pictureBoxHelp);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoD Server Watcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label labelColon;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelServerTitle;
        private System.Windows.Forms.PictureBox pictureBoxHelp;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelMap;
    }
}