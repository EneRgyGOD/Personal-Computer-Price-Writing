namespace PCPW
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPull = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.TxtBoxUrl = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.btnBoot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(160, 77);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(130, 29);
            this.btnPull.TabIndex = 0;
            this.btnPull.Text = "Pull Data";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(12, 9);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(59, 20);
            this.status.TabIndex = 1;
            this.status.Text = "STATUS";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtBoxUrl
            // 
            this.TxtBoxUrl.Location = new System.Drawing.Point(12, 44);
            this.TxtBoxUrl.Name = "TxtBoxUrl";
            this.TxtBoxUrl.Size = new System.Drawing.Size(278, 27);
            this.TxtBoxUrl.TabIndex = 3;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(12, 77);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(130, 29);
            this.btnPath.TabIndex = 4;
            this.btnPath.Text = "Choose Folder";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Location = new System.Drawing.Point(160, 112);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(130, 29);
            this.btnFileOpen.TabIndex = 5;
            this.btnFileOpen.Text = "Open File";
            this.btnFileOpen.UseVisualStyleBackColor = true;
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // btnBoot
            // 
            this.btnBoot.Location = new System.Drawing.Point(12, 112);
            this.btnBoot.Name = "btnBoot";
            this.btnBoot.Size = new System.Drawing.Size(130, 29);
            this.btnBoot.TabIndex = 6;
            this.btnBoot.Text = "Boot with Windows";
            this.btnBoot.UseVisualStyleBackColor = true;
            this.btnBoot.Click += new System.EventHandler(this.btnBoot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 153);
            this.Controls.Add(this.btnBoot);
            this.Controls.Add(this.btnFileOpen);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.TxtBoxUrl);
            this.Controls.Add(this.status);
            this.Controls.Add(this.btnPull);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(320, 200);
            this.MinimumSize = new System.Drawing.Size(320, 200);
            this.Name = "Form1";
            this.Text = "PCPW";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.TextBox TxtBoxUrl;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnFileOpen;
        private System.Windows.Forms.Button btnBoot;
    }
}

