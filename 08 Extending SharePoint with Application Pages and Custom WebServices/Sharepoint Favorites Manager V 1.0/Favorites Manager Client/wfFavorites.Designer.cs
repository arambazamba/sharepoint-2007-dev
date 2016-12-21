namespace Integrations
{
    partial class wfFavorites
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfFavorites));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSite = new System.Windows.Forms.ComboBox();
            this.txtCollection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ilPics = new System.Windows.Forms.ImageList(this.components);
            this.pbConnected = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnected)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.btnDownload);
            this.groupBox2.Controls.Add(this.pbConnected);
            this.groupBox2.Controls.Add(this.btnUpload);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbList);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbSite);
            this.groupBox2.Controls.Add(this.txtCollection);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(25, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 176);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose your synchronization target:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(33, 143);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 12;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(473, 63);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 11;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.DownloadFavorites);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(473, 102);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 9;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.UploadFavorites);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(473, 27);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Favorites List";
            // 
            // cbList
            // 
            this.cbList.FormattingEnabled = true;
            this.cbList.Location = new System.Drawing.Point(158, 104);
            this.cbList.Name = "cbList";
            this.cbList.Size = new System.Drawing.Size(265, 21);
            this.cbList.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Site:";
            // 
            // cbSite
            // 
            this.cbSite.FormattingEnabled = true;
            this.cbSite.Location = new System.Drawing.Point(158, 65);
            this.cbSite.Name = "cbSite";
            this.cbSite.Size = new System.Drawing.Size(265, 21);
            this.cbSite.TabIndex = 2;
            this.cbSite.SelectedIndexChanged += new System.EventHandler(this.SiteSelected);
            // 
            // txtCollection
            // 
            this.txtCollection.Location = new System.Drawing.Point(158, 28);
            this.txtCollection.Name = "txtCollection";
            this.txtCollection.Size = new System.Drawing.Size(265, 20);
            this.txtCollection.TabIndex = 1;
            this.txtCollection.Text = "http://chiron";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site Collection URL:";
            // 
            // ilPics
            // 
            this.ilPics.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPics.ImageStream")));
            this.ilPics.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPics.Images.SetKeyName(0, "bullet_ball_red.png");
            this.ilPics.Images.SetKeyName(1, "bullet_ball_green.png");
            // 
            // pbConnected
            // 
            this.pbConnected.Image = global::Integrations.Properties.Resources.bullet_ball_red;
            this.pbConnected.Location = new System.Drawing.Point(438, 30);
            this.pbConnected.Name = "pbConnected";
            this.pbConnected.Size = new System.Drawing.Size(16, 16);
            this.pbConnected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbConnected.TabIndex = 10;
            this.pbConnected.TabStop = false;
            // 
            // wfFavorites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(641, 226);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "wfFavorites";
            this.Text = "Sharepoint 2007 Favorites Synchronizer";
            this.Load += new System.EventHandler(this.wfFavoritesLoad);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnected)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCollection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbList;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pbConnected;
        private System.Windows.Forms.ImageList ilPics;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label lblStatus;

    }
}