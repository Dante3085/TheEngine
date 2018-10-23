using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TheEngine.Graphics.Menu.MenuElements;

namespace TheEngine.Graphics.Menu
{
    /// <summary>
    /// Moves MenuElements on X,Y-Axis.
    /// </summary>
    public class TranslateTransition
    {
        private MenuElement _menuElement;
        private Point _start;
        private Point _end;
        private int _durationInMs;

        private int _counter = 0;
        private int _xInc;
        private int _yInc;

        private bool _active = false;

        public TranslateTransition(MenuElement menuElement, Point start, Point end, int durationInMs)
        {
            _menuElement = menuElement;
            _start = start;
            _end = end;
            _durationInMs = durationInMs;

            _xInc = (_end.X - _start.X) / _durationInMs;
            _yInc = (_end.Y - _start.Y) / _durationInMs;

            if (_xInc == 0 && _end.X != _start.X)
                _xInc = 1;
            if (_yInc == 0 && _end.Y != _start.Y)
                _yInc = 1;
        }

        /// <summary>
        /// Works. // TODO: 51 statt 50
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (_active)
            {
                _counter += gameTime.ElapsedGameTime.Milliseconds;

                if (_menuElement.X == _end.X && _menuElement.Y == _end.Y)
                    _active = false;

                
                Game1.gameConsole.Log("xInc: " + _xInc + ", yInc: " + _yInc);

                _menuElement.X += _xInc;
                _menuElement.Y += _yInc;
                

                // Reset
                _counter = 0;
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
