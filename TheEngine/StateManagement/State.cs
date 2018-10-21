using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.Input;
using TheEngine.Logging;

namespace TheEngine.StateManagement
{
    public abstract class State
    {
        #region MemberVariables

        /// <summary>
        /// Stores the entities of the State.
        /// </summary>
        private List<IEntity> _entities;

        /// <summary>
        /// Stores references to States that can be reached from this State.
        /// </summary>
        private List<EState> _next;

        /// <summary>
        /// InputHandler for KeyboardInput.
        /// </summary>
        private Action _keyboardHandler;

        /// <summary>
        /// InputHandler for GamePadInput.
        /// </summary>
        private Action _gamePadHandler;

        /// <summary>
        /// Currently active InputHandler.
        /// </summary>
        private Action _inputHandler;

        /// <summary>
        /// Name of the State.
        /// </summary>
        private string _name;

        #endregion
        #region Properties

        public List<EState> Next => _next;

        public Action KeyboardInput
        {
            get => _keyboardHandler;
            set => _keyboardHandler = value;
        }

        public Action GamePadInput
        {
            get => _gamePadHandler;
            set => _gamePadHandler = value;
        }

        public string Name => _name;

        #endregion
        #region Methods

        /// <summary>
        /// Constructs a State with the given entities name.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="next"></param>
        /// <param name="keyboardHandler"></param>
        /// <param name="gamePadHandler"></param>
        /// 
        public State(List<IEntity> entities = null, List<EState> next = null, 
            Action keyboardHandler = null, Action gamePadHandler = null, 
            string name = "NO_NAME_STATE")
        {
            _entities = entities;
            _next = next;
            _keyboardHandler = keyboardHandler;
            _gamePadHandler = gamePadHandler;
            _name = name;

            HandleConstructorDefaults();

            _inputHandler = InputManager.GamePadConnected() ? _gamePadHandler : _keyboardHandler;
        }

        /// <summary>
        /// Handles default values assigned to constructor parameters if no explicit value
        /// was passed through.
        /// </summary>
        private void HandleConstructorDefaults()
        {
            if (_entities == null)
                _entities = new List<IEntity>();

            if (_next == null)
                _next = new List<EState>();

            if (_keyboardHandler == null)
                _keyboardHandler = () => { };

            if (_gamePadHandler == null)
                _gamePadHandler = () => { };
        }

        /// <summary>
        /// Updates every entity of the State.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            foreach (IEntity e in _entities)
                e.Update(gameTime);
            _inputHandler();
        }

        /// <summary>
        /// Draws drawable entities.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEntity e in _entities)
                if (e is IDrawable)
                    ((IDrawable)e).Draw(spriteBatch);
        }

        /// <summary>
        /// Behaviour for when the FiniteStateMachine changes it's currentState to this State.
        /// </summary>
        public virtual void OnEnter()
        {
            Logger.Log("Entered State: " + _name);
        }

        /// <summary>
        /// Behaviour for when the FiniteStateMachine changes it's currentState from this State to another
        /// State.
        /// </summary>
        public virtual void OnExit()
        {
            Logger.Log("Exited State: " + _name);
        }

        #endregion
    }
}
