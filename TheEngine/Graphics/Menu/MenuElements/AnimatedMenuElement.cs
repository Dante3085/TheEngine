using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.Graphics.Primitive;
using TheEngine.Graphics.Sprites;

namespace TheEngine.Graphics.Menu.MenuElements
{
    public abstract class AnimatedMenuElement : MenuElement
    {
        #region MemberVariables

        protected AnimatedSprite _animSprite;

        #endregion
        #region Properties

        public override float Width => _animSprite.Width;
        public override float Height => _animSprite.Height;

        public AnimatedSprite AnimatedSprite => _animSprite;

        #endregion

        protected AnimatedMenuElement(RectangleF bounds, string name, AnimatedSprite animSprite, Action functionality = null) 
            : base(bounds, functionality)
        {
            _animSprite = animSprite;
        }

        #region Methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            _animSprite.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _animSprite.Update(gameTime);

            _animSprite._position.X = _bounds.X;
            _animSprite._position.Y = _bounds.Y;
        }
        #endregion
    }
}
