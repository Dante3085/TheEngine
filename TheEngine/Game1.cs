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

        private VBox vBox;

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;

            ScreenManager.Update(graphics);

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

            vBox = new VBox(new RectangleF(1200, 0, 0, 0), 10, elements: new MenuElement[]
            {
                new TextButton(new RectangleF(0, 0, 100, 100), "FirstButton", Color.BlueViolet), // 1
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 2
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 3
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 4
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 5
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 6
                new TextButton(new RectangleF(0, 0, 100, 100), "LastButton", Color.BlueViolet), // 7
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 8
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 9
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 10
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 11
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 12
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 13
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 14
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 15
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 16
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 17
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 18
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 19
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 20
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 21
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 22
                new TextButton(new RectangleF(0, 0, 100, 100), "TextButton", Color.BlueViolet), // 23
            });
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

            Game1.gameConsole.Log("MousePosition: " + InputManager.CurrentMousePosition().ToString());

            EngineUI.Update(gameTime);
            vBox.Update(gameTime);

            var _elements = vBox.Elements;
            for (int i = 0; i < _elements.Count; i++)
            {
                if (i == 0)
                    Game1.gameConsole.Log("First: " + _elements[i].Bounds.ToString(), 5);
                else if (i == _elements.Count - 1)
                    Game1.gameConsole.Log("Last: " + _elements[i].Bounds.ToString(), 3);
                else
                    Game1.gameConsole.Log(_elements[i].Bounds.ToString());
            }

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
            vBox.Draw(spriteBatch);
            // textButton.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
