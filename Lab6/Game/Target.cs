using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameRes
{
    public class Target
    {
        public Image Model;
        public int X { get; set; }
        public int Y { get; set; }
        public int Distance { get; }

        private bool _side; //true = слева, false = справа
        private double _a;
        private int _y0;
        private int _y1;

        public bool Away { get; set; }


        public Target(Image model)
        {
            Model = (Image)model.Clone();

            Random rnd = new Random();

            Distance = rnd.Next(70, 100);


            Size size = new Size(Model.Width - Distance * 4, Model.Height - Distance * 4);
            Model = Drawing.ResizeImg(Model, size);

            _y0 = rnd.Next(0, 200);
            _y1 = rnd.Next(0, 200);

            _side = rnd.Next(0, 2) == 1;

            Away = false;

            if (_side)
            {
                X = -550;
                Model.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else
                X = 1100;

            _a = (double)(_y1 - _y0) / 350;

        }

        public void Move()
        {
            double yy = _y0;
            if (_side)
            {
                yy += _a;
                Y = (int)Math.Round(yy, MidpointRounding.AwayFromZero);

                X++;

                Away = (X >= 1500);
            }
            else
            {
                yy += _a;
                Y = (int)Math.Round(yy, MidpointRounding.AwayFromZero);

                X--;

                Away = (X <= -550);
            }
        }
    }
}
