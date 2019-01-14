using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameRes;

namespace Lab6
{
    public partial class MainScreen : Form
    {
        Bitmap bitmap;
        Graphics g;

        Bitmap exBitmap = null;

        Game _game;


        public MainScreen()
        {
            InitializeComponent();

            bitmap = new Bitmap(this.Width, this.Height);

            g = Graphics.FromImage(bitmap);

            _game = new Game(Properties.Resources.plane1, Properties.Resources.rocket2, Properties.Resources.Explosion);

            _game.FieldHasChanged += new Game.EventHandlerImage(OnFieldHasChanged);
        }

        private void OnFieldHasChanged(Image img)
        {
            Game.EventHandlerImage dlgt = Redraw2;

            if (this.InvokeRequired && this.IsHandleCreated)
            {
                //dlgt.Invoke();
                try
                {
                    Invoke(dlgt, img);
                }
                catch(Exception)
                {

                }
            }
            else
                dlgt(img);
        }

        private void Redraw2(Image img)
        {
            if (exBitmap == null)
                exBitmap = new Bitmap(this.Width, this.Height);

            Graphics exGraphics = Graphics.FromImage(exBitmap);

            exGraphics.Clear(Color.CornflowerBlue);

            _game.UpdateField(exGraphics);

            gameField.Image = exBitmap;

            exGraphics.Dispose();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Добро пожаловать в AirDefense Simulator!\nПробел -> запустить ракету\n^ -> двигать ракету вверх\nv -> двигать ракету вниз\n" +
                "> -> двигать ракету вправо\n< -> двигать ракету влево\nEnjoy!");
            _game.Start();
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            _game.FieldHasChanged -= OnFieldHasChanged;

            _game.StopThread();
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                _game.StartRocket();

            if (e.KeyCode == Keys.Up)
                _game.RocketUp();

            if (e.KeyCode == Keys.Left)
                _game.RocketLeft();

            if (e.KeyCode == Keys.Right)
                _game.RocketRight();

            if (e.KeyCode == Keys.Down)
                _game.RocketDown();
        }
    }
}
