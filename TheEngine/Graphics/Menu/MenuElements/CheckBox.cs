using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.DataManagement;
using TheEngine.Graphics.Primitive;
using TheEngine.Input;

namespace TheEngine.Graphics.Menu.MenuElements
{
    /// <summary>
    /// Mehr oder weniger boolean Variable mit Schmuck.
    /// Idee: Hintere Textur gibt Hover-State an. Check-Texturen werden drübergemalt.
    /// </summary>
    public class CheckBox : MenuElement
    {
        private Texture2D _checkBoxNoHover = Contents.checkBoxNoHover;
        private Texture2D _checkBoxHover = Contents.checkBoxHover;
        private Texture2D _check = Contents.check;

        private bool _checked;

        public CheckBox(RectangleF bounds, bool check) : base (bounds)
        {
            _checked = check;
            _bounds.Size = new Vector2(_checkBoxNoHover.Bounds.Width, _checkBoxNoHover.Bounds.Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (OnLeftMouseClick())
                _checked = _checked ? false : true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsMouseHover())
            {
                if (_checked)
                {
                    spriteBatch.Draw(_checkBoxHover, _bounds.Location, Color.White);
                    spriteBatch.Draw(_check, Bounds.Location, null, 
                        Color.White, 0f, Vector2.Zero, 0.080f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(_checkBoxHover, _bounds.Location, Color.White);
                }
            }
            else
            {
                if (_checked)
                {
                    spriteBatch.Draw(_checkBoxNoHover, _bounds.Location, Color.White);
                    spriteBatch.Draw(_check, Bounds.Location, null,
                        Color.White, 0f, Vector2.Zero, 0.080f, SpriteEffects.None, 0f);
                }
                else
                    spriteBatch.Draw(_checkBoxNoHover, _bounds.Location, Color.White);
            }
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
