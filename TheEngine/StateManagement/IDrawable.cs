using Microsoft.Xna.Framework.Graphics;

namespace TheEngine.StateManagement
{
    /// <summary>
    /// IEntities that can be drawn.
    /// </summary>
    public interface IDrawable : IEntity
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
