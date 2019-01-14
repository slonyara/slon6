using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRes
{
    class Rocket
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Distance { get; set; }
        public bool Away { get; set; }
        public bool IsStarted { get; set; }

        public Image Model;

        public Rocket(Image model)
        {
            Model = model;

            Distance = 0;
            X = 600;
            Y = 700;
        }

        public void Start()
        {
            IsStarted = true;
        }

        public void Move()
        {
            Distance++;
            Y--;

            Size size = new Size(Model.Width - 1, Model.Height - 1);
            if(size.Height > 0 && size.Width > 0)
                Model = Drawing.ResizeImg(Model, size);
            else
            {
                Away = true;
                return;
            }
            Away = (Y < -100 || X > 1500 || X < -500);
        }
    }
}
