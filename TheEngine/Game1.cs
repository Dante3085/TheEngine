using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheEngine.DataManagement;
using TheEngine.Graphics;
using TheEngine.Graphics.Menu;
using TheEngine.Graphics.Menu.Layouts;
using TheEngine.Graphics.Menu.MenuElements;
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

        private TextButton[] textBtns;
        private VBox btns;
        private TranslateTransition btnAnimation;

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

            textBtns = new TextButton[]
            {
                new TextButton(Vector2.Zero, 150, 75, "", () => gameConsole.Log("Button pressed!")),
                new TextButton(new Vector2(0, 150), 150, 75, "", () => gameConsole.Log("Button pressed!")),
                new TextButton(new Vector2(0, 300), 150, 75, "", () => gameConsole.Log("Button pressed!")),
            };
            btns = new VBox(new Vector2(-200, 0), 0, null, textBtns);
            btnAnimation = new TranslateTransition(btns.Position, new Vector2(500, 0), 2000, btns);
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

            if (InputManager.OnKeyDown(Keys.Enter))
            {
                if (InputManager.OnKeyToggle(Keys.Space))
                    btnAnimation.Backward();
                else
                    btnAnimation.Forward();
            }

            btns.Update(gameTime);

            btnAnimation.Update(gameTime);

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

            btns.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
