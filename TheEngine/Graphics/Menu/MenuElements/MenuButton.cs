using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.DataManagement;
using TheEngine.Graphics.Primitive;

namespace TheEngine.Graphics.Menu.MenuElements
{
    public class MenuButton : MenuElement
    {
        #region MemberVariables

        private Texture2D _buttonTextureNoHover;
        private Texture2D _buttonTextureHover;
        private Texture2D _activeButtonTexture;

        #endregion
        #region Properties

        #endregion
        #region Methods
        public MenuButton(RectangleF bounds, Texture2D buttonTextureNoHover, Texture2D buttonTextureHover, Action functionality = null) : 
            base(bounds, functionality)
        {
            _buttonTextureNoHover = buttonTextureNoHover;
            _buttonTextureHover = buttonTextureHover;

            _activeButtonTexture = buttonTextureNoHover;

            _bounds.Width = _activeButtonTexture.Width;
            _bounds.Height = _activeButtonTexture.Height;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(_activeButtonTexture, _bounds.Location, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (OnLeftMouseClick())
                _functionality();

            _bounds.Width = _activeButtonTexture.Width;
            _bounds.Height = _activeButtonTexture.Height;
        }

        /// <summary>
        /// Changes activeButtonTexture on MouseHover.
        /// </summary>
        public override void MouseHoverReaction()
        {
            _activeButtonTexture = IsMouseHover() ? _buttonTextureHover : _buttonTextureNoHover;
        }

        public override void CursorReaction(GameTime gameTime)
        {
            if (_cursorOnIt)
                _activeButtonTexture = _buttonTextureHover;
        }
        #endregion
    }
}
