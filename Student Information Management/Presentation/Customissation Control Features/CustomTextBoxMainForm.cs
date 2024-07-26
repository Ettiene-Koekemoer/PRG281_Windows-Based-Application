using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Student_Information_Management
{
	public partial class CustomTextBoxMainForm : UserControl
	{
		private Color BorderColor = Color.DarkGray;
		private int BorderSize = 2;
		private bool UnderlineStyle = false;
		private Color borderFocusColour = Color.Yellow;
		private bool isFocused = false;

		public CustomTextBoxMainForm()
		{
			InitializeComponent();
		}

		public Color BorderColor1
		{
			get => BorderColor;
			set { BorderColor = value; this.Invalidate(); }
		}
		public int BorderSize1
		{
			get => BorderSize;
			set { BorderSize = value; this.Invalidate(); }
		}
		public bool UnderlineStyle1
		{
			get => UnderlineStyle;
			set { UnderlineStyle = value; this.Invalidate(); }
		}
		public Color BorderFocusColour
		{
			get => borderFocusColour;
			set => borderFocusColour = value;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graph = e.Graphics;

			using (Pen penBorder = new Pen(BorderColor, BorderSize))
			{
				penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

				if (!isFocused)
				{
					if (UnderlineStyle)
					{
						graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
					}
					else
					{
						graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
					}
				}
				else
				{
					penBorder.Color = borderFocusColour;
					if (UnderlineStyle)
					{
						graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
					}
					else
					{
						graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
					}
				}
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this.DesignMode)
			{
				UpdateControlHeight();
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			UpdateControlHeight();
		}

		private void UpdateControlHeight()
		{
			if (textBox2.Multiline == false)
			{
				int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
				textBox2.Multiline = true;
				textBox2.MinimumSize = new Size(0, txtHeight);
				textBox2.Multiline = false;

				this.Height = textBox2.Height + this.Padding.Top + this.Padding.Bottom;
			}
		}

		private void textBox2_Enter(object sender, EventArgs e)
		{
			isFocused = true;
			this.Invalidate();
		}

		private void textBox2_Leave(object sender, EventArgs e)
		{
			isFocused = false;
			this.Invalidate();
		}
	}
}
