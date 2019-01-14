using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRes
{
    public class Drawing
    {
        public static void DrawPanel(Graphics g, string dist)
        {
            //прицел
            Pen pen = new Pen(Color.Black, 4);
            g.DrawEllipse(pen, 700, 620, 20, 20);
            g.DrawEllipse(pen, 690, 610, 40, 40);
            g.DrawEllipse(pen, 668, 588, 84, 84);
            g.DrawEllipse(pen, 648, 568, 124, 124);
            g.DrawLine(pen, 648, 630, 772, 630);
            g.DrawLine(pen, 710, 568, 710, 692);
            g.DrawLine(pen, 648, 630, 648, 705);
            g.DrawLine(pen, 772, 630, 772, 705);

            //приборная панель
            Point[] panel = new Point[] { new Point(200, 930), new Point(250, 800), new Point(700, 700), new Point(1150, 800), new Point(1200, 930) };
            g.FillClosedCurve(Brushes.DarkSlateGray, panel);

            //наполнение приборки
            g.FillRectangle(Brushes.Black, 350, 770, 170, 50);
            g.FillRectangle(Brushes.Red, 355, 775, 48, 40);
            g.FillRectangle(Brushes.Green, 410, 775, 48, 40);
            g.FillRectangle(Brushes.Yellow, 466, 775, 48, 40);

            g.FillRectangle(Brushes.Black, 860, 855, 100, 25);
            g.FillRectangle(Brushes.Black, 898, 755, 25, 100);
            g.FillEllipse(Brushes.Black, 877, 745, 65, 40);

            g.DrawEllipse(pen, 635, 725, 150, 150);
            g.FillEllipse(Brushes.DarkGreen, 635, 725, 150, 150);
            g.DrawEllipse(Pens.GreenYellow, 650, 742, 120, 120);
            g.DrawEllipse(Pens.GreenYellow, 665, 756, 90, 90);
            g.DrawEllipse(Pens.GreenYellow, 680, 771, 60, 60);
            g.DrawEllipse(Pens.GreenYellow, 695, 786, 30, 30);
            g.DrawEllipse(Pens.GreenYellow, 703, 793, 15, 15);
            g.DrawLine(Pens.GreenYellow, 635, 800, 785, 800);
            g.DrawLine(Pens.GreenYellow, 710, 725, 710, 875);

            g.FillRectangle(Brushes.Black, 305, 830, 250, 34);

            Font font = new Font(FontFamily.GenericMonospace, 13);
            g.DrawString("Расстояние до цели: " + dist, font, Brushes.White, 305, 837);

            g.Dispose();
        }

        public static Graphics DrawBackGround(Graphics g)
        {
            //g.Clear(Color.White);

            //фон
            g.FillRectangle(Brushes.CornflowerBlue, 0, 0, 1400, 930); //Заливка глубым либо CadetBlue либо CornflowerBlue

            //прицел
            Pen pen = new Pen(Color.Black, 4);
            g.DrawEllipse(pen, 700, 620, 20, 20);
            g.DrawEllipse(pen, 690, 610, 40, 40);
            g.DrawEllipse(pen, 668, 588, 84, 84);
            g.DrawEllipse(pen, 648, 568, 124, 124);
            g.DrawLine(pen, 648, 630, 772, 630);
            g.DrawLine(pen, 710, 568, 710, 692);
            g.DrawLine(pen, 648, 630, 648, 705);
            g.DrawLine(pen, 772, 630, 772, 705);

            //приборная панель
            Point[] panel = new Point[] { new Point(200, 930), new Point(250, 800), new Point(700, 700), new Point(1150, 800), new Point(1200, 930) }; 
            g.FillClosedCurve(Brushes.DarkSlateGray, panel);

            //наполнение приборки
            g.FillRectangle(Brushes.Black, 350, 800, 170, 50);
            g.FillRectangle(Brushes.Red, 355, 805, 48, 40);
            g.FillRectangle(Brushes.Green, 410, 805, 48, 40);
            g.FillRectangle(Brushes.Yellow, 466, 805, 48, 40);

            g.FillRectangle(Brushes.Black, 860, 855, 100, 25);
            g.FillRectangle(Brushes.Black, 898, 755, 25, 100);
            g.FillEllipse(Brushes.Black, 877, 745, 65, 40);

            g.DrawEllipse(pen, 635, 725, 150, 150);
            g.FillEllipse(Brushes.DarkGreen, 635, 725, 150, 150);
            g.DrawEllipse(Pens.GreenYellow, 650, 742, 120, 120);
            g.DrawEllipse(Pens.GreenYellow, 665, 756, 90, 90);
            g.DrawEllipse(Pens.GreenYellow, 680, 771, 60, 60);
            g.DrawEllipse(Pens.GreenYellow, 695, 786, 30, 30);
            g.DrawEllipse(Pens.GreenYellow, 703, 793, 15, 15);
            g.DrawLine(Pens.GreenYellow, 635, 800, 785, 800);
            g.DrawLine(Pens.GreenYellow, 710, 725, 710, 875);


            g.Dispose();
            return g;
        }

        public static Image ResizeImg(Image img, Size size)
        {
            return (Image)(new Bitmap(img, size));
        }
    }
}
