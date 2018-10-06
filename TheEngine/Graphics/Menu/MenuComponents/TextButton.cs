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
    public class TextButton : MenuElement
    {
        #region MemberVariables

        private Text _text;
        private Rectangle _rec;
        
        private Dictionary<string , double> _opacities = new Dictionary<string, double>()
        {
            { "noHover", 0.5 },
            { "hover", 1.0 },
        };

        private double _activeOpacity;
        private TextPos _currentPos;
        private Color _color = Color.AliceBlue;

        private Rectangle[] _outlineLines = new Rectangle[]
        {
            new Rectangle(), new Rectangle(),
            new Rectangle(), new Rectangle(),  
        };

        #endregion

        #region Properties

        public override int Width => _rec.Width;
        public override int Height => _rec.Height;
        public override Rectangle Rectangle => _rec;

        public Dictionary<string, double> Opacities => _opacities;

        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        #endregion

        public enum TextPos
        {
            TopLeft, TopCenter, TopRight,
            CenterLeft, Center, CenterRight,
            BottomLeft, BottomCenter, BottomRight
        }

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
