using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public static bool _drawRecs = true;

        /// <summary>
        /// X Position of this MenuElement.
        /// </summary>
        protected int _x;

        /// <summary>
        /// Y Position of this MenuElement.
        /// </summary>
        protected int _y;

        /// <summary>
        /// Previous X Position. For noticing a change in X Position.
        /// </summary>
        protected int _prevX;

        /// <summary>
        /// Previous Y Position. For noticing a change in Y Position.
        /// </summary>
        protected int _prevY;

        /// <summary>
        /// Function of this MenuElement.
        /// </summary>
        protected Action _functionality;


        /// <summary>
        /// Stores if MenuCursor is on this MenuElement.
        /// </summary>
        protected bool _cursorOnIt = false;

        #endregion
        #region Properties

        /// <summary>
        /// X Position of this MenuElement.
        /// </summary>
        public int X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// Y Position of this MenuElement.
        /// </summary>
        public int Y
        {
            get => _y;
            set => _y = value;
        }

        /// <summary>
        /// Previous X Position. For noticing a change in X Position.
        /// </summary>
        public int PrevX
        {
            get => _prevX;
            set => _prevX = value;
        }

        /// <summary>
        /// Previous Y Position. For noticing a change in Y Position.
        /// </summary>
        public int PrevY
        {
            get => _prevY;
            set => _prevY = value;
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
        public abstract int Width { get; }

        /// <summary>
        /// Height of this MenuElement.
        /// </summary>
        public abstract int Height { get; }

        /// <summary>
        /// Rectangle describing the Bounds of this MenuElement.
        /// </summary>
        public abstract Rectangle Rectangle { get; }

        #endregion
        #region Methods

        protected MenuElement(int x = 0, int y = 0, Action functionality = null)
        {
            _x = x;
            _y = y;
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
            return InputManager.IsMouseHoverRectangle(Rectangle);
        }

        /// <summary>
        /// Gets whether Mouse is hovering over MenuElement and at the same time LeftMouseButton has been clicked.
        /// </summary>
        /// <returns></returns>
        public virtual bool OnLeftMouseClick()
        {
            return IsMouseHover() && InputManager.OnLeftMouseClick();
        }

        #endregion
    }
}
