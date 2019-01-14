using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameRes
{
    public class Game
    {
        Target _plane;
        Rocket _rocket;
        Image _planeImg;
        Image _rocketImg;
        Image _explosion;

        bool _stopThread = false;
        bool _isExplosion = false;

        Font _font;

        public delegate void EventHandlerImage(Image img);
        public event EventHandlerImage FieldHasChanged;

        public Game(Image target, Image rocket, Image explosion)
        {
            _planeImg = target;
            _rocketImg = rocket;
            _explosion = explosion;

            _font = new Font(FontFamily.GenericSerif, 10);
        }

        public void Start()
        {
            Thread threadPlane = new Thread(new ThreadStart(ThreadDraw));
            threadPlane.IsBackground = true;
            threadPlane.Start();
        }

        private void ThreadDraw()
        {
            _plane = new Target(_planeImg);
            _rocket = new Rocket(_rocketImg);

            bool hit = false;

            int c = 1;
            while (!_stopThread)
            {
                _plane.Move();

                if (c % 6 == 0 && _rocket.IsStarted)
                    _rocket.Move();

                hit = TestHitPlane(_plane, _rocket);

                if(hit)
                {
                    _isExplosion = true;
                }

                if (_plane.Away)
                    _plane = new Target(_planeImg);

                if (_rocket.Away)
                    _rocket = new Rocket(_rocketImg);

                if (!_stopThread)
                {
                    if (_isExplosion)
                    {
                        FieldHasChanged(_plane.Model);
                        Thread.Sleep(2000);
                        _isExplosion = false;
                        _plane = new Target(_planeImg);
                        _rocket = new Rocket(_rocketImg);
                    }

                    FieldHasChanged(_plane.Model);
                }

                c++;
                Thread.Sleep(3);
            }

        }

        private bool TestHitPlane(Target plane, Rocket rocket)
        {
            return plane.X + 240 >= rocket.X && plane.X <= rocket.X && plane.Y + 200 >= rocket.Y && plane.Y <= rocket.Y && plane.Distance == rocket.Distance;
        }

        
        public void UpdateField(Graphics g)
        {
            if(_plane.Distance >= _rocket.Distance)
            {
                g.DrawImage(_plane.Model, _plane.X, _plane.Y);
                g.DrawImage(_rocket.Model, _rocket.X, _rocket.Y);
            }
            else
            {
                g.DrawImage(_rocket.Model, _rocket.X, _rocket.Y);
                g.DrawImage(_plane.Model, _plane.X, _plane.Y);
            }
            

            string dist = "";
            if (_rocket != null && _plane != null)
            {
                dist = (_plane.Distance - _rocket.Distance).ToString();
            }

            if(_isExplosion)
            {
                g.DrawImage(_explosion, _plane.X - 10, _plane.Y - 10);
            }

            Drawing.DrawPanel(g, dist);
        }

        public void StopThread()
        {
            _stopThread = true;
        }

        public void StartRocket()
        {
            if (_rocket == null)
                return;

            _rocket.Start();
        }

        public void RocketUp()
        {
            if (_rocket == null || !_rocket.IsStarted)
                return;
            _rocket.Y -= 3;
        }

        public void RocketDown()
        {
            if (_rocket == null || !_rocket.IsStarted)
                return;
            _rocket.Y += 3;
        }

        public void RocketLeft()
        {
            if (_rocket == null || !_rocket.IsStarted)
                return;
            _rocket.X -= 3;
        }

        public void RocketRight()
        {
            if (_rocket == null || !_rocket.IsStarted)
                return;
            _rocket.X += 3;
        }
    }
}
