﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.DataManagement;

namespace TheEngine.Graphics.Primitive
{
    /// <summary>
    /// Provides Methods for drawing simple geometric shapes.
    /// </summary>
    public static class Primitives
    {
        private static Color white = Color.White;

        /// <summary>
        /// Draws a RectangleF outline (unfilled RectangleF) using the given RectangleF object. <para></para>
        /// "lines" parameter has to be exactly 4 RectangleF objects.
        /// "lines" parameter exists to avoid 4 additional RectangleF objects from being created everytime this method is called.
        /// This is important since this method is called a lot (May prevent GarbageCollection hickups).
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="rec"></param>
        /// <param name="lines"></param>
        /// <param name="texture"></param>
        /// <param name="color"></param>
        /// <param name="lineThickness"></param>
        public static void DrawBounds(RectangleF rec, Rectangle[] lines, Texture2D texture, Color color, SpriteBatch spriteBatch,
            int lineThickness = 2)
        {
            if (lines.Length != 4)
                throw new ArgumentException("'lines' has to bee an array of exactly 4 RectangleF objects!");

            // left
            lines[0].X = (int)rec.X;
            lines[0].Y = (int)rec.Y;
            lines[0].Width = lineThickness;
            lines[0].Height = (int)rec.Height;

            // top
            lines[1].X = (int)rec.X;
            lines[1].Y = (int)rec.Y;
            lines[1].Width = (int)rec.Width;
            lines[1].Height = lineThickness;

            // right
            lines[2].X = (int)rec.X + (int)rec.Width;
            lines[2].Y = (int)rec.Y;
            lines[2].Width = lineThickness;
            lines[2].Height = (int)rec.Height;

            // bottom
            lines[3].X = (int)rec.X;
            lines[3].Y = (int)rec.Y + (int)rec.Height;
            lines[3].Width = (int)rec.Width;
            lines[3].Height = lineThickness;

            spriteBatch.Draw(texture, lines[0], color);
            spriteBatch.Draw(texture, lines[1], color);
            spriteBatch.Draw(texture, lines[2], color);
            spriteBatch.Draw(texture, lines[3], color);
        }

        /// <summary>
        /// Draws a filled RectangleF using the given RectangleF object.
        /// data is the size of the rectangle.
        /// </summary>
        /// <param name="rec"></param>
        /// <param name="recTex"></param>
        /// <param name="data"></param>
        /// <param name="color"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="opacity"></param>
        public static void DrawRectangle(RectangleF rec, Texture2D recTex, SpriteBatch spriteBatch, 
            double opacity = 1.0)
        {
            spriteBatch.Draw(recTex, rec.Location, white * (float)opacity);
        }

        /// <summary>
        /// Draws a circle with the given radius, color, sharpness and opacity at the given position.
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="color"></param>
        /// <param name="pos"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="sharpness"></param>
        /// <param name="opacity"></param>
        /// <returns></returns>
        public static Texture2D DrawCircle(int radius, Color color, Vector2 pos, SpriteBatch spriteBatch, 
            GraphicsDevice graphicsDevice, double sharpness = 1.0, double opacity = 1.0)
        {
            int diameter = radius * 2;
            Texture2D circleTex = new Texture2D(graphicsDevice, diameter, diameter, false, SurfaceFormat.Color);
            Color[] colorData = new Color[circleTex.Width * circleTex.Height];
            Vector2 center = new Vector2(radius);

            for (int colIndex = 0; colIndex < circleTex.Width; colIndex++)
            {
                for (int rowIndex = 0; rowIndex < circleTex.Height; rowIndex++)
                {
                    Vector2 position = new Vector2(colIndex, rowIndex);
                    float distance = Vector2.Distance(center, position);

                    // hermite iterpolation
                    float x = distance / diameter;
                    float edge0 = (radius * (float)sharpness) / (float)diameter;
                    float edge1 = radius / (float)diameter;
                    float temp = MathHelper.Clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
                    float result = temp * temp * (3.0f - 2.0f * temp);

                    colorData[rowIndex * circleTex.Width + colIndex] = color * (1f - result);
                }
            }
            circleTex.SetData<Color>(colorData);

            spriteBatch.Draw(circleTex, pos, color * (float)opacity);

            return circleTex;
        }
    }
}
