namespace ReceiveMessages
{
    partial class Toast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toast));
            this.message = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.Location = new System.Drawing.Point(23, 60);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(448, 35);
            this.message.TabIndex = 0;
            this.message.Text = "لديك 2 مكاتبه صادره";
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // url
            // 
            this.url.AutoSize = true;
            this.url.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.url.Location = new System.Drawing.Point(23, 108);
            this.url.Name = "url";
            this.url.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.url.Size = new System.Drawing.Size(197, 16);
            this.url.TabIndex = 1;
            this.url.TabStop = true;
            this.url.Text = "192.168.1.200/api:....................";
            this.url.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.url.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.url_LinkClicked);
            // 
            // Toast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(491, 146);
            this.Controls.Add(this.url);
            this.Controls.Add(this.message);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Toast";
            this.Resizable = false;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "منظومه الارشيف الالكترونى";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Toast_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message;
        private System.Windows.Forms.LinkLabel url;
    }
}