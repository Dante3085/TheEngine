using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.DataManagement;
using TheEngine.Graphics.Menu.MenuElements;
using TheEngine.Graphics.Primitive;

namespace TheEngine.Graphics.Menu.MenuElements
{
    /// <summary>
    /// Displays Text(Also: Wrapping, Scrolling, etc.)
    /// </summary>
    public class TextBox : MenuElement
    {
        #region MemberVariables

        // TODO: size Vector, position Vector and RectangleF. Smth is wrong ?!

        private Vector2 _size;
        private List<Line> _lines;
        private Texture2D _texture;

        private int _leftPadding;
        private int _topPadding;
        private int _rightPadding;
        private int _bottomPadding;

        #endregion
        #region Properties

        public override float Width => _bounds.Width;
        public override float Height => _bounds.Height;
        public override RectangleF RectangleF => _bounds;

        #endregion
        #region Methods

        #region PrivateClasses

        private class Line
        {
            #region MemberVariables

            private RectangleF _bounds;
            private string _text;

            #endregion
            #region Properties

            public RectangleF Bounds => _bounds;
            public string Text => _text;

            #endregion
            #region Methods

            public Line(RectangleF bounds, string text)
            {
                _bounds = bounds;
                _text = text;
            }

            #endregion
        }

        #endregion

        public TextBox(RectangleF bounds, string text, int leftPadding = 0, int topPadding = 0,
            int rightPadding = 0, int bottomPadding = 0) : base(bounds)
        {
            _leftPadding = leftPadding;
            _topPadding = topPadding;
            _rightPadding = rightPadding;
            _bottomPadding = bottomPadding;

            _texture = Contents.Texture((int)bounds.X, (int)bounds.Y);

            _lines = new List<Line>()
            {
                new Line(new RectangleF(bounds.X + leftPadding, bounds.Y + topPadding, 
                    bounds.Width - (leftPadding + rightPadding), Contents.Arial12.MeasureString(text).Y), text),
            };
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Primitives.DrawRectangle(_bounds, _texture, Color.Gray, spriteBatch, 0.5);
            foreach (Line l in _lines)
                spriteBatch.DrawString(Contents.Arial12, l.Text, l.Bounds.Location, Color.White);
        }

        public override void MouseHoverReaction()
        {
            // throw new NotImplementedException();
        }

        public override void CursorReaction(GameTime gameTime)
        {
            // throw new NotImplementedException();
        }

        #endregion
    }
}