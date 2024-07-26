using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Student_Information_Management
{
	public class CustButtonStyle : Button
	{
		private int BorderSize = 0;
		private int BorderRadius = 40;
		private Color BorderColor = Color.White;

		public int BorderSize1
		{ 
			get => BorderSize; 
			set { BorderSize = value;  this.Invalidate();}
		}
		public int BorderRadius1 
		{ 
			get => BorderRadius; 
			set { BorderRadius = value; this.Invalidate();}
		}
		public Color BorderColor1 
		{ 
			get => BorderColor; 
			set { BorderColor = value; this.Invalidate();}
		}
		public Color BackGroundColour
		{
			get => this.BackColor;
			set => this.BackColor = value;
		}
		public Color TextColour
		{
			get => this.ForeColor;
			set => this.ForeColor = value;
		}

		public CustButtonStyle()
		{
			this.FlatStyle = FlatStyle.Flat;
			this.FlatAppearance.BorderSize = 0;
			this.Size = new Size(150, 40);
			this.BackColor = Color.Yellow;
			this.ForeColor = Color.Black;
		}

		private GraphicsPath GetFigurePath(RectangleF Rect, float radius)
		{
			GraphicsPath path = new GraphicsPath();
			path.StartFigure();
			path.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
			path.AddArc(Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
			path.AddArc(Rect.Width - radius, Rect.Height - radius, radius, radius, 0, 90);
			path.AddArc(Rect.X, Rect.Height - radius, radius, radius, 90, 90);
			path.CloseFigure();
			return path;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			RectangleF RectSurface = new RectangleF(0, 0, this.Width, this.Height);
			RectangleF RectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1F);

			//Code for Round Button
			if (BorderRadius > 2)
			{
				using (GraphicsPath PathSurface = GetFigurePath(RectSurface, BorderRadius))
				using (GraphicsPath PathBorder = GetFigurePath(RectBorder, BorderRadius - 1F))
				using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
				using (Pen penBorder = new Pen(BorderColor, BorderSize))
				{
					penBorder.Alignment = PenAlignment.Inset;
					this.Region = new Region(PathSurface);
					e.Graphics.DrawPath(penSurface, PathSurface);

					if (BorderSize >= 1)
					{
						e.Graphics.DrawPath(penBorder, PathBorder);
					}
				}
			}
			else //Normal Button
			{
				this.Region = new Region(RectSurface);
				if (BorderRadius >= 1)
				{
					using (Pen penBorder = new Pen(BorderColor, BorderSize))
					{
						penBorder.Alignment = PenAlignment.Inset;
						e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
					}
				}
			}
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
		}

		private void Container_BackColorChanged(object sender, EventArgs e)
		{
			if (this.DesignMode)
			{
				this.Invalidate();
			}
		}
	}
}