﻿namespace Student_Information_Management
{
	partial class CustomTextBoxMainForm
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox2
			// 
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.textBox2.Location = new System.Drawing.Point(7, 7);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(236, 16);
			this.textBox2.TabIndex = 0;
			this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
			this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
			// 
			// CustomTextBoxMainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.textBox2);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.DimGray;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "CustomTextBoxMainForm";
			this.Padding = new System.Windows.Forms.Padding(7);
			this.Size = new System.Drawing.Size(250, 30);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox2;
	}
}
