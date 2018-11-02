using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TheEngine.Graphics.Menu.MenuElements;
using TheEngine.Graphics.Primitive;
using TheEngine.Utils;

namespace TheEngine.Graphics.Menu
{
    /// <summary>
    /// Moves MenuElements on X,Y-Axis.
    /// </summary>
    public class TranslateTransition
    {
        #region MemberVariables

        /// <summary>
        /// <see cref="TheEngine.Graphics.Menu.MenuElements.MenuElement"/> that this <see cref="TheEngine.Graphics.Menu.TranslateTransition"/> is being applied on.
        /// </summary>
        private MenuElement _menuElement;

        /// <summary>
        /// Start-Position of this <see cref="TheEngine.Graphics.Menu.TranslateTransition"/>.
        /// </summary>
        private Vector2 _start;

        /// <summary>
        /// End-Position of this <see cref="TheEngine.Graphics.Menu.TranslateTransition"/>.
        /// </summary>
        private Vector2 _end;

        /// <summary>
        /// How many pixels the MenuElement moves per second.
        /// </summary>
        private float _speed;

        /// <summary>
        /// Rate at which the MenuElement's position is updated.
        /// </summary>
        private float _elapsed = 0.01f;

        /// <summary>
        /// Switch for turning the forward movement update process on and off.
        /// </summary>
        private bool _forwardMoving = false;

        /// <summary>
        /// Switch for turning backward movement update process on and off.
        /// </summary>
        private bool _backwardMoving = false;

        /// <summary>
        /// Distance between _start and _end.
        /// </summary>
        private float _distance;

        /// <summary>
        /// Direction from _start to _end.
        /// </summary>
        private Vector2 _direction;

        /// <summary>
        /// For checking how much time the TranslateTransition took/takes.
        /// </summary>
        private float _elapsedTime;

        #endregion
        #region Properties

        /// <summary>
        /// <see cref="TheEngine.Graphics.Menu.MenuElements.MenuElement"/> that this <see cref="TheEngine.Graphics.Menu.TranslateTransition"/> is being applied on.
        /// </summary>
        public MenuElement MenuElement { get => _menuElement; set => _menuElement = value; }

        /// <summary>
        /// Start-Position of this <see cref="TheEngine.Graphics.Menu.TranslateTransition"/>.
        /// While setting, recalculates internal Distance and Direction Vector2s.
        /// </summary>
        public Vector2 Start
        {
            get => _start;
            set
            {
                _start = value;
                _distance = Vector2.Distance(_start, _end);
                _direction = Vector2.Normalize(_end - _start);
            }
        }

        /// <summary>
        /// End-Position of this <see cref="TheEngine.Graphics.Menu.TranslateTransition"/>.
        /// While setting, recalculates internal Distance and Direction Vector2s.
        /// </summary>
        public Vector2 End
        {
            get => _end;
            set
            {
                _end = value;
                _distance = Vector2.Distance(_start, _end);
                _direction = Vector2.Normalize(_end - _start);
            }
        }
        public float Speed { get => _speed; set => _speed = value; }

        #endregion
        #region Methods

        /// <summary>
        /// Constructs a TranslateTransition that moves the given MenuElement from start to end with given speed(pixels per second).
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="speed"></param>
        /// <param name="menuElement"></param>
        public TranslateTransition(Vector2 start, Vector2 end, float speed, MenuElement menuElement)
        {
            _start = start;
            _end = end;
            _speed = speed;
            _menuElement = menuElement;

            _distance = Vector2.Distance(_start, _end);
            _direction = Vector2.Normalize(_end - _start);
        }

        /// <summary>
        /// Works. // TODO: 51 statt 50
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            RectangleF boundsPointer = _menuElement.Bounds;

            if (_forwardMoving)
            {
                _elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                boundsPointer.Location += _direction * _speed * _elapsed;

                if (Vector2.Distance(_start, boundsPointer.Location) >= _distance)
                {
                    boundsPointer.Location = _end;
                    _forwardMoving = false;
                }
            }

            else if (_backwardMoving)
            {
                _elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                boundsPointer.Location -= _direction * _speed * _elapsed;

                if (Vector2.Distance(_end, boundsPointer.Location) >= _distance)
                {
                    boundsPointer.Location = _start;
                    _backwardMoving = false;
                }
            }

            _menuElement.Bounds = boundsPointer;
        }

        /// <summary>
        /// Reconfigures the TranslateTransition to it's original state(i.e. restart).
        /// </summary>
        public void Forward()
        {
            _elapsedTime = 0;
            _backwardMoving = false;
            _forwardMoving = true;
        }

        public void Backward()
        {
            _elapsedTime = 0;
            _forwardMoving = false;
            _backwardMoving = true;
        }

        #endregion
    }
}
