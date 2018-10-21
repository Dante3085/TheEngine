using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TheEngine.Graphics.Menu.MenuElements;

namespace TheEngine.Graphics.Menu
{
    public class MenuAnimation
    {
        private MenuElement _menuElement;
        private Point _start;
        private Point _end;
        private int _durationInMs;

        private int _shortTime = 0;
        private int _longTime = 0;

        private bool _active = false;

        public MenuAnimation(MenuElement menuElement, Point start, Point end, int durationInMs)
        {
            _menuElement = menuElement;
            _start = start;
            _end = end;
            _durationInMs = durationInMs;
        }

        public void Update(GameTime gameTime)
        {
            if (_active)
            {
                _shortTime += gameTime.ElapsedGameTime.Milliseconds;
                _longTime += gameTime.ElapsedGameTime.Milliseconds;

                if (_longTime >= _durationInMs)
                    _active = false;

                // Inkrement = Bewegung / Zeit
                var xInc = (_end.X - _start.X) / _durationInMs;
                var yInc = (_end.Y - _start.Y) / _durationInMs;

                if (_shortTime >= 1)
                {
                    _menuElement.X += xInc;
                    _menuElement.Y += yInc;
                }

                // Reset
                _shortTime = 0;
            }
        }

        /// <summary>
        /// Sets MenuElement to start and activates necessary code in Update method.
        /// </summary>
        public void Start()
        {
            _menuElement.X = _start.X;
            _menuElement.Y = _start.Y;
            _active = true;
        }
    }
}
