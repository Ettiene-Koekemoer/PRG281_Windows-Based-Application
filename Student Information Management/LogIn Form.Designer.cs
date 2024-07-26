namespace Student_Information_Management
{
	partial class frmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
			this.picBox = new System.Windows.Forms.PictureBox();
			this.grpLogin = new Student_Information_Management.CustGroupBoxStyle();
			this.chbShow = new System.Windows.Forms.CheckBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.btnSignUp = new Student_Information_Management.CustButtonStyle();
			this.btnLogIn = new Student_Information_Management.CustButtonStyle();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblUsername = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
			this.grpLogin.SuspendLayout();
			this.SuspendLayout();
			// 
			// picBox
			// 
			this.picBox.BackColor = System.Drawing.Color.Transparent;
			this.picBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.picBox.ErrorImage = null;
			this.picBox.Image = ((System.Drawing.Image)(resources.GetObject("picBox.Image")));
			this.picBox.Location = new System.Drawing.Point(446, 74);
			this.picBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.picBox.Name = "picBox";
			this.picBox.Size = new System.Drawing.Size(366, 270);
			this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picBox.TabIndex = 1;
			this.picBox.TabStop = false;
			// 
			// grpLogin
			// 
			this.grpLogin.Controls.Add(this.chbShow);
			this.grpLogin.Controls.Add(this.txtPassword);
			this.grpLogin.Controls.Add(this.txtUsername);
			this.grpLogin.Controls.Add(this.btnSignUp);
			this.grpLogin.Controls.Add(this.btnLogIn);
			this.grpLogin.Controls.Add(this.lblPassword);
			this.grpLogin.Controls.Add(this.lblUsername);
			this.grpLogin.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpLogin.Location = new System.Drawing.Point(21, 22);
			this.grpLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.grpLogin.Name = "grpLogin";
			this.grpLogin.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.grpLogin.Size = new System.Drawing.Size(399, 379);
			this.grpLogin.TabIndex = 0;
			this.grpLogin.TabStop = false;
			this.grpLogin.Text = "LOGIN";
			// 
			// chbShow
			// 
			this.chbShow.AutoSize = true;
			this.chbShow.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chbShow.Location = new System.Drawing.Point(175, 226);
			this.chbShow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.chbShow.Name = "chbShow";
			this.chbShow.Size = new System.Drawing.Size(65, 24);
			this.chbShow.TabIndex = 8;
			this.chbShow.Text = "Show";
			this.chbShow.UseVisualStyleBackColor = true;
			this.chbShow.CheckedChanged += new System.EventHandler(this.chbShow_CheckedChanged);
			// 
			// txtPassword
			// 
			this.txtPassword.BackColor = System.Drawing.Color.Black;
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPassword.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.ForeColor = System.Drawing.Color.White;
			this.txtPassword.Location = new System.Drawing.Point(175, 183);
			this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(213, 27);
			this.txtPassword.TabIndex = 7;
			this.txtPassword.Text = "Ann123!5";
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// txtUsername
			// 
			this.txtUsername.BackColor = System.Drawing.Color.Black;
			this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUsername.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUsername.ForeColor = System.Drawing.Color.White;
			this.txtUsername.Location = new System.Drawing.Point(175, 92);
			this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(213, 27);
			this.txtUsername.TabIndex = 6;
			this.txtUsername.Text = "AKritzinger";
			// 
			// btnSignUp
			// 
			this.btnSignUp.BackColor = System.Drawing.Color.Black;
			this.btnSignUp.BackGroundColour = System.Drawing.Color.Black;
			this.btnSignUp.BorderColor1 = System.Drawing.Color.Yellow;
			this.btnSignUp.BorderRadius1 = 30;
			this.btnSignUp.BorderSize1 = 2;
			this.btnSignUp.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
			this.btnSignUp.FlatAppearance.BorderSize = 0;
			this.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSignUp.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSignUp.ForeColor = System.Drawing.Color.White;
			this.btnSignUp.Location = new System.Drawing.Point(38, 296);
			this.btnSignUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnSignUp.Name = "btnSignUp";
			this.btnSignUp.Size = new System.Drawing.Size(108, 40);
			this.btnSignUp.TabIndex = 5;
			this.btnSignUp.Text = "Sign Up";
			this.btnSignUp.TextColour = System.Drawing.Color.White;
			this.btnSignUp.UseVisualStyleBackColor = false;
			this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
			// 
			// btnLogIn
			// 
			this.btnLogIn.BackColor = System.Drawing.Color.Black;
			this.btnLogIn.BackGroundColour = System.Drawing.Color.Black;
			this.btnLogIn.BorderColor1 = System.Drawing.Color.Yellow;
			this.btnLogIn.BorderRadius1 = 30;
			this.btnLogIn.BorderSize1 = 2;
			this.btnLogIn.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
			this.btnLogIn.FlatAppearance.BorderSize = 0;
			this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLogIn.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLogIn.ForeColor = System.Drawing.Color.White;
			this.btnLogIn.Location = new System.Drawing.Point(237, 296);
			this.btnLogIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnLogIn.Name = "btnLogIn";
			this.btnLogIn.Size = new System.Drawing.Size(108, 40);
			this.btnLogIn.TabIndex = 4;
			this.btnLogIn.Text = "Log In";
			this.btnLogIn.TextColour = System.Drawing.Color.White;
			this.btnLogIn.UseVisualStyleBackColor = false;
			this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPassword.Location = new System.Drawing.Point(36, 186);
			this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(88, 18);
			this.lblPassword.TabIndex = 3;
			this.lblPassword.Text = "Password:";
			// 
			// lblUsername
			// 
			this.lblUsername.AutoSize = true;
			this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsername.Location = new System.Drawing.Point(30, 96);
			this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(90, 18);
			this.lblUsername.TabIndex = 2;
			this.lblUsername.Text = "Username:";
			// 
			// frmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(834, 431);
			this.Controls.Add(this.picBox);
			this.Controls.Add(this.grpLogin);
			this.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmLogin";
			this.Text = "Login";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
			this.grpLogin.ResumeLayout(false);
			this.grpLogin.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CustGroupBoxStyle grpLogin;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblUsername;
		private CustButtonStyle btnLogIn;
		private CustButtonStyle btnSignUp;
		private System.Windows.Forms.PictureBox picBox;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.CheckBox chbShow;
    }
}