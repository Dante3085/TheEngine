using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheEngine.Graphics.Menu;
using TheEngine.Graphics.Menu.MenuElements;
using TheEngine.Input;

namespace TheEngine.Graphics.EngineUIs
{
    /// <summary>
    /// Provides EngineUI that displays information about the game and offers manipulative functionality.
    /// </summary>
    public static class EngineUI
    {
        private static TextButton infoScreen;
        private static TranslateTransition infoScreenTransition;

        public static void Init()
        {
            infoScreen = new TextButton(Vector2.Zero, new Vector2(200,
                (float) ScreenManager.ScreenHeight), "", Color.Aquamarine);
            infoScreen.Position -= new Vector2(infoScreen.Width, 0);

            infoScreenTransition = new TranslateTransition(infoScreen.Position, Vector2.Zero, 1000, infoScreen);
        }

        public static void Update(GameTime gameTime)
        {
            infoScreen.Update(gameTime);
            infoScreenTransition.Update(gameTime);

            if (InputManager.GamePadConnected())
            {
                if (InputManager.OnButtonDown(Buttons.Start))
                {
                    if (InputManager.OnButtonToggle(Buttons.Start))
                        infoScreenTransition.Backward();
                    else
                        infoScreenTransition.Forward();
                }
            }
            else
            {
                if (InputManager.OnKeyDown(Keys.Tab))
                {
                    if (InputManager.OnKeyToggle(Keys.Tab))
                        infoScreenTransition.Backward();
                    else
                        infoScreenTransition.Forward();
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            infoScreen.Draw(spriteBatch);
        }
    }
}