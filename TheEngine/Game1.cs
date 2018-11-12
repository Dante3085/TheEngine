using System;
using System.Collections.Generic;
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

        private AnimatedSprite animSprite;
        private Slider slider;

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;

            ScreenManager.Update();

            graphics.PreferredBackBufferWidth = 3000;
            graphics.PreferredBackBufferHeight = 2000;

            // graphics.IsFullScreen = true;
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
            gameConsole.IsFullscreen = true;
            gameConsole.BackgroundAlpha = 0.0f;

            gameConsole.SetLogLevelColor(1, Color.White);
            gameConsole.SetLogLevelColor(2, Color.Blue);
            gameConsole.SetLogLevelColor(3, Color.Red);
            gameConsole.SetLogLevelColor(4, Color.Violet);
            gameConsole.SetLogLevelColor(5, Color.DarkMagenta);

            base.Initialize();
            InputManager.Init();
            EngineUI.Init(NewKeyboardInput.Default());
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

            //animSprite = new AnimatedSprite("sprite", Contents.swordsman, 48, 43, Vector2.Zero, fps : 10, 
            //    keyboardInput: KeyboardInput.Default());

            AnimatedSprite swordsman = new AnimatedSprite
                ("Swordsman", Contents.swordsman, 48, 43 , Vector2.Zero, 
                PlayerIndex.One, isInteractable: true, keyboardInput: KeyboardInput.None());

            // Idle Animation that is played on startup
            swordsman.AddAnimation(EAnimation.Idle, 4, 48, 43, 433, 0, new Vector2(0, 0), 5);

            // Idle Animations for each direction.
            swordsman.AddAnimation(EAnimation.IdleLeft, 4, 48, 43, 528, 4, new Vector2(0, 0), 5);
            swordsman.AddAnimation(EAnimation.IdleUp, 4, 48, 43, 528, 0, new Vector2(0, 0), 5);
            swordsman.AddAnimation(EAnimation.IdleRight, 4, 48, 43, 480, 0, new Vector2(0, 0), 5);
            swordsman.AddAnimation(EAnimation.IdleDown, 4, 48, 43, 433, 0, new Vector2(0, 0), 5);

            // Movement Animations for each direction.
            swordsman.AddAnimation(EAnimation.Left, 8, 50, 50, 100, 0, new Vector2(0, 0), 12);
            swordsman.AddAnimation(EAnimation.Up, 12, 50, 50, 50, 0, new Vector2(0, 0), 15);
            swordsman.AddAnimation(EAnimation.Right, 8, 50, 50, 100, 8, new Vector2(0, 0), 12);
            swordsman.AddAnimation(EAnimation.Down, 12, 50, 50, 0, 0, new Vector2(0, 0), 15);

            swordsman.SetAnimation(EAnimation.Idle);

            slider = new Slider(new RectangleF(2000, 100, 100, 100));
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
            animSprite.Update(gameTime);
            slider.Update(gameTime);

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

            EngineUI.Draw(spriteBatch);
            animSprite.Draw(spriteBatch);
            slider.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
