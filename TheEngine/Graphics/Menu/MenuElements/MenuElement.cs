using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.DataManagement;
using TheEngine.Graphics.Primitive;
using TheEngine.Input;

namespace TheEngine.Graphics.Menu.MenuElements
{
    // TODO: Properties "Width", "Height" could be reduced to only giving access to RectangleF bounds.

    /// <summary>
    /// MenuElements can be added to a Menu.
    /// </summary>
    public abstract class MenuElement : GameObject, StateManagement.IDrawable
    {
        #region MemberVariables

        /// <summary>
        /// Flag for deciding to draw all MenuElement's Rectangles.
        /// </summary>
        public static bool _drawBounds = true;

        /// <summary>
        /// Bounds of this MenuElement (= Position, Size).
        /// </summary>
        protected RectangleF _bounds;

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
        protected Rectangle[] _boundLines = new Rectangle[]
        {
            new Rectangle(), new Rectangle(),
            new Rectangle(), new Rectangle(),
        };

        #endregion
        #region Properties

        /// <summary>
        /// Bounds of this MenuElement (= Position, Size).
        /// </summary>
        public RectangleF Bounds
        {
            get => _bounds;
            set => _bounds = value;
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
        /// Functionality of this MenuElement.
        /// </summary>
        public Action Functionality
        {
            get => _functionality;
            set => _functionality = value;
        }

        #endregion
        #region Methods

        protected MenuElement(RectangleF bounds, Action functionality = null)
        {
            _bounds = bounds;
            _prevPosition = _bounds.Location;
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
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_drawBounds)
                Primitives.DrawBounds(_bounds, _boundLines, Contents.rectangleTex, 
                    Color.Blue, spriteBatch);
        }

        /// <summary>
        /// Override this method to describe behaviour of this MenuElement on MouseHover.
        /// </summary>
        public abstract void MouseHoverReaction();

        /// <summary>
        /// Override this method to describe behaviour of this MenuElement when a Cursor is on it.
        /// </summary>
        public abstract void CursorReaction(GameTime gameTime);

        /// <summary>
        /// Gets whether or not Mouse has entered this MenuElement(no holding/triggers once).
        /// </summary>
        /// <returns></returns>
        public bool OnMouseHover()
        {
            return InputManager.OnMouseHoverRectangle(_bounds);
        }

        /// <summary>
        /// Gets whether or not Mouse is hovering over this MenuElement(holding/triggers more than once).
        /// </summary>
        /// <returns></returns>
        public bool IsMouseHover()
        {
            return InputManager.IsMouseHoverRectangle(_bounds);
        }

        /// <summary>
        /// Gets whether Mouse is hovering over MenuElement and at the same time LeftMouseButton has been clicked(no holding).
        /// </summary>
        /// <returns></returns>
        public bool OnLeftMouseClick()
        {
            return IsMouseHover() && InputManager.OnLeftMouseClick();
        }

        /// <summary>
        /// Gets whether Mouse is hovering over MenuElement and at the same time LeftMouseButton is clicked(holding).
        /// </summary>
        /// <returns></returns>
        public bool IsLeftMouseClick()
        {
            return IsMouseHover() && InputManager.IsLeftMouseClick();
        }

        /// <summary>
        /// Gets whether Mouse is hovering over MenuElement and at the same time RightMouseButton is clicked(no holding).
        /// </summary>
        /// <returns></returns>
        public bool OnRightMouseClick()
        {
            return IsMouseHover() && InputManager.OnRightMouseClick();
        }

        /// <summary>
        /// Gets whether Mouse is hovering over MenuElement and at the same time RightMouseButton is clicked (holding).
        /// </summary>
        /// <returns></returns>
        public bool IsRightMouseClick()
        {
            return IsMouseHover() && InputManager.IsRightMouseClick();
        }

        #endregion
    }
}
