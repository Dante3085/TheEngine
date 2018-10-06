using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.DataManagement;
using TheEngine.Input;

namespace TheEngine.Graphics.Menu.MenuComponents
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
        private Rectangle _rec;

        /// <summary>
        /// Stores opacity values for this TextButton.
        /// </summary>
        private Dictionary<string , double> _opacities = new Dictionary<string, double>()
        {
            { "noHover", 0.5 },
            { "hover", 1.0 },
        };

        /// <summary>
        /// Stores opacity of this TextButton that is currently used.
        /// </summary>
        private double _activeOpacity;

        /// <summary>
        /// Stores the Color of this TextButton.
        /// </summary>
        private Color _color = Color.AliceBlue;

        /// <summary>
        /// Stores 4 Rectangles used to draw the BoundingBox of this TextButton.
        /// </summary>
        private Rectangle[] _outlineLines = new Rectangle[]
        {
            new Rectangle(), new Rectangle(),
            new Rectangle(), new Rectangle(),  
        };

        /// <summary>
        /// Stores the current Position of the Text relative to this TextButton.
        /// </summary>
        private TextPos _currentPos;

        #endregion

        #region Properties

        /// <summary>
        /// Returns Width of this TextButton.
        /// </summary>
        public override int Width => _rec.Width;

        /// <summary>
        /// Returns Height of this TextButton.
        /// </summary>
        public override int Height => _rec.Height;

        /// <summary>
        /// Returns the Rectangle describing the Bounds of this TextButton.
        /// </summary>
        public override Rectangle Rectangle => _rec;

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

        public TextButton(int x, int y, string text, Action functionality = null) 
            : base(x, y, functionality)
        {
            _text = new Text(x, y, text, () => Game1.gameConsole.Log(text + " gedrueckt."));
            _rec = new Rectangle(x, y, _text.Width * 3, _text.Height * 3);

            _activeOpacity = _opacities["noHover"];
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _rec.X = _x;
            _rec.Y = _y;

            // Position has changed.
            if (_rec.X != _prevX ||
                _rec.Y != _prevY)
                SetTextPosition(_currentPos);

            _prevX = _rec.X;
            _prevY = _rec.Y;

            _text.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Primitives.DrawRectangle(_rec, _color, spriteBatch, _activeOpacity);
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
                    _text.X = _rec.X;
                    _text.Y = _rec.Y;
                    break;
                }
                case TextPos.TopCenter:
                {
                    _text.X = _rec.X + (_rec.Width / 2) - _text.Rectangle.Center.X;
                    _text.Y = _rec.Y;
                    break;
                }
                case TextPos.TopRight:
                {
                    _text.X = (_rec.X + _rec.Width) - _text.Rectangle.Width;
                    _text.Y = _rec.Y;
                    break;
                }

                case TextPos.CenterLeft:
                {
                    _text.X = _rec.X;
                    _text.Y = _rec.Y + (_rec.Height / 2) - _text.Rectangle.Center.Y;
                    break;
                }
                case TextPos.Center:
                {
                    _text.X = _rec.X + (_rec.Width / 2) - _text.Rectangle.Center.X;
                    _text.Y = _rec.Y + (_rec.Height / 2) - _text.Rectangle.Center.Y;
                    break;
                }
                case TextPos.CenterRight:
                {
                    _text.X = _rec.X + _rec.Width;
                    _text.Y = _rec.Y + (_rec.Height / 2);
                    break;
                }

                case TextPos.BottomLeft:
                {
                    break;
                }
            }
        }
    }
}
