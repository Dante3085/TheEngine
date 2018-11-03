using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.DataManagement;
using TheEngine.Graphics.Primitive;

namespace TheEngine.Graphics.Menu.MenuElements
{
    public class Slider : MenuElement
    { 

        private Texture2D _bar = Contents.sliderBar;
        private Texture2D _dotNoHover = Contents.sliderDot;
        private Texture2D _dotHover = Contents.sliderDot;

        private Vector2 _dotLoc;

        public Slider(RectangleF bounds, double from, double to, double step) : base(bounds)
        {

        }

        public void Update(GameTime gameTime)
        {
            if (OnLeftMouseClick())
            {

            }

            else
            {
                _dotLoc = new Vector2(_bounds.Location.X,
                    _bounds.Location.Y - (_dotNoHover.Height - 20));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_bar, _bounds.Location, Color.White);
            spriteBatch.Draw(_dotNoHover, _dotLoc, Color.White);
        }

        public override void MouseHoverReaction()
        {
            throw new NotImplementedException();
        }

        public override void CursorReaction(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
