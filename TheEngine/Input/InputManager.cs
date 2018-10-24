﻿using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TheEngine.Graphics.Primitive;

namespace TheEngine.Input
{
    /// <summary>
    /// Provides utility for checking Input.
    /// Note: GamePad is currently restricted to PlayerIndex.One.
    /// </summary>
    public static class InputManager
    {
        #region MemberVariables

        private static KeyboardState _currentKeyboardState;
        private static KeyboardState _previousKeyboardState;

        private static GamePadState _currentGamePadState;
        private static GamePadState _previousGamePadState;

        private static MouseState _previousMouseState;
        private static MouseState _currentMouseState;

        private const double doubleClickDelay = 500;
        private static double doubleClickTimer;

        #endregion
        #region UpdateStatesMethods

        /// <summary>
        /// Call this method before you'r Input operation(s).
        /// </summary>
        public static void UpdateCurrentStates()
        {
            _currentKeyboardState = Keyboard.GetState();

            _currentGamePadState = GamePad.GetState(PlayerIndex.One);

            _currentMouseState = Mouse.GetState();
        }

        /// <summary>
        /// Call this method after you'r Input operation(s).
        /// </summary>
        public static void UpdatePreviousStates()
        {
            _previousKeyboardState = _currentKeyboardState;

            _previousGamePadState = _currentGamePadState;

            _previousMouseState = _currentMouseState;
        }

        #endregion
        #region Mouse

        /// <summary>
        /// Returns MousePosition of CurrentState
        /// </summary>
        /// <returns></returns>
        public static Point CurrentMousePosition()
        {
            return _currentMouseState.Position;
        }

        /// <summary>
        /// Returns MousePosition of PreviousState.
        /// </summary>
        /// <returns></returns>
        public static Point PreviousMousePosition()
        {
            return _previousMouseState.Position;
        }

        /// <summary>
        /// Gets whether LeftMouseButton has been clicked (no holding).
        /// </summary>
        /// <returns></returns>
        public static bool OnLeftMouseClick()
        {
            return _previousMouseState.LeftButton == ButtonState.Released && 
                _currentMouseState.LeftButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Gets whether LeftMouseButton has been clicked and is still down (holding).
        /// </summary>
        /// <returns></returns>
        public static bool IsLeftMouseClick()
        {
            return _previousMouseState.LeftButton == ButtonState.Pressed &&
                   _currentMouseState.LeftButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Gets whether RightMouseButton has been clicked (no holding).
        /// </summary>
        /// <returns></returns>
        public static bool OnRightMouseClick()
        {
            return _previousMouseState.RightButton == ButtonState.Released &&
                _currentMouseState.RightButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Gets whether RightMouseButton has been clicked and is still down (holding).
        /// </summary>
        /// <returns></returns>
        public static bool IsRightMouseClick()
        {
            return _previousMouseState.RightButton == ButtonState.Pressed &&
                _currentMouseState.RightButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Gets whether Mouse has entered the given Rectangle
        /// (no holding / triggers once).
        /// </summary>
        /// <returns></returns>
        public static bool OnMouseHoverRectangle(RectangleF rectangle)
        {
            return rectangle.Contains(_previousMouseState.Position) == false &&
                   rectangle.Contains(_currentMouseState.Position);
        }

        /// <summary>
        /// Gets whether Mouse hovers the given Rectangle
        /// (triggers as long as Mouse hovers Rectangle).
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static bool IsMouseHoverRectangle(RectangleF rectangle)
        {
            return rectangle.Contains(_currentMouseState.Position);
        }

        /// <summary>
        /// Gets whether or not Left Mouse has been double clicked (no holding).
        /// </summary>
        /// <returns></returns>
        public static bool OnLeftDoubleClick(GameTime gameTime)
        {
           // TODO
            throw new NotImplementedException();
        }

        #endregion
        #region Keyboard

        /// <summary>
        /// Gets whether given key is currently being pressed. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyDown(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Gets whether given key is currently not being pressed.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyUp(Keys key)
        {
            return _currentKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        /// Gets whether given key has initially been pressed.
        /// Key was up, is now down. (No holding)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool OnKeyDown(Keys key)
        {
            return _previousKeyboardState.IsKeyUp(key) && _currentKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Gets whether given key has initially been released.
        /// Key was down, is now up. (No holding)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool OnKeyUp(Keys key)
        {
            return _previousKeyboardState.IsKeyDown(key) && _currentKeyboardState.IsKeyUp(key);
        }

        #endregion
        #region GamePad

        /// <summary>
        /// Gets whether or not a GamePad is currently connected.
        /// </summary>
        /// <returns></returns>
        public static bool GamePadConnected()
        {
            return _currentGamePadState.IsConnected;
        }

        /// <summary>
        /// Gets whether given button is currently being pressed. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsButtonDown(Buttons button)
        {
            return _currentGamePadState.IsButtonDown(button);
        }

        /// <summary>
        /// Gets whether given button is currently not being pressed.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static bool IsButtonUp(Buttons button)
        {
            return _currentGamePadState.IsButtonUp(button);
        }

        /// <summary>
        /// Gets whether given button has initially been pressed.
        /// Button was up, is now down. (No holding)
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static bool OnButtonDown(Buttons button)
        {
            return _previousGamePadState.IsButtonUp(button) && _currentGamePadState.IsButtonDown(button);
        }

        /// <summary>
        /// Gets whether given button has initially been released.
        /// Button was down, is now up. (No holding)
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static bool OnButtonUp(Buttons button)
        {
            return _previousGamePadState.IsButtonDown(button) && _currentGamePadState.IsButtonUp(button);
        }

        #endregion
    }
}
