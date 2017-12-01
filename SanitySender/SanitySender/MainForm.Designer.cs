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
            this.buttonRestore = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonFetch = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainListView
            // 
            this.MainListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.MainListView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainListView.BackgroundImage")));
            this.MainListView.BackgroundImageTiled = true;
            this.MainListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MainListView.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainListView.Location = new System.Drawing.Point(14, 20);
            this.MainListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(608, 220);
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
            this.buttonBackUp.Enabled = false;
            this.buttonBackUp.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBackUp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonBackUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonBackUp.Image")));
            this.buttonBackUp.Location = new System.Drawing.Point(641, 171);
            this.buttonBackUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBackUp.Name = "buttonBackUp";
            this.buttonBackUp.Size = new System.Drawing.Size(88, 30);
            this.buttonBackUp.TabIndex = 2;
            this.buttonBackUp.Text = "Backup";
            this.buttonBackUp.UseVisualStyleBackColor = true;
            this.buttonBackUp.Click += new System.EventHandler(this.buttonBackUp_Click);
            // 
            // mainBrowser
            // 
            this.mainBrowser.Location = new System.Drawing.Point(14, 248);
            this.mainBrowser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainBrowser.MinimumSize = new System.Drawing.Size(24, 26);
            this.mainBrowser.Name = "mainBrowser";
            this.mainBrowser.Size = new System.Drawing.Size(715, 473);
            this.mainBrowser.TabIndex = 4;
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogOut.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLogOut.Image = ((System.Drawing.Image)(resources.GetObject("buttonLogOut.Image")));
            this.buttonLogOut.Location = new System.Drawing.Point(641, 210);
            this.buttonLogOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(88, 30);
            this.buttonLogOut.TabIndex = 5;
            this.buttonLogOut.Text = "Logout";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Enabled = false;
            this.buttonRestore.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRestore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRestore.Image = ((System.Drawing.Image)(resources.GetObject("buttonRestore.Image")));
            this.buttonRestore.Location = new System.Drawing.Point(640, 133);
            this.buttonRestore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(88, 30);
            this.buttonRestore.TabIndex = 6;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Enabled = false;
            this.buttonClear.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClear.Image = ((System.Drawing.Image)(resources.GetObject("buttonClear.Image")));
            this.buttonClear.Location = new System.Drawing.Point(641, 95);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(88, 30);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonFetch
            // 
            this.buttonFetch.Enabled = false;
            this.buttonFetch.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonFetch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonFetch.Image = ((System.Drawing.Image)(resources.GetObject("buttonFetch.Image")));
            this.buttonFetch.Location = new System.Drawing.Point(641, 58);
            this.buttonFetch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFetch.Name = "buttonFetch";
            this.buttonFetch.Size = new System.Drawing.Size(88, 30);
            this.buttonFetch.TabIndex = 8;
            this.buttonFetch.Text = "Fetch";
            this.buttonFetch.UseVisualStyleBackColor = true;
            this.buttonFetch.Click += new System.EventHandler(this.buttonFetch_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSend.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSend.Image = ((System.Drawing.Image)(resources.GetObject("buttonSend.Image")));
            this.buttonSend.Location = new System.Drawing.Point(641, 20);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(88, 30);
            this.buttonSend.TabIndex = 9;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 707);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonFetch);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.mainBrowser);
            this.Controls.Add(this.buttonBackUp);
            this.Controls.Add(this.MainListView);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonFetch;
        private System.Windows.Forms.Button buttonSend;
    }
}

