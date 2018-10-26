using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.DataManagement;
using TheEngine.Graphics.Primitive;
using TheEngine.Input;
using TheEngine.Utils;

namespace TheEngine.Graphics.Menu.MenuElements
{
    /// <summary>
    /// UI-Button with Text.
    /// </summary>
    public class TextButton : MenuElement
    {
        #region MemberVariables

        /// <summary>
        /// Visible Text of this TextButton.
        /// </summary>
        private Text _text;

        /// <summary>
        /// Describes the Bounds of this TextButton.
        /// </summary>
        private RectangleF _rec;

        /// <summary>
        /// Stores Texture of the TextButton.
        /// </summary>
        private Texture2D _texture;

        /// <summary>
        /// Stores opacity values for this TextButton.
        /// </summary>
        private Dictionary<string , double> _opacities = new Dictionary<string, double>()
        {
            { "noHover", 0.5 },
            { "hover", 0.75 },
            { "click", 1.0 },
        };

        /// <summary>
        /// Stores opacity of this TextButton that is currently used.
        /// </summary>
        private double _activeOpacity;

        /// <summary>
        /// Stores the Color of this TextButton.
        /// </summary>
        private Color _color;

        /// <summary>
        /// Stores the current Position of the Text relative to this TextButton.
        /// </summary>
        private TextPos _currentPos;

        #endregion
        #region Properties

        /// <summary>
        /// Returns Width of this TextButton.
        /// </summary>
        public override float Width => _rec.Width;

        /// <summary>
        /// Returns Height of this TextButton.
        /// </summary>
        public override float Height => _rec.Height;

        /// <summary>
        /// Returns the RectangleF describing the Bounds of this TextButton.
        /// </summary>
        public override RectangleF RectangleF => _rec;

        /// <summary>
        /// Returns a Dictionary storing Opacity values for this TextButton.
        /// </summary>
        public Dictionary<string, double> Opacities => _opacities;

        /// <summary>
        /// Returns the Color of this TextButton.
        /// </summary>
        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        /// <summary>
        /// Returns the Text of this TextButton.
        /// </summary>
        public Text Text
        {
            get => _text;
            set => _text = value;
        }

        #endregion
        #region Enums

        public enum TextPos
        {
            TopLeft, TopCenter, TopRight,
            CenterLeft, Center, CenterRight,
            BottomLeft, BottomCenter, BottomRight
        }

        #endregion
        #region Methods
        public TextButton(Vector2 position, Vector2 size, string text, Color color, Action functionality = null) 
            : base(position, functionality)
        {
            _text = new Text(position, text, () => Game1.gameConsole.Log(text + " gedrueckt."));
            _rec = new RectangleF(position.X, position.Y, size.X, size.Y);
            _texture = Contents.Texture((int)size.X, (int)size.Y);
            _color = color;


            _activeOpacity = _opacities["noHover"];
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (IsLeftMouseClick())
                _activeOpacity = _opacities["click"];

            if (OnLeftMouseClick())
                _functionality();

            _rec.X = _position.X;
            _rec.Y = _position.Y;

            // Position has changed.
            if (Math.Abs(_rec.X - _prevPosition.X) > Constants.TOLERANCE ||
                Math.Abs(_rec.Y - _prevPosition.Y) > Constants.TOLERANCE)
                SetTextPosition(_currentPos);

            _prevPosition.X = _rec.X;
            _prevPosition.Y = _rec.Y;

            _text.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Primitives.DrawRectangle(_rec, _texture, _color, spriteBatch, _activeOpacity);
            _text.Draw(spriteBatch);

            if (MenuElement._drawRecs)
                Primitives.DrawRectangleOutline(_rec, _outlineLines, Contents.rectangleTex, 
                    Color.Red, spriteBatch);
        }

        public override void MouseHoverReaction()
        {
            _activeOpacity = InputManager.IsMouseHoverRectangle(_rec) ? 
                _opacities["hover"] : _opacities["noHover"];
        }

        public override void CursorReaction(GameTime gameTime)
        {
            // throw new NotImplementedException();
        }

        public void SetTextPosition(TextPos pos)
        {
            _currentPos = pos;
            switch (pos)
            {
                case TextPos.TopLeft:
                {
                    _text.Position = new Vector2(_rec.X, _rec.Y);
                    break;
                }
                case TextPos.TopCenter:
                {
                    _text.Position = new Vector2(_rec.X + (_rec.Width / 2) - _text.RectangleF.Center.X, _rec.Y);
                    break;
                }
                case TextPos.TopRight:
                {
                    _text.Position = new Vector2((_rec.X + _rec.Width) - _text.Width, _rec.Y);
                    break;
                }

                case TextPos.CenterLeft:
                {
                    _text.Position = new Vector2(_rec.X, _rec.Y + (_rec.Height / 2) - _text.RectangleF.Center.Y);
                    break;
                }
                case TextPos.Center:
                {
                    _text.Position = new Vector2(_rec.X + (_rec.Width / 2) - _text.RectangleF.Center.X,
                                                 _rec.Y + (_rec.Height / 2) - _text.RectangleF.Center.Y);
                    break;
                }
                case TextPos.CenterRight:
                {
                    _text.Position = new Vector2(_rec.X + _rec.Width, _rec.Y + (_rec.Height / 2));
                    break;
                }

                case TextPos.BottomLeft:
                {
                    _text.Position = new Vector2(_rec.X, _rec.Y + _rec.Height - _text.Height);
                    break;
                }

                case TextPos.BottomCenter:
                {
                    _text.Position = new Vector2(_rec.X + (_rec.Width / 2) - _text.RectangleF.Center.X,
                                                 _rec.Y + _rec.Height - _text.Height);
                    break;
                }

                case TextPos.BottomRight:
                {
                    _text.Position = new Vector2(_rec.X + _rec.Width - _text.Width, 
                                                 _rec.Y + _rec.Height - _text.Height);
                    break;
                }
            }
        }
        #endregion
    }
}
