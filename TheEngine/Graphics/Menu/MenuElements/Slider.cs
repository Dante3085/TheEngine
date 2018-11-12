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
    public class Slider : MenuElement
    { 

        private Texture2D _bar = Contents.sliderBar;
        private Texture2D _dotNoHover = Contents.sliderDot;
        private Texture2D _dotHover = Contents.sliderDot;

        private RectangleF _barBounds;
        private RectangleF _dotBounds;

        private Rectangle[] _dotBoundLines = new Rectangle[]
        {
            new Rectangle(), new Rectangle(),
            new Rectangle(), new Rectangle(),
        };

        private Rectangle[] _barBoundLines = new Rectangle[]
        {
            new Rectangle(), new Rectangle(),
            new Rectangle(), new Rectangle(),
        };

        public Slider(RectangleF bounds) 
            : base(bounds)
        {
            _barBounds = new RectangleF(0, 0, _bar.Width, _bar.Height);

            _dotBounds = new RectangleF(_bounds.X, _bounds.Y , _dotNoHover.Width, _dotNoHover.Height);

            _bounds.Width = _barBounds.Width;
            _bounds.Height = _dotBounds.Height;

            _dotBounds.Location = _bounds.Location;
            _barBounds.Location = new Vector2(_bounds.X, _bounds.Y + (_dotBounds.Height / 4f));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Game1.gameConsole.Log("DotBounds: " + _dotBounds.ToString() + "\nBarBounds: " + _barBounds.ToString());

            // Move Dot with Mouse
            if (IsLeftMouseClick())
                _dotBounds.Location = InputManager.CurrentMousePosition().ToVector2();

            // Left
            if (_dotBounds.X < _bounds.X)
                _dotBounds.X = _bounds.Y;

            // Top
            if (_dotBounds.Y < _bounds.Y - (_dotNoHover.Height / 4f))
                _dotBounds.Y = _bounds.Y - (_dotNoHover.Height / 4f);

            // Right
            if (_dotBounds.X > _bounds.X + _bounds.Width)
                _dotBounds.X = _bounds.X + _bounds.Width;

            // Bottom
            if (_dotBounds.Y > _bounds.Y + _bounds.Height)
                _dotBounds.Y = _bounds.Y + _bounds.Height;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            //if (_drawBounds)
            //{
                Primitives.DrawBounds(_dotBounds, _dotBoundLines, Contents.rectangleTex, Color.Red,
                    spriteBatch, 5);
                Primitives.DrawBounds(_barBounds, _barBoundLines, Contents.rectangleTex, Color.Red,
                    spriteBatch, 5);
            //}

            spriteBatch.Draw(_bar, _barBounds.Location, Color.White);
            spriteBatch.Draw(_dotNoHover, _dotBounds.Location, Color.White);
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
