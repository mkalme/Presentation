using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Presentation
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics bitmapGraphics;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            updateGraphics();
        }

        private void updateGraphics() {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bitmapGraphics = Graphics.FromImage(bmp);

            LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(new Point(0, 0) , new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)),
                ColorTranslator.FromHtml("#535659"),
                ColorTranslator.FromHtml("#535659"),
                90F
            );

            bitmapGraphics.FillRectangle(brush, ClientRectangle);//load gradient background

            //load page
            SizeF size = new SizeF(1000, 700);
            PointF location = new PointF((bmp.Width - size.Width) / 2, (bmp.Height - size.Height) / 2 );

            Pen pen = new Pen(Color.Black, 1);
            pen.Alignment = PenAlignment.Inset;

            bitmapGraphics.FillRectangle(new SolidBrush(Color.White), new RectangleF(location, size));
            bitmapGraphics.DrawRectangle(pen, new Rectangle(new Point((int)location.X, (int)location.Y), new Size((int)(size.Width) + 1, (int)(size.Height) + 1)));

            pictureBox1.Image = bmp;
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            updateGraphics();
        }
    }
}
