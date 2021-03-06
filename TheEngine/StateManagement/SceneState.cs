﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.Graphics.Primitive;

namespace TheEngine.StateManagement
{
    /// <summary>
    /// A SceneState is a State that displays visible information, meaning that it has a
    /// backgroundTexture and other visible elements.
    /// </summary>
    public class SceneState : State
    {
        #region MemberVariables

        /// <summary>
        /// BackgroundTexture for the Scene.
        /// </summary>
        private Texture2D _background;

        /// <summary>
        /// BackgroundRectangle for defining the bounds of the BackgroundTexture.
        /// </summary>
        private RectangleF _backgroundRec;

        #endregion
        #region Methods
        public SceneState(Texture2D background, int screenWidth, int screenHeight, List<IEntity> entities, 
            List<EState> next, Action keyboardHandler = null, Action gamePadHandler = null) 
            : base(entities, next, keyboardHandler, gamePadHandler)
        {
            _background = background;
            _backgroundRec = new RectangleF(0, 0, screenWidth, screenHeight);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws backgroundTexture then calls Draw() of base class.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, _backgroundRec.Location, Color.White);
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public override void OnEnter()
        {
            base.OnEnter();
        }

        /// <summary>
        /// TODO
        /// </summary>
        public override void OnExit()
        {
            base.OnExit();
        }

        #endregion
    }
}
