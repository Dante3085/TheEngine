using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheEngine.Graphics.Menu.MenuComponents
{
    public class TextButton : MenuElement
    {
        #region MemberVariables

        private Text _text;
        private Rectangle _rec;

        #endregion

        #region Properties

        public override int Width { get; }
        public override int Height { get; }
        public override Rectangle Rectangle { get; }

        #endregion

        public TextButton(int x, int y, string text, Action functionality = null) 
            : base(x, y, functionality)
        {
            _text = new Text(x * 2, y * 2, text, null);
            _rec = new Rectangle(x, y, _text.Width * 2, _text.Height * 2);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _text.Update(gameTime);
            //_rec.Width = _text.Width;
            //_rec.Height = _text.Height;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Primitives.DrawRectangle(_rec, Color.DarkRed, spriteBatch, 0.5);
            _text.Draw(spriteBatch);
        }

        public override void MouseHoverReaction()
        {
            // throw new NotImplementedException();
        }

        public override void CursorReaction(GameTime gameTime)
        {
            // throw new NotImplementedException();
        }
    }
}
