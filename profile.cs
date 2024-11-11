using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myMarkletplace
{
    public partial class profile : UserControl
    {
        public profile()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void profile_Load(object sender, EventArgs e)
        {

        }
        public class RoundedButton : Button
        {
            public int BorderRadius { get; set; } = 20; // Set the radius for rounded corners

            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);

                Graphics graphics = pevent.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Create a rounded rectangle path
                Rectangle buttonRect = new Rectangle(0, 0, this.Width, this.Height);
                GraphicsPath path = new GraphicsPath();
                float diameter = BorderRadius * 2f;
                path.AddArc(buttonRect.X, buttonRect.Y, diameter, diameter, 180, 90);
                path.AddArc(buttonRect.Right - diameter, buttonRect.Y, diameter, diameter, 270, 90);
                path.AddArc(buttonRect.Right - diameter, buttonRect.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(buttonRect.X, buttonRect.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();

                // Set region to rounded path for rounded corners
                this.Region = new Region(path);

                // Draw button background
                using (Brush brush = new SolidBrush(this.BackColor))
                {
                    graphics.FillPath(brush, path);
                }

                // Draw button text
                TextRenderer.DrawText(graphics, this.Text, this.Font, buttonRect, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
