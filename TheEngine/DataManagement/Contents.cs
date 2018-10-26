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
        public static GraphicsDevice graphicsDevice;

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
            Arial12 = c.Load<SpriteFont>("SpriteFonts/Arial12");
            Arial15 = c.Load<SpriteFont>("SpriteFonts/Arial15");
            Arial18 = c.Load<SpriteFont>("SpriteFonts/Arial18");
            Arial21 = c.Load<SpriteFont>("SpriteFonts/Arial21");
            Arial24 = c.Load<SpriteFont>("SpriteFonts/Arial24");
            Arial30 = c.Load<SpriteFont>("SpriteFonts/Arial30");
            Arial36 = c.Load<SpriteFont>("SpriteFonts/Arial36");
            Arial42 = c.Load<SpriteFont>("SpriteFonts/Arial42");
            Arial48 = c.Load<SpriteFont>("SpriteFonts/Arial48");
            Arial56 = c.Load<SpriteFont>("SpriteFonts/Arial56");
            Arial64 = c.Load<SpriteFont>("SpriteFonts/Arial64");
            Arial72 = c.Load<SpriteFont>("SpriteFonts/Arial72");

            adventurer = c.Load<Texture2D>("Adventurer/adventurer-Sheet");

            rectangleTex = new Texture2D(g, 1, 1, false, SurfaceFormat.Color);
            rectangleTex.SetData(new[] { Color.White });

        }

        /// <summary>
        /// Returns a Texture2D with given width and height.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Texture2D Texture(int width, int height)
        {
            return new Texture2D(graphicsDevice, width, height);
        }

        #endregion
    }
}