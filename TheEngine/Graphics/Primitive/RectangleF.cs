using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TheEngine.Graphics.Primitive
{
    public struct RectangleF : IEquatable<RectangleF>
    {
        private static RectangleF emptyRectangleF = new RectangleF();

        private const double TOLERANCE = 0.001;

        /// <summary>
        /// The x coordinate of the top-left corner of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary
        public float X;

        /// <summary>
        /// The y coordinate of the top-left corner of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        public float Y;
        /// <summary>
        /// The width of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        
        public float Width;
        /// <summary>
        /// The height of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        
        public float Height;

        /// <summary>
        /// Returns a <see cref="TheEngine.Graphics.Primitive.RectangleF" /> with X=0, Y=0, Width=0, Height=0.
        /// </summary>
        public static RectangleF Empty => RectangleF.emptyRectangleF;

        /// <summary>
        /// Returns the x coordinate of the left edge of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        public float Left => this.X;

        /// <summary>
        /// Returns the x coordinate of the right edge of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        public float Right => this.X + this.Width;

        /// <summary>
        /// Returns the y coordinate of the top edge of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        public float Top => this.Y;

        /// <summary>
        /// Returns the y coordinate of the bottom edge of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        public float Bottom => this.Y + this.Height;

        /// <summary>
        /// Whether or not this <see cref="TheEngine.Graphics.Primitive.RectangleF" /> has a <see cref="TheEngine.Graphics.Primitive.RectangleF.Width" /> and
        /// <see cref="TheEngine.Graphics.Primitive.RectangleF.Height" /> of 0, and a <see cref="TheEngine.Graphics.Primitive.RectangleF.Location" /> of (0, 0).
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (Math.Abs(this.Width) < TOLERANCE && Math.Abs(this.Height) < TOLERANCE && Math.Abs(this.X) < TOLERANCE)
                    return Math.Abs(this.Y) < TOLERANCE;
                return false;
            }
        }

        /// <summary>
        /// The top-left coordinates of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        public Vector2 Location
        {
            get => new Vector2(this.X, this.Y);
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }

        /// <summary>
        /// The width-height coordinates of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        public Vector2 Size
        {
            get => new Vector2(this.Width, this.Height);
            set
            {
                this.Width = value.X;
                this.Height = value.Y;
            }
        }

        /// <summary>
        /// A <see cref="T:Microsoft.Xna.Framework.Vector2" /> located in the center of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <remarks>
        /// If <see cref="TheEngine.Graphics.Primitive.RectangleF.Width" /> or <see cref="TheEngine.Graphics.Primitive.RectangleF.Height" /> is an odd number,
        /// the center point will be rounded down.
        /// </remarks>
        public Vector2 Center => new Vector2(this.X + this.Width / 2, this.Y + this.Height / 2);

        internal string DebugDisplayString => this.X.ToString() + "  " + (object)this.Y + "  " + (object)this.Width + "  " + (object)this.Height;

        /// <summary>
        /// Creates a new instance of <see cref="TheEngine.Graphics.Primitive.RectangleF" /> struct, with the specified
        /// position, width, and height.
        /// </summary>
        /// <param name="x">The x coordinate of the top-left corner of the created <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="y">The y coordinate of the top-left corner of the created <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="width">The width of the created <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="height">The height of the created <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        public RectangleF(float x, float y, float width, float height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Creates a new instance of <see cref="TheEngine.Graphics.Primitive.RectangleF" /> struct, with the specified
        /// location and size.
        /// </summary>
        /// <param name="location">The x and y coordinates of the top-left corner of the created <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="size">The width and height of the created <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        public RectangleF(Vector2 location, Vector2 size)
        {
            this.X = location.X;
            this.Y = location.Y;
            this.Width = size.X;
            this.Height = size.Y;
        }

        /// <summary>
        /// Compares whether two <see cref="TheEngine.Graphics.Primitive.RectangleF" /> instances are equal.
        /// </summary>
        /// <param name="a"><see cref="TheEngine.Graphics.Primitive.RectangleF" /> instance on the left of the equal sign.</param>
        /// <param name="b"><see cref="TheEngine.Graphics.Primitive.RectangleF" /> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(RectangleF a, RectangleF b)
        {
            if (Math.Abs(a.X - b.X) < TOLERANCE && Math.Abs(a.Y - b.Y) < TOLERANCE && Math.Abs(a.Width - b.Width) < TOLERANCE)
                return Math.Abs(a.Height - b.Height) < TOLERANCE;
            return false;
        }

        /// <summary>
        /// Compares whether two <see cref="TheEngine.Graphics.Primitive.RectangleF" /> instances are not equal.
        /// </summary>
        /// <param name="a"><see cref="TheEngine.Graphics.Primitive.RectangleF" /> instance on the left of the not equal sign.</param>
        /// <param name="b"><see cref="TheEngine.Graphics.Primitive.RectangleF" /> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(RectangleF a, RectangleF b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Gets whether or not the provided coordinates lie within the bounds of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="x">The x coordinate of the point to check for containment.</param>
        /// <param name="y">The y coordinate of the point to check for containment.</param>
        /// <returns><c>true</c> if the provided coordinates lie inside this <see cref="TheEngine.Graphics.Primitive.RectangleF" />; <c>false</c> otherwise.</returns>
        public bool Contains(int x, int y)
        {
            if (this.X <= x && x < this.X + this.Width && this.Y <= y)
                return y < this.Y + this.Height;
            return false;
        }

        /// <summary>
        /// Gets whether or not the provided coordinates lie within the bounds of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="x">The x coordinate of the point to check for containment.</param>
        /// <param name="y">The y coordinate of the point to check for containment.</param>
        /// <returns><c>true</c> if the provided coordinates lie inside this <see cref="TheEngine.Graphics.Primitive.RectangleF" />; <c>false</c> otherwise.</returns>
        public bool Contains(float x, float y)
        {
            if ((double)this.X <= (double)x && (double)x < (double)(this.X + this.Width) && (double)this.Y <= (double)y)
                return (double)y < (double)(this.Y + this.Height);
            return false;
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="T:Microsoft.Xna.Framework.Point" /> lies within the bounds of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <returns><c>true</c> if the provided <see cref="T:Microsoft.Xna.Framework.Point" /> lies inside this <see cref="TheEngine.Graphics.Primitive.RectangleF" />; <c>false</c> otherwise.</returns>
        public bool Contains(Point value)
        {
            if (this.X <= value.X && value.X < this.X + this.Width && this.Y <= value.Y)
                return value.Y < this.Y + this.Height;
            return false;
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="T:Microsoft.Xna.Framework.Point" /> lies within the bounds of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="result"><c>true</c> if the provided <see cref="T:Microsoft.Xna.Framework.Point" /> lies inside this <see cref="TheEngine.Graphics.Primitive.RectangleF" />; <c>false</c> otherwise. As an output parameter.</param>
        public void Contains(ref Point value, out bool result)
        {
            result = this.X <= value.X && value.X < this.X + this.Width && this.Y <= value.Y && value.Y < this.Y + this.Height;
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="T:Microsoft.Xna.Framework.Vector2" /> lies within the bounds of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <returns><c>true</c> if the provided <see cref="T:Microsoft.Xna.Framework.Vector2" /> lies inside this <see cref="TheEngine.Graphics.Primitive.RectangleF" />; <c>false</c> otherwise.</returns>
        public bool Contains(Vector2 value)
        {
            if ((double)this.X <= (double)value.X && (double)value.X < (double)(this.X + this.Width) && (double)this.Y <= (double)value.Y)
                return (double)value.Y < (double)(this.Y + this.Height);
            return false;
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="T:Microsoft.Xna.Framework.Vector2" /> lies within the bounds of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="result"><c>true</c> if the provided <see cref="T:Microsoft.Xna.Framework.Vector2" /> lies inside this <see cref="TheEngine.Graphics.Primitive.RectangleF" />; <c>false</c> otherwise. As an output parameter.</param>
        public void Contains(ref Vector2 value, out bool result)
        {
            result = (double)this.X <= (double)value.X && (double)value.X < (double)(this.X + this.Width) && (double)this.Y <= (double)value.Y && (double)value.Y < (double)(this.Y + this.Height);
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="TheEngine.Graphics.Primitive.RectangleF" /> lies within the bounds of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="value">The <see cref="TheEngine.Graphics.Primitive.RectangleF" /> to check for inclusion in this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <returns><c>true</c> if the provided <see cref="TheEngine.Graphics.Primitive.RectangleF" />'s bounds lie entirely inside this <see cref="TheEngine.Graphics.Primitive.RectangleF" />; <c>false</c> otherwise.</returns>
        public bool Contains(RectangleF value)
        {
            if (this.X <= value.X && value.X + value.Width <= this.X + this.Width && this.Y <= value.Y)
                return value.Y + value.Height <= this.Y + this.Height;
            return false;
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="TheEngine.Graphics.Primitive.RectangleF" /> lies within the bounds of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="value">The <see cref="TheEngine.Graphics.Primitive.RectangleF" /> to check for inclusion in this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="result"><c>true</c> if the provided <see cref="TheEngine.Graphics.Primitive.RectangleF" />'s bounds lie entirely inside this <see cref="TheEngine.Graphics.Primitive.RectangleF" />; <c>false</c> otherwise. As an output parameter.</param>
        public void Contains(ref RectangleF value, out bool result)
        {
            result = this.X <= value.X && value.X + value.Width <= this.X + this.Width && this.Y <= value.Y && value.Y + value.Height <= this.Y + this.Height;
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="T:System.Object" />.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object" /> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is RectangleF f)
                return this == f;
            return false;
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="other">The <see cref="TheEngine.Graphics.Primitive.RectangleF" /> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(RectangleF other)
        {
            return this == other;
        }

        /// <summary>
        /// Gets the hash code of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <returns>Hash code of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</returns>
        public override int GetHashCode()
        {
            return (((17 * 23 + this.X.GetHashCode()) * 23 + this.Y.GetHashCode()) * 23 + this.Width.GetHashCode()) * 23 + this.Height.GetHashCode();
        }

        /// <summary>
        /// Adjusts the edges of this <see cref="TheEngine.Graphics.Primitive.RectangleF" /> by specified horizontal and vertical amounts.
        /// </summary>
        /// <param name="horizontalAmount">Value to adjust the left and right edges.</param>
        /// <param name="verticalAmount">Value to adjust the top and bottom edges.</param>
        public void Inflate(int horizontalAmount, int verticalAmount)
        {
            this.X -= horizontalAmount;
            this.Y -= verticalAmount;
            this.Width += horizontalAmount * 2;
            this.Height += verticalAmount * 2;
        }

        /// <summary>
        /// Adjusts the edges of this <see cref="TheEngine.Graphics.Primitive.RectangleF" /> by specified horizontal and vertical amounts.
        /// </summary>
        /// <param name="horizontalAmount">Value to adjust the left and right edges.</param>
        /// <param name="verticalAmount">Value to adjust the top and bottom edges.</param>
        public void Inflate(float horizontalAmount, float verticalAmount)
        {
            this.X -= (int)horizontalAmount;
            this.Y -= (int)verticalAmount;
            this.Width += (int)horizontalAmount * 2;
            this.Height += (int)verticalAmount * 2;
        }

        /// <summary>
        /// Gets whether or not the other <see cref="TheEngine.Graphics.Primitive.RectangleF" /> intersects with this rectangle.
        /// </summary>
        /// <param name="value">The other rectangle for testing.</param>
        /// <returns><c>true</c> if other <see cref="TheEngine.Graphics.Primitive.RectangleF" /> intersects with this rectangle; <c>false</c> otherwise.</returns>
        public bool Intersects(RectangleF value)
        {
            if (value.Left < this.Right && this.Left < value.Right && value.Top < this.Bottom)
                return this.Top < value.Bottom;
            return false;
        }

        /// <summary>
        /// Gets whether or not the other <see cref="TheEngine.Graphics.Primitive.RectangleF" /> intersects with this rectangle.
        /// </summary>
        /// <param name="value">The other rectangle for testing.</param>
        /// <param name="result"><c>true</c> if other <see cref="TheEngine.Graphics.Primitive.RectangleF" /> intersects with this rectangle; <c>false</c> otherwise. As an output parameter.</param>
        public void Intersects(ref RectangleF value, out bool result)
        {
            result = value.Left < this.Right && this.Left < value.Right && value.Top < this.Bottom && this.Top < value.Bottom;
        }

        /// <summary>
        /// Creates a new <see cref="TheEngine.Graphics.Primitive.RectangleF" /> that contains overlapping region of two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="value2">The second <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <returns>Overlapping region of the two rectangles.</returns>
        public static RectangleF Intersect(RectangleF value1, RectangleF value2)
        {
            RectangleF result;
            RectangleF.Intersect(ref value1, ref value2, out result);
            return result;
        }

        /// <summary>
        /// Creates a new <see cref="TheEngine.Graphics.Primitive.RectangleF" /> that contains overlapping region of two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="value2">The second <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="result">Overlapping region of the two rectangles as an output parameter.</param>
        public static void Intersect(ref RectangleF value1, ref RectangleF value2, out RectangleF result)
        {
            if (value1.Intersects(value2))
            {
                float num1 = Math.Min(value1.X + value1.Width, value2.X + value2.Width);
                float x = Math.Max(value1.X, value2.X);
                float y = Math.Max(value1.Y, value2.Y);
                float num2 = Math.Min(value1.Y + value1.Height, value2.Y + value2.Height);
                result = new RectangleF(x, y, num1 - x, num2 - y);
            }
            else
                result = new RectangleF(0, 0, 0, 0);
        }

        /// <summary>
        /// Changes the <see cref="P:Microsoft.Xna.Framework.Rectangle.Location" /> of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="offsetX">The x coordinate to add to this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="offsetY">The y coordinate to add to this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        public void Offset(int offsetX, int offsetY)
        {
            this.X += offsetX;
            this.Y += offsetY;
        }

        /// <summary>
        /// Changes the <see cref="P:Microsoft.Xna.Framework.Rectangle.Location" /> of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="offsetX">The x coordinate to add to this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="offsetY">The y coordinate to add to this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        public void Offset(float offsetX, float offsetY)
        {
            this.X += (int)offsetX;
            this.Y += (int)offsetY;
        }

        /// <summary>
        /// Changes the <see cref="P:Microsoft.Xna.Framework.Rectangle.Location" /> of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="amount">The x and y components to add to this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        public void Offset(Point amount)
        {
            this.X += amount.X;
            this.Y += amount.Y;
        }

        /// <summary>
        /// Changes the <see cref="P:Microsoft.Xna.Framework.Rectangle.Location" /> of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.
        /// </summary>
        /// <param name="amount">The x and y components to add to this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        public void Offset(Vector2 amount)
        {
            this.X += (int)amount.X;
            this.Y += (int)amount.Y;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String" /> representation of this <see cref="TheEngine.Graphics.Primitive.RectangleF" /> in the format:
        /// {X:[<see cref="TheEngine.Graphics.Primitive.RectangleF.X" />] Y:[<see cref="TheEngine.Graphics.Primitive.RectangleF.Y" />] Width:[<see cref="TheEngine.Graphics.Primitive.RectangleF.Width" />] Height:[<see cref="TheEngine.Graphics.Primitive.RectangleF.Height" />]}
        /// </summary>
        /// <returns><see cref="T:System.String" /> representation of this <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</returns>
        public override string ToString()
        {
            return "{X:" + (object)this.X + " Y:" + (object)this.Y + " Width:" + (object)this.Width + " Height:" + (object)this.Height + "}";
        }

        /// <summary>
        /// Creates a new <see cref="TheEngine.Graphics.Primitive.RectangleF" /> that completely contains two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="value2">The second <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <returns>The union of the two rectangles.</returns>
        public static RectangleF Union(RectangleF value1, RectangleF value2)
        {
            float x = Math.Min(value1.X, value2.X);
            float y = Math.Min(value1.Y, value2.Y);
            return new RectangleF(x, y, Math.Max(value1.Right, value2.Right) - x, Math.Max(value1.Bottom, value2.Bottom) - y);
        }

        /// <summary>
        /// Creates a new <see cref="TheEngine.Graphics.Primitive.RectangleF" /> that completely contains two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="value2">The second <see cref="TheEngine.Graphics.Primitive.RectangleF" />.</param>
        /// <param name="result">The union of the two rectangles as an output parameter.</param>
        public static void Union(ref RectangleF value1, ref RectangleF value2, out RectangleF result)
        {
            result.X = Math.Min(value1.X, value2.X);
            result.Y = Math.Min(value1.Y, value2.Y);
            result.Width = Math.Max(value1.Right, value2.Right) - result.X;
            result.Height = Math.Max(value1.Bottom, value2.Bottom) - result.Y;
        }
    }
}
