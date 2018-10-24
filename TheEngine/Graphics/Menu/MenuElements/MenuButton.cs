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

        private RectangleF _buttonRec;

        #endregion

        #region Properties

        public override float Width => _buttonRec.Width;
        public override float Height => _buttonRec.Height;

        public override RectangleF RectangleF => _buttonRec;

        #endregion

        public MenuButton(Vector2 position, Texture2D buttonTextureNoHover, Texture2D buttonTextureHover, Action functionality = null) : 
            base(position, functionality)
        {
            _buttonTextureNoHover = buttonTextureNoHover;
            _buttonTextureHover = buttonTextureHover;

            _activeButtonTexture = buttonTextureNoHover;

            _buttonRec = new RectangleF(position.X, position.Y, _activeButtonTexture.Width, _activeButtonTexture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_activeButtonTexture, _buttonRec.Location, Color.White);

            if (MenuElement._drawRecs)
                Primitives.DrawRectangleOutline(_buttonRec, _outlineLines, 
                    Contents.rectangleTex, Color.Blue, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (OnLeftMouseClick())
                ExecuteFunctionality();

            // TODO: Weiß nicht, ob alle Zuweisungen hier nötig sind. Einige aber schon. Sonst kann der Button im Layout nicht korrekt angebracht werden.
            _buttonRec.X = _position.X;
            _buttonRec.Y = _position.Y;
            _buttonRec.Width = _activeButtonTexture.Width;
            _buttonRec.Height = _activeButtonTexture.Height;
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
    }
}
