using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_Management
{
	public partial class CustTextBoxBorder : UserControl
	{
		private Color BorderColor = Color.Yellow;
		private int BorderSize = 2;
		private bool UnderlineStyle = false;
		private Color BorderFocusColour = Color.White;
		private bool isFocused = false;

		public CustTextBoxBorder()
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
		public Color BorderFocusColour1 
		{ 
			get => BorderFocusColour; 
			set => BorderFocusColour = value;
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
					penBorder.Color = BorderFocusColour;
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
			if (textBox1.Multiline == false)
			{
				int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
				textBox1.Multiline = true;
				textBox1.MinimumSize = new Size(0, txtHeight);
				textBox1.Multiline = false;

				this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
			}
		}

		private void textBox1_Enter(object sender, EventArgs e)
		{
			isFocused = true;
			this.Invalidate();
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			isFocused = false;
			this.Invalidate();
		}
	}
}
