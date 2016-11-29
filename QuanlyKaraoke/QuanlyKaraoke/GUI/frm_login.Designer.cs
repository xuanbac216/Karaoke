namespace QuanlyKaraoke
{
    partial class frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.btn_login_ok = new System.Windows.Forms.Button();
            this.btn_login_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(164, 243);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(154, 20);
            this.txt_username.TabIndex = 0;
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(164, 281);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(154, 20);
            this.txt_pass.TabIndex = 0;
            // 
            // btn_login_ok
            // 
            this.btn_login_ok.Location = new System.Drawing.Point(162, 319);
            this.btn_login_ok.Name = "btn_login_ok";
            this.btn_login_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_login_ok.TabIndex = 1;
            this.btn_login_ok.Text = "OK";
            this.btn_login_ok.UseVisualStyleBackColor = true;
            this.btn_login_ok.Click += new System.EventHandler(this.btn_login_ok_Click);
            // 
            // btn_login_cancel
            // 
            this.btn_login_cancel.Location = new System.Drawing.Point(243, 319);
            this.btn_login_cancel.Name = "btn_login_cancel";
            this.btn_login_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_login_cancel.TabIndex = 1;
            this.btn_login_cancel.Text = "Cancel";
            this.btn_login_cancel.UseVisualStyleBackColor = true;
            this.btn_login_cancel.Click += new System.EventHandler(this.btn_login_cancel_Click);
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(602, 383);
            this.Controls.Add(this.btn_login_cancel);
            this.Controls.Add(this.btn_login_ok);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_username);
            this.Name = "frm_login";
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Button btn_login_ok;
        private System.Windows.Forms.Button btn_login_cancel;
    }
}