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

        public static Texture2D checkBoxNoHover;
        public static Texture2D checkBoxHover;
        public static Texture2D check;

        public static Texture2D sliderBar;
        public static Texture2D sliderDot;

        #endregion
        #region Characters

        public static Texture2D warrior;
        public static Texture2D bowlingBall;
        public static Texture2D swordsman;
        public static Texture2D adventurer;

        #endregion
        #region Other

        public static Texture2D rectangleTex;
        public static Texture2D debugTexture;

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
            Arial12 = c.Load<SpriteFont>("spriteFonts/Arial12");
            Arial15 = c.Load<SpriteFont>("spriteFonts/Arial15");
            Arial18 = c.Load<SpriteFont>("spriteFonts/Arial18");
            Arial21 = c.Load<SpriteFont>("spriteFonts/Arial21");
            Arial24 = c.Load<SpriteFont>("spriteFonts/Arial24");
            Arial30 = c.Load<SpriteFont>("spriteFonts/Arial30");
            Arial36 = c.Load<SpriteFont>("spriteFonts/Arial36");
            Arial42 = c.Load<SpriteFont>("spriteFonts/Arial42");
            Arial48 = c.Load<SpriteFont>("spriteFonts/Arial48");
            Arial56 = c.Load<SpriteFont>("spriteFonts/Arial56");
            Arial64 = c.Load<SpriteFont>("spriteFonts/Arial64");
            Arial72 = c.Load<SpriteFont>("spriteFonts/Arial72");

            swordsman = c.Load<Texture2D>("characters/Swordsman");
            adventurer = c.Load<Texture2D>("characters/Adventurer");

            rectangleTex = new Texture2D(g, 1, 1, false, SurfaceFormat.Color);
            rectangleTex.SetData(new[] { Color.White });

            checkBoxNoHover = c.Load<Texture2D>("menuComponents/checkbox_noHover");
            checkBoxHover = c.Load<Texture2D>("menuComponents/checkbox_hover");
            check = c.Load<Texture2D>("menuComponents/check");

            redButtonHover = c.Load<Texture2D>("menuComponents/RedButtonHover");
            redButtonNoHover = c.Load<Texture2D>("menuComponents/RedButtonNoHover");

            sliderBar = c.Load<Texture2D>("menuComponents/SliderBar");
            sliderDot = c.Load<Texture2D>("menuComponents/SliderDot");
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

        /// <summary>
        /// Returns a Texture2D with given size.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Texture2D Texture(Point size)
        {
            return new Texture2D(graphicsDevice, size.X, size.Y);
        }

        /// <summary>
        /// Returns a Texture2D with given size.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Texture2D Texture(Vector2 size)
        {
            return new Texture2D(graphicsDevice, (int)size.X, (int)size.Y);
        }

        #endregion
    }
}