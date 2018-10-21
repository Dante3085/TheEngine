
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheEngine;
using TheEngine.Graphics.Menu.Layouts;
using TheEngine.Graphics.Menu.MenuElements;
using TheEngine.Input;
using IDrawable = TheEngine.StateManagement.IDrawable;

namespace TheEngine.Graphics.Menu
{
    /// <summary>
    /// TODO: Questionable Purpose
    /// Adds MenuCursor feature on given Layout.
    /// </summary>
    public class Menu : GameObject, StateManagement.IDrawable
    {
        #region MemberVariables

        private Layout _layout;
        private int _cursoredElement;

        #endregion
        #region Methods

        public Menu(Layout layout)
        {
            _layout = layout;
            _cursoredElement = 0;
        }

        public void Update(GameTime gameTime)
        {
            _layout.Update(gameTime);

            _layout.Elements[_cursoredElement].CursorOnIt = true;
            if (InputManager.GamePadConnected())
                HandleGamePadInput(gameTime);
            else
                HandleKeyboardInput(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _layout.Draw(spriteBatch);
        }

        public void HandleKeyboardInput(GameTime gameTime)
        {
            List<MenuElement> elements = _layout.Elements;

            // Go backwards through element list.
            if (InputManager.OnKeyDown(Keys.Up))
            {
                elements[_cursoredElement].CursorOnIt = false;

                // Cursor is at first element => Set Cursor to last element.
                if (elements[_cursoredElement].Equals(elements[0]))
                    _cursoredElement = elements.Count - 1;
                else
                    _cursoredElement--;
            }

            // Go forward through element list.
            else if (InputManager.OnKeyDown(Keys.Down))
            {
                elements[_cursoredElement].CursorOnIt = false;

                // Cursor is at last element. Set cursor to first element.
                if (elements[_cursoredElement].Equals(elements[elements.Count - 1]))
                    _cursoredElement = 0;
                else
                    _cursoredElement++;
            }

            // Execute Functionality of cursored element.
            else if (InputManager.OnKeyDown(Keys.Enter))
                elements[_cursoredElement].ExecuteFunctionality();
        }

        public void HandleGamePadInput(GameTime gameTime)
        {
            List<MenuElement> elements = _layout.Elements;

            if (InputManager.OnButtonDown(Buttons.DPadUp))
            {
                elements[_cursoredElement].CursorOnIt = false;

                // Cursor is at first element => Set Cursor to last element.
                if (elements[_cursoredElement].Equals(elements[0]))
                    _cursoredElement = elements.Count - 1;
                else
                    _cursoredElement--;
            }

            else if (InputManager.OnButtonDown(Buttons.DPadDown))
            {
                elements[_cursoredElement].CursorOnIt = false;

                // Cursor is at last element. Set cursor to first element.
                if (elements[_cursoredElement].Equals(elements[elements.Count - 1]))
                    _cursoredElement = 0;
                else
                    _cursoredElement++;
            }

            else if (InputManager.OnButtonDown(Buttons.A))
                elements[_cursoredElement].ExecuteFunctionality();
        }

        #endregion
    }
}
