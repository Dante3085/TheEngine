﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TheEngine;
using TheEngine.Input;

namespace TheEngine.Graphics.Sprites.Combos
{
    /// <summary>
    /// Sequence of Button/Key-Presses leads to sequence of Animations.
    /// </summary>
    public class Combo
    {
        #region MemberVariables

        // Should only be set once.
        private ComboNode _root;
        private ComboNode _current;
        private AnimatedSprite _sprite;

        private bool _checkCurrentInput = true;
        private int _passedMillis = 0;

        #endregion

        #region Properties



        #endregion

        #region Methods

        public Combo(ComboNode root, AnimatedSprite sprite)
        {
            _root = root;
            _current = _root;
            _sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {
            // Check CurrentComboNode Input
            if (_checkCurrentInput)
            {
                if (InputManager.OnKeyDown(_current.Key) || InputManager.OnButtonDown(_current.Button))
                {
                    // Makes it so that when Animation ends, the Check for next start.
                    _sprite.SetOnAnimationEnd(_current.Animation, () =>
                    {
                        _checkCurrentInput = false;
                        _sprite.SetAnimation(EAnimation.Idle);
                    });
                    _sprite.SetAnimation(_current.Animation);
                    _passedMillis = 0;
                }
            }

            // Check CurrentComboNode.Next Input
            else
            {
                _passedMillis += gameTime.ElapsedGameTime.Milliseconds;

                // TimeIntervall exceeded.
                if (_passedMillis > _current.TimeIntervall.End)
                {
                    _checkCurrentInput = true;
                    _current = _root;
                }

                // Inside TimeIntervall.
                else if (_passedMillis > _current.TimeIntervall.Start &&
                         _passedMillis < _current.TimeIntervall.End)
                {
                    // Check for Input for Next
                    foreach (Keys k in _current.Next.Keys)
                    {
                        if (InputManager.OnKeyDown(k))
                        {
                            _current = _current.Next[k];
                            _sprite.SetAnimation(_current.Animation);
                            _checkCurrentInput = true;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
