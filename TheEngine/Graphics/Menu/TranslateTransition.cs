using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TheEngine.Graphics.Menu.MenuElements;
using TheEngine.Utils;

namespace TheEngine.Graphics.Menu
{
    /// <summary>
    /// Moves MenuElements on X,Y-Axis.
    /// </summary>
    public class TranslateTransition
    {
        private MenuElement _menuElement;
        private Vector2 _start;
        private Vector2 _end;
        private Vector2 _velocity;
        private int _durationInMs;

        private int _counter = 0;

        private bool _active = false;

        public TranslateTransition(MenuElement menuElement, Vector2 start, Vector2 end, int durationInMs)
        {
            _menuElement = menuElement;
            _start = start;
            _end = end;
            _durationInMs = durationInMs;

            _velocity = new Vector2((_end.X - _start.X) / _durationInMs, (_end.Y - _start.Y) / _durationInMs);
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

                if (Math.Abs(_menuElement.Position.X - _end.X) < Constants.TOLERANCE &&
                    Math.Abs(_menuElement.Position.Y - _end.Y) < Constants.TOLERANCE)
                {
                    _active = false;
                    Start();
                }

                _menuElement.Position += _velocity;

                // Reset
                _counter = 0;
            }
        }

        /// <summary>
        /// Sets MenuElement to start and activates necessary code in Update method.
        /// </summary>
        public void Start()
        {
            _menuElement.Position = _start;
            _active = true;
        }
    }
}
