using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace TheEngine.Input
{
    public class NewKeyboardInput
    {
        private Dictionary<EInput, Keys> _inputs;

        public Dictionary<EInput, Keys> Inputs
        {
            get => _inputs;
            set => _inputs = value;
        }

        public NewKeyboardInput(Dictionary<EInput, Keys> inputs)
        {
            _inputs = inputs;
        }

        /// <summary>
        /// Returns a NewKeyboardInput with default Layout.
        /// </summary>
        /// <returns></returns>
        public static NewKeyboardInput Default()
        {
            return new NewKeyboardInput(new Dictionary<EInput, Keys>()
            {
                // Sprite Movement
                { EInput.Left, Keys.Left },
                { EInput.Up, Keys.Up },
                { EInput.Right, Keys.Right },
                { EInput.Down, Keys.Down },

                // EngineUI
                { EInput.InfoScreen, Keys.F1 },
            });
        }
    }
}
