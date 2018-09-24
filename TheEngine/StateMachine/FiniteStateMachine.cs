﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine;
using TheEngine.Input;

namespace TheEngine.StateMachine
{
    /// <summary>
    /// FiniteStateMachine manages updating, drawing and switching between States.
    /// </summary>
    public class FiniteStateMachine
    {
        #region MemberVariables

        /// <summary>
        /// Stores all States known to the FiniteStateMachine.
        /// </summary>
        private Dictionary<EState, State> _states;

        /// <summary>
        /// Stores a reference to the currenState of the FiniteStateMachine.
        /// </summary>
        private EState _currentState = EState.EmptyState;

        #endregion
        #region Properties

        /// <summary>
        /// Returns all States known to the FiniteStateMachine.
        /// </summary>
        public Dictionary<EState, State> States => _states;

        /// <summary>
        /// Returns a reference to the current State of the FiniteStateMachine.
        /// </summary>
        public EState CurrentState => _currentState;

        #endregion
        #region Methods

        /// <summary>
        /// Constructs a FiniteStateMachine with the given States.
        /// </summary>
        /// <param name="states"></param>
        public FiniteStateMachine(Dictionary<EState, State> states)
        {
            _states = states;
        }

        /// <summary>
        /// Checks for InputType (Keyboard or GamePad).
        /// Updates the currentState of the FiniteStateMachine.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            _states[_currentState].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _states[_currentState].Draw(spriteBatch);
        }

        /// <summary>
        /// If the given State is known to the FiniteStateMachine, the currentState of the FiniteStateMachine
        /// is changed to the given State.
        /// </summary>
        /// <param name="state"></param>
        public void Change(EState state)
        {
            if (!_states.ContainsKey(state))
                throw new FiniteStateMachineException("@FiniteStateMachine.Change(" + state + "): " 
                                                      + state + " is not known to this FiniteStateMachine!");

            if (!_states[_currentState].Next.Contains(state))
                throw new FiniteStateMachineException("@FiniteStateMachine.Change(" + state + "): "
                                                      + _currentState + " does not allow for a Change from it to "
                                                      + state);

            _states[_currentState].OnExit();
            _currentState = state;
            _states[_currentState].OnEnter();
        }

        /// <summary>
        /// If the given State is not already known to the FiniteStateMachine, the given State is added
        /// to the FiniteStateMachine.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="state"></param>
        public void Add(EState name, State state)
        {
            if (_states.ContainsKey(name))
                throw new FiniteStateMachineException("@FiniteStateMachine.Add(" + name + "): " 
                                                      + name + " is already known to this FiniteStateMachine!");
            _states.Add(name, state);
        }

        /// <summary>
        /// If the given State is known to the FiniteStateMachine, the given State is removed from the
        /// FiniteStateMachine.
        /// </summary>
        /// <param name="state"></param>
        public void Remove(EState state)
        {
            if (!_states.ContainsKey(state))
                throw new FiniteStateMachineException("@FiniteStateMachine.Remove(" + state + "): " 
                                                      + state + " is not known to this FiniteStateMachine!");
            _states.Remove(state);
        }

        #endregion
    }
}
