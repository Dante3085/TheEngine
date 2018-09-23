using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TheEngine.StateMachine
{
    /// <summary>
    /// Contract for objects that can be understood by FiniteStateMachine.
    /// </summary>
    public interface IEntity
    {
        void Update(GameTime gameTime);
    }
}
