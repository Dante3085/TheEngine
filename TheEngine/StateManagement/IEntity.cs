using Microsoft.Xna.Framework;

namespace TheEngine.StateManagement
{
    /// <summary>
    /// Contract for objects that can be understood by FiniteStateMachine.
    /// </summary>
    public interface IEntity
    {
        void Update(GameTime gameTime);
    }
}
