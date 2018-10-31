using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheEngine.DataManagement;
using TheEngine.Graphics.Menu;
using TheEngine.Graphics.Menu.Layouts;
using TheEngine.Graphics.Menu.MenuElements;
using TheEngine.Graphics.Primitive;
using TheEngine.Input;

namespace TheEngine.Graphics.EngineUIs
{
    /// <summary>
    /// Provides EngineUI that displays information about the game and offers manipulative functionality.
    /// </summary>
    public static class EngineUI
    {
        private static HBox _hBox;
        private static TextBox _textBox;
        private static TranslateTransition infoScreenTransition;
        private static NewKeyboardInput _keyboardInput;

        public static void Init(NewKeyboardInput keyboardInput)
        {
            _keyboardInput = keyboardInput;

            _textBox = new TextBox(new RectangleF(Vector2.Zero, new Vector2(250, ScreenManager.ScreenHeight)), 
                "Das ist Informationstext mit Single-Word-Wrapping und Multi-Word-Wrapping", Contents.Arial15, Color.DimGray, .2f);

            _hBox = new HBox(new RectangleF(Vector2.Zero, Vector2.Zero), 2, elements: new MenuElement[]
            {
                _textBox,
                new VBox(new RectangleF(), 0, elements: new MenuElement[]
                {
                    new TextButton(new RectangleF(Vector2.Zero, new Vector2(100, 50)), "Text", Color.Aqua),
                    new TextButton(new RectangleF(Vector2.Zero, new Vector2(100, 50)), "Text", Color.IndianRed),
                    new Text(new RectangleF(Vector2.Zero, Vector2.Zero), "Das ist Text"),
                    new Text(new RectangleF(Vector2.Zero, Vector2.Zero), "Das ist Text"),
                    new CheckBox(new RectangleF(1000, 100, 100, 100), false),
                    new Text(new RectangleF(Vector2.Zero, Vector2.Zero), "Das ist Text"),
                    new MenuButton(new RectangleF(Vector2.Zero, new Vector2(100, 100)), Contents.redButtonNoHover,
                        Contents.redButtonHover),
                    new Text(new RectangleF(Vector2.Zero, Vector2.Zero), "Das ist Text"),
                    new CheckBox(new RectangleF(1000, 100, 100, 100), false),
                    new Text(new RectangleF(Vector2.Zero, Vector2.Zero), "Das ist Text"),
                    new CheckBox(new RectangleF(1000, 100, 100, 100), false),
                    new CheckBox(new RectangleF(1000, 100, 100, 100), false),
                    new CheckBox(new RectangleF(1000, 100, 100, 100), false),
                    new MenuButton(new RectangleF(Vector2.Zero, new Vector2(100, 100)), Contents.redButtonNoHover,
                        Contents.redButtonHover), 
                    new CheckBox(new RectangleF(1000, 100, 100, 100), false),
                    new CheckBox(new RectangleF(1000, 100, 100, 100), false),
                    new MenuButton(new RectangleF(Vector2.Zero, new Vector2(100, 100)), Contents.redButtonNoHover,
                        Contents.redButtonHover),
                }),
                new VBox(new RectangleF(), 10, elements: new MenuElement[]
                {
                    new CheckBox(new RectangleF(1000, 100, 100, 100), false),
                    new CheckBox(new RectangleF(1000, 100, 100, 100), false),
                    new CheckBox(new RectangleF(1000, 100, 100, 100), false),
                    new CheckBox(new RectangleF(1000, 100, 100, 100), false),
                    new TextBox(new RectangleF(Vector2.Zero, new Vector2(200, 500)), "Das ist von mir geschriebener Text, der hoffentlich umgebrochen wird.",
                        Contents.Arial18, Color.Beige, 0.2f),
                    new DropBox(new RectangleF(), new List<TextButton>()
                    {
                        new TextButton(new RectangleF(Vector2.Zero, new Vector2(100, 200)), "DropboxHead", Color.IndianRed),
                        new TextButton(new RectangleF(Vector2.Zero, new Vector2(100, 200)), "Text", Color.IndianRed),
                        new TextButton(new RectangleF(Vector2.Zero, new Vector2(100, 200)), "Text", Color.IndianRed),
                        new TextButton(new RectangleF(Vector2.Zero, new Vector2(100, 200)), "Text", Color.IndianRed),
                    }), 
                }), 
            });

            Game1.gameConsole.Log("" + _hBox.Bounds.Location.X);
            RectangleF pointer = _hBox.Bounds;
            pointer.Location -= new Vector2(_hBox.Bounds.Width, 0);
            _hBox.Bounds = pointer;

            Game1.gameConsole.Log("" + _hBox.Bounds.Width);
            Game1.gameConsole.Log("" + _hBox.Bounds.Location.X);

            infoScreenTransition = new TranslateTransition(_hBox.Bounds.Location, Vector2.Zero, 1000, _hBox);
        }

        public static void Update(GameTime gameTime)
        {
            _hBox.Update(gameTime);
            infoScreenTransition.Update(gameTime);

            if (InputManager.GamePadConnected())
            {
                if (InputManager.OnButtonDown(Buttons.A))
                {
                    if (InputManager.OnButtonToggle(Buttons.A))
                        infoScreenTransition.Backward();
                    else
                        infoScreenTransition.Forward();
                }
            }
            else
            {
                if (InputManager.OnKeyDown(_keyboardInput.Inputs[EInput.InfoScreen]))
                {
                    if (InputManager.OnKeyToggle(_keyboardInput.Inputs[EInput.InfoScreen]))
                        infoScreenTransition.Backward();
                    else
                        infoScreenTransition.Forward();
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            _hBox.Draw(spriteBatch);
        }
    }
}