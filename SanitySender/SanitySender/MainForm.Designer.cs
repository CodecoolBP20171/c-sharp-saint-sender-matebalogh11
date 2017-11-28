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
            this.MainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainBox = new System.Windows.Forms.TextBox();
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
            this.MainListView.Size = new System.Drawing.Size(498, 185);
            this.MainListView.TabIndex = 0;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.Click += new System.EventHandler(this.MainListView_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "From";
            this.columnHeader1.Width = 127;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Subject";
            this.columnHeader2.Width = 359;
            // 
            // MainBox
            // 
            this.MainBox.Location = new System.Drawing.Point(12, 203);
            this.MainBox.Multiline = true;
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(498, 273);
            this.MainBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 488);
            this.Controls.Add(this.MainBox);
            this.Controls.Add(this.MainListView);
            this.Enabled = false;
            this.Name = "MainForm";
            this.Text = "SaintSender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.TextBox MainBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

