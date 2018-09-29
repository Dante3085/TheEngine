using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TheEngine.DataManagement
{
    /// <summary>
    /// Utility class for storing and loading Textures and SpriteFonts.
    /// </summary>
    public static class Contents
    {
        #region Texture2Ds
    
        #region BackgroundImages

        public static Texture2D blueBackground;
        public static Texture2D ff15Background;
        public static Texture2D blackBackground;
        public static Texture2D whiteBackground;

        #endregion
        #region MenuComponents

        public static Texture2D redButtonNoHover;
        public static Texture2D redButtonHover;
        public static Texture2D btnNewGame;
        public static Texture2D glowingButton;
        public static Texture2D discoButton;
        public static Texture2D heart;
        public static Texture2D xboxButtons_A;

        #endregion
        #region Characters

        public static Texture2D warrior;
        public static Texture2D bowlingBall;
        public static Texture2D swordsman;
        public static Texture2D adventurer;

        #endregion
        #region Other

        public static Texture2D rectangleTex;

        #endregion

        #endregion
        #region SpriteFonts

        public static SpriteFont Arial12;
        public static SpriteFont Arial15;
        public static SpriteFont Arial18;
        public static SpriteFont Arial21;
        public static SpriteFont Arial24;
        public static SpriteFont Arial30;
        public static SpriteFont Arial36;
        public static SpriteFont Arial42;
        public static SpriteFont Arial48;
        public static SpriteFont Arial56;
        public static SpriteFont Arial64;
        public static SpriteFont Arial72;

        #endregion
        #region Methods
        /// <summary>
        /// Uses given ContentManager and GraphicsDevice to load all Content declared inside Contents class.
        /// </summary>
        /// <param name="c"></param>
        public static void LoadAll(ContentManager c, GraphicsDevice g)
        {
            Arial12 = c.Load<SpriteFont>("SpriteFonts/DefaultText");

            rectangleTex = new Texture2D(g, 1, 1, false, SurfaceFormat.Color);
            rectangleTex.SetData(new[] { Color.White });

            
        }

        #endregion
    }
}