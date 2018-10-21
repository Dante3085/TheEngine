﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.Graphics.Sprites;

namespace TheEngine.Graphics.Menu.MenuElements
{
    public abstract class AnimatedMenuElement : MenuElement
    {
        #region MemberVariables

        protected AnimatedSprite _animSprite;

        #endregion
        #region Properties

        public override int Width => _animSprite.Width;
        public override int Height => _animSprite.Height;

        public AnimatedSprite AnimatedSprite => _animSprite;

        #endregion

        protected AnimatedMenuElement(string name, AnimatedSprite animSprite, int x = 0, int y = 0, Action functionality = null) 
            : base(x, y, functionality)
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

            _animSprite._position.X = _x;
            _animSprite._position.Y = _y;
        }
        #endregion
    }
}
