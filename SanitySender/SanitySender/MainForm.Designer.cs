namespace SaintSender
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgMail = new System.Windows.Forms.ImageList(this.components);
            this.buttonBackUp = new System.Windows.Forms.Button();
            this.mainBrowser = new System.Windows.Forms.WebBrowser();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainListView
            // 
            this.MainListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MainListView.Location = new System.Drawing.Point(12, 12);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(521, 185);
            this.MainListView.SmallImageList = this.imgMail;
            this.MainListView.TabIndex = 0;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.Click += new System.EventHandler(this.MainListView_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "From";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Subject";
            this.columnHeader2.Width = 359;
            // 
            // imgMail
            // 
            this.imgMail.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMail.ImageStream")));
            this.imgMail.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMail.Images.SetKeyName(0, "Mail (1).png");
            // 
            // buttonBackUp
            // 
            this.buttonBackUp.Location = new System.Drawing.Point(550, 134);
            this.buttonBackUp.Name = "buttonBackUp";
            this.buttonBackUp.Size = new System.Drawing.Size(75, 23);
            this.buttonBackUp.TabIndex = 2;
            this.buttonBackUp.Text = "Backup";
            this.buttonBackUp.UseVisualStyleBackColor = true;
            this.buttonBackUp.Click += new System.EventHandler(this.buttonBackUp_Click);
            // 
            // mainBrowser
            // 
            this.mainBrowser.Location = new System.Drawing.Point(12, 203);
            this.mainBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.mainBrowser.Name = "mainBrowser";
            this.mainBrowser.Size = new System.Drawing.Size(613, 349);
            this.mainBrowser.TabIndex = 4;
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(550, 163);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 23);
            this.buttonLogOut.TabIndex = 5;
            this.buttonLogOut.Text = "Logout";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 564);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.mainBrowser);
            this.Controls.Add(this.buttonBackUp);
            this.Controls.Add(this.MainListView);
            this.Enabled = false;
            this.Name = "MainForm";
            this.Text = "SaintSender";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonBackUp;
        private System.Windows.Forms.WebBrowser mainBrowser;
        private System.Windows.Forms.ImageList imgMail;
        private System.Windows.Forms.Button buttonLogOut;
    }
}

