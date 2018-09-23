using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TheEngine.Input
{
    public interface IInputable
    {
        void HandleKeyboardInput(GameTime gameTime);
        void HandleGamePadInput(GameTime gameTime);
    }
}
