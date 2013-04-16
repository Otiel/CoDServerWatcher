namespace CoDServerWatcher {
    partial class FormAbout {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBoxCoDSW = new System.Windows.Forms.PictureBox();
            this.pictureBoxCaptionFreeSlot = new System.Windows.Forms.PictureBox();
            this.labelCaptionFreeSlot = new System.Windows.Forms.Label();
            this.labelCaptionTitle = new System.Windows.Forms.Label();
            this.labelCaptionNoFreeSlot = new System.Windows.Forms.Label();
            this.pictureBoxCaptionNoFreeSlot = new System.Windows.Forms.PictureBox();
            this.labelCaptionServerNotReachable = new System.Windows.Forms.Label();
            this.pictureBoxCaptionServerNotReachable = new System.Windows.Forms.PictureBox();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoDSW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptionFreeSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptionNoFreeSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptionServerNotReachable)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(145, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(197, 20);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "CoD Server Watcher x.x.x.x";
            // 
            // pictureBoxCoDSW
            // 
            this.pictureBoxCoDSW.Image = global::CoDServerWatcher.Properties.Resources.PngStarGreen_128x128;
            this.pictureBoxCoDSW.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxCoDSW.Name = "pictureBoxCoDSW";
            this.pictureBoxCoDSW.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxCoDSW.TabIndex = 1;
            this.pictureBoxCoDSW.TabStop = false;
            // 
            // pictureBoxCaptionFreeSlot
            // 
            this.pictureBoxCaptionFreeSlot.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCaptionFreeSlot.Image")));
            this.pictureBoxCaptionFreeSlot.Location = new System.Drawing.Point(161, 88);
            this.pictureBoxCaptionFreeSlot.Name = "pictureBoxCaptionFreeSlot";
            this.pictureBoxCaptionFreeSlot.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxCaptionFreeSlot.TabIndex = 2;
            this.pictureBoxCaptionFreeSlot.TabStop = false;
            // 
            // labelCaptionFreeSlot
            // 
            this.labelCaptionFreeSlot.AutoSize = true;
            this.labelCaptionFreeSlot.Location = new System.Drawing.Point(179, 90);
            this.labelCaptionFreeSlot.Name = "labelCaptionFreeSlot";
            this.labelCaptionFreeSlot.Size = new System.Drawing.Size(113, 13);
            this.labelCaptionFreeSlot.TabIndex = 0;
            this.labelCaptionFreeSlot.Text = "At least one free slot";
            // 
            // labelCaptionTitle
            // 
            this.labelCaptionTitle.AutoSize = true;
            this.labelCaptionTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaptionTitle.Location = new System.Drawing.Point(146, 67);
            this.labelCaptionTitle.Name = "labelCaptionTitle";
            this.labelCaptionTitle.Size = new System.Drawing.Size(56, 17);
            this.labelCaptionTitle.TabIndex = 0;
            this.labelCaptionTitle.Text = "Caption:";
            // 
            // labelCaptionNoFreeSlot
            // 
            this.labelCaptionNoFreeSlot.AutoSize = true;
            this.labelCaptionNoFreeSlot.Location = new System.Drawing.Point(179, 107);
            this.labelCaptionNoFreeSlot.Name = "labelCaptionNoFreeSlot";
            this.labelCaptionNoFreeSlot.Size = new System.Drawing.Size(67, 13);
            this.labelCaptionNoFreeSlot.TabIndex = 0;
            this.labelCaptionNoFreeSlot.Text = "No free slot";
            // 
            // pictureBoxCaptionNoFreeSlot
            // 
            this.pictureBoxCaptionNoFreeSlot.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCaptionNoFreeSlot.Image")));
            this.pictureBoxCaptionNoFreeSlot.Location = new System.Drawing.Point(161, 105);
            this.pictureBoxCaptionNoFreeSlot.Name = "pictureBoxCaptionNoFreeSlot";
            this.pictureBoxCaptionNoFreeSlot.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxCaptionNoFreeSlot.TabIndex = 5;
            this.pictureBoxCaptionNoFreeSlot.TabStop = false;
            // 
            // labelCaptionServerNotReachable
            // 
            this.labelCaptionServerNotReachable.AutoSize = true;
            this.labelCaptionServerNotReachable.Location = new System.Drawing.Point(179, 124);
            this.labelCaptionServerNotReachable.Name = "labelCaptionServerNotReachable";
            this.labelCaptionServerNotReachable.Size = new System.Drawing.Size(123, 13);
            this.labelCaptionServerNotReachable.TabIndex = 0;
            this.labelCaptionServerNotReachable.Text = "Server is not reachable";
            // 
            // pictureBoxCaptionServerNotReachable
            // 
            this.pictureBoxCaptionServerNotReachable.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCaptionServerNotReachable.Image")));
            this.pictureBoxCaptionServerNotReachable.Location = new System.Drawing.Point(161, 122);
            this.pictureBoxCaptionServerNotReachable.Name = "pictureBoxCaptionServerNotReachable";
            this.pictureBoxCaptionServerNotReachable.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxCaptionServerNotReachable.TabIndex = 7;
            this.pictureBoxCaptionServerNotReachable.TabStop = false;
            // 
            // linkLabel
            // 
            this.linkLabel.ActiveLinkColor = System.Drawing.Color.Orange;
            this.linkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel.AutoSize = true;
            this.linkLabel.LinkColor = System.Drawing.Color.White;
            this.linkLabel.Location = new System.Drawing.Point(109, 32);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(233, 13);
            this.linkLabel.TabIndex = 0;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "https://github.com/Otiel/CoDServerWatcher";
            this.linkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(355, 154);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.labelCaptionServerNotReachable);
            this.Controls.Add(this.pictureBoxCaptionServerNotReachable);
            this.Controls.Add(this.labelCaptionNoFreeSlot);
            this.Controls.Add(this.pictureBoxCaptionNoFreeSlot);
            this.Controls.Add(this.labelCaptionTitle);
            this.Controls.Add(this.labelCaptionFreeSlot);
            this.Controls.Add(this.pictureBoxCaptionFreeSlot);
            this.Controls.Add(this.pictureBoxCoDSW);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About CoD Server Watcher";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoDSW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptionFreeSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptionNoFreeSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptionServerNotReachable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBoxCoDSW;
        private System.Windows.Forms.PictureBox pictureBoxCaptionFreeSlot;
        private System.Windows.Forms.Label labelCaptionFreeSlot;
        private System.Windows.Forms.Label labelCaptionTitle;
        private System.Windows.Forms.Label labelCaptionNoFreeSlot;
        private System.Windows.Forms.PictureBox pictureBoxCaptionNoFreeSlot;
        private System.Windows.Forms.Label labelCaptionServerNotReachable;
        private System.Windows.Forms.PictureBox pictureBoxCaptionServerNotReachable;
        private System.Windows.Forms.LinkLabel linkLabel;
    }
}