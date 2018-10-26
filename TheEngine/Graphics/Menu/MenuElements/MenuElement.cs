using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.Graphics.Primitive;
using TheEngine.Input;

namespace TheEngine.Graphics.Menu.MenuElements
{
    /// <summary>
    /// MenuElements can be added to a Menu.
    /// </summary>
    public abstract class MenuElement : GameObject, StateManagement.IDrawable
    {
        #region MemberVariables

        /// <summary>
        /// Flag for deciding to draw all MenuElement's Rectangles.
        /// </summary>
        public static bool _drawRecs = false;

        /// <summary>
        /// Position of this MenuElement.
        /// </summary>
        protected Vector2 _position;

        /// <summary>
        /// Previous Position of this MenuElement. For checking Position change.
        /// </summary>
        protected Vector2 _prevPosition;

        /// <summary>
        /// Function of this MenuElement.
        /// </summary>
        protected Action _functionality;


        /// <summary>
        /// Stores if MenuCursor is on this MenuElement.
        /// </summary>
        protected bool _cursorOnIt = false;

        /// <summary>
        /// Stores 4 Rectangles used to draw the BoundingBox of this MenuElement.
        /// </summary>
        protected Rectangle[] _outlineLines = new Rectangle[]
        {
            new Rectangle(), new Rectangle(),
            new Rectangle(), new Rectangle(),
        };

        #endregion
        #region Properties

        /// <summary>
        /// Position of this MenuElement.
        /// </summary>
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        /// <summary>
        /// Previous Position of this MenuElement. For checking Position change.
        /// </summary>
        public Vector2 PrevPosition
        {
            get => _prevPosition;
            set => _prevPosition = value;
        }

        /// <summary>
        /// Stores if MenuCursor is on this MenuElement.
        /// </summary>
        public bool CursorOnIt
        {
            get => _cursorOnIt;
            set => _cursorOnIt = value;
        }

        /// <summary>
        /// Width of this MenuElement.
        /// </summary>
        public abstract float Width { get; }

        /// <summary>
        /// Height of this MenuElement.
        /// </summary>
        public abstract float Height { get; }

        /// <summary>
        /// RectangleF describing the Bounds of this MenuElement.
        /// </summary>
        public abstract RectangleF RectangleF { get; }

        #endregion
        #region Methods

        protected MenuElement(Vector2 position, Action functionality = null)
        {
            _position = position;
            _prevPosition = _position;
            _functionality = functionality;

            if (_functionality == null)
                _functionality = () => {};
        }

        /// <summary>
        /// Updates the MenuElement.
        /// </summary>
        public virtual void Update(GameTime gameTime)
        {
            MouseHoverReaction();
            CursorReaction(gameTime);
        }

        /// <summary>
        /// Draws the MenuElement on screen with use of SpriteBatch.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public abstract void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Override this method to describe behaviour of this MenuElement on MouseHover.
        /// </summary>
        public abstract void MouseHoverReaction();

        /// <summary>
        /// Override this method to describe behaviour of this MenuElement when a Cursor is on it.
        /// </summary>
        public abstract void CursorReaction(GameTime gameTime);

        /// <summary>
        /// Executes MenuElement's functionality.
        /// </summary>
        public virtual void ExecuteFunctionality()
        {
            if (_functionality == null)
                return;
            _functionality();
        }

        /// <summary>
        /// Changes MenuElements functionality to given functionality.
        /// </summary>
        /// <param name="functionality"></param>
        public void ChangeFunctionality(Action functionality)
        {
            _functionality = functionality;
        }

        /// <summary>
        /// Gets whether or not Mouse is hovering over this MenuElement-
        /// </summary>
        /// <returns></returns>
        public virtual bool IsMouseHover()
        {
            return InputManager.IsMouseHoverRectangle(RectangleF);
        }

        /// <summary>
        /// Gets whether Mouse is hovering over MenuElement and at the same time LeftMouseButton has been clicked(no holding).
        /// </summary>
        /// <returns></returns>
        public virtual bool OnLeftMouseClick()
        {
            return IsMouseHover() && InputManager.OnLeftMouseClick();
        }

        /// <summary>
        /// Gets whether Mouse is hovering over MenuElement and at the same time LeftMouseButton is clicked(holding).
        /// </summary>
        /// <returns></returns>
        public virtual bool IsLeftMouseClick()
        {
            return IsMouseHover() && InputManager.IsLeftMouseClick();
        }

        #endregion
    }
}
