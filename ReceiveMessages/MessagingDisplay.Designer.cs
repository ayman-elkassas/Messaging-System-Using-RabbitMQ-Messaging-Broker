namespace ReceiveMessages
{
    partial class MessagingDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessagingDisplay));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.from,
            this.to,
            this.url});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(20, 60);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.Size = new System.Drawing.Size(395, 348);
            this.dataGridView.StandardTab = true;
            this.dataGridView.TabIndex = 1;
            // 
            // from
            // 
            this.from.HeaderText = "المصدر";
            this.from.Name = "from";
            this.from.ReadOnly = true;
            this.from.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // to
            // 
            this.to.HeaderText = "موجه الى";
            this.to.Name = "to";
            this.to.ReadOnly = true;
            this.to.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // url
            // 
            this.url.ActiveLinkColor = System.Drawing.Color.White;
            this.url.HeaderText = "المكاتبه";
            this.url.Name = "url";
            this.url.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.url.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.url.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // MessagingDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackLocation = MetroFramework.Forms.BackLocation.BottomRight;
            this.ClientSize = new System.Drawing.Size(435, 428);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(920, 300);
            this.MinimizeBox = false;
            this.Name = "MessagingDisplay";
            this.Resizable = false;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MessagingDisplay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MessagingDisplay_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn from;
        private System.Windows.Forms.DataGridViewTextBoxColumn to;
        private System.Windows.Forms.DataGridViewLinkColumn url;




    }
}