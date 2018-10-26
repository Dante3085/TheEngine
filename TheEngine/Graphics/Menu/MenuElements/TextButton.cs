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
        /// Stores Texture of the TextButton.
        /// </summary>
        private Texture2D _texture;

        /// <summary>
        /// Stores opacity values for this TextButton.
        /// </summary>
        private Dictionary<string, double> _opacities = new Dictionary<string, double>()
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
        public override float Width => _bounds.Width;

        /// <summary>
        /// Returns Height of this TextButton.
        /// </summary>
        public override float Height => _bounds.Height;

        /// <summary>
        /// Returns the RectangleF describing the Bounds of this TextButton.
        /// </summary>
        public override RectangleF RectangleF => _bounds;

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
        public TextButton(RectangleF bounds, string text, Color color, Action functionality = null)
            : base(bounds, functionality)
        {
            _text = new Text(new RectangleF(bounds.Location, new Vector2()), text, () => Game1.gameConsole.Log(text + " gedrueckt."));
            _texture = Contents.Texture((int)bounds.Size.X, (int)bounds.Size.Y);
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

            // Position has changed.
            if (Math.Abs(_bounds.X - _prevPosition.X) > Constants.TOLERANCE ||
                Math.Abs(_bounds.Y - _prevPosition.Y) > Constants.TOLERANCE)
                SetTextPosition(_currentPos);

            _prevPosition.X = _bounds.X;
            _prevPosition.Y = _bounds.Y;

            _text.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Primitives.DrawRectangle(_bounds, _texture, _color, spriteBatch, _activeOpacity);
            _text.Draw(spriteBatch);

            if (MenuElement._drawRecs)
                Primitives.DrawRectangleOutline(_bounds, _outlineLines, Contents.rectangleTex,
                    Color.Red, spriteBatch);
        }

        public override void MouseHoverReaction()
        {
            _activeOpacity = InputManager.IsMouseHoverRectangle(_bounds) ?
                _opacities["hover"] : _opacities["noHover"];
        }

        public override void CursorReaction(GameTime gameTime)
        {
            // throw new NotImplementedException();
        }

        public void SetTextPosition(TextPos pos)
        {
            _currentPos = pos;
            RectangleF textBounds = _text.Bounds;
            switch (pos)
            {
                case TextPos.TopLeft:
                    {
                        textBounds.Location = new Vector2(_bounds.X, _bounds.Y);
                        break;
                    }
                case TextPos.TopCenter:
                    {
                        textBounds.Location = new Vector2(_bounds.X + (_bounds.Width / 2) - _text.RectangleF.Center.X, _bounds.Y);
                        break;
                    }
                case TextPos.TopRight:
                    {
                        textBounds.Location = new Vector2((_bounds.X + _bounds.Width) - _text.Width, _bounds.Y);
                        break;
                    }

                case TextPos.CenterLeft:
                    {
                        textBounds.Location = new Vector2(_bounds.X, _bounds.Y + (_bounds.Height / 2) - _text.RectangleF.Center.Y);
                        break;
                    }
                case TextPos.Center:
                    {
                        textBounds.Location = new Vector2(_bounds.X + (_bounds.Width / 2) - _text.RectangleF.Center.X,
                            _bounds.Y + (_bounds.Height / 2) - _text.RectangleF.Center.Y);
                        break;
                    }
                case TextPos.CenterRight:
                    {
                        textBounds.Location = new Vector2(_bounds.X + _bounds.Width, _bounds.Y + (_bounds.Height / 2));
                        break;
                    }

                case TextPos.BottomLeft:
                    {
                        textBounds.Location = new Vector2(_bounds.X, _bounds.Y + _bounds.Height - _text.Height);
                        break;
                    }

                case TextPos.BottomCenter:
                    {
                        textBounds.Location = new Vector2(_bounds.X + (_bounds.Width / 2) - _text.RectangleF.Center.X,
                            _bounds.Y + _bounds.Height - _text.Height);
                        break;
                    }

                case TextPos.BottomRight:
                    {
                        textBounds.Location = new Vector2(_bounds.X + _bounds.Width - _text.Width,
                            _bounds.Y + _bounds.Height - _text.Height);
                        break;
                    }
            }
            _text.Bounds = textBounds;
        }
        #endregion
    }
}
