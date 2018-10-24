using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TheEngine.Graphics.Primitive;

namespace TheEngine.Graphics.Sprites
{
    /// <summary>
    /// Marks Types for being able to collide with each other.
    /// </summary>
    public interface ICollidable
    {
        /// <summary>
        /// Identify ICollidables that took part in the collision.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// BoundingBox that is necessary for detecting the collision.
        /// </summary>
        RectangleF BoundingBox { get; }

        /// <summary>
        /// Contains logic for deciding if collision happened.
        /// </summary>
        /// <param name="partner"></param>
        /// <returns></returns>
        bool CollidesWith(ICollidable partner);

        /// <summary>
        /// Called in case of Collision.
        /// </summary>
        /// <param name="parnter"></param>
        void HandleCollision(ICollidable parnter);
    }
}