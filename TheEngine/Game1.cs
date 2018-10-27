using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheEngine.DataManagement;
using TheEngine.Graphics;
using TheEngine.Graphics.EngineUIs;
using TheEngine.Graphics.Menu;
using TheEngine.Graphics.Menu.Layouts;
using TheEngine.Graphics.Menu.MenuElements;
using TheEngine.Graphics.Primitive;
using TheEngine.Graphics.Sprites;
using TheEngine.Input;
using VosSoft.Xna.GameConsole;

namespace TheEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static GameConsole gameConsole;

        #region Test

        private Texture2D sourceTexture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Color     color;

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            ScreenManager.Update();

            graphics.PreferredBackBufferWidth = ScreenManager.ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenManager.ScreenHeight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameConsole = new GameConsole(this, "german", Content);

            base.Initialize();
            InputManager.Init();
            EngineUI.Init();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Contents.graphicsDevice = GraphicsDevice;
            Contents.LoadAll(Content, GraphicsDevice);

            sourceRectangle = new Rectangle(10, 10, 200, 200);
            // destinationRectangle;
            color = new Color(255, 200, 255, 255);
            sourceTexture = Contents.Texture(sourceRectangle.Size);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ScreenManager.Update();

            InputManager.UpdateCurrentStates();

            if (InputManager.OnKeyDown(Keys.Tab))
                gameConsole.Open(Keys.Tab);

            EngineUI.Update(gameTime);

            InputManager.UpdatePreviousStates();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //EngineUI.Draw(spriteBatch);
            spriteBatch.Draw(sourceTexture, sourceRectangle, sourceRectangle, color);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
