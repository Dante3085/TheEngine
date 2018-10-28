using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.Graphics.Menu.MenuElements;
using TheEngine.Graphics.Primitive;

namespace TheEngine.Graphics.Menu.Layouts
{
    /// <summary>
    /// Layout that orders MenuElements horizontally.
    /// </summary>
    public class HBox : Layout
    {
        #region MemberVariables

        /// <summary>
        /// Stores the amount of horizontal space between each Element of the HBox.
        /// </summary>
        private int _spacing;

        #endregion
        #region Properties

        /// <summary>
        /// Returns, sets spacing inside HBox.
        /// </summary>
        public override int Spacing
        {
            get => _spacing;
            set => _spacing = value;
        }

        #endregion

        /// <summary>
        /// Assigns given Parameters and initially orders elements.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="functionality"></param>
        /// <param name="spacing"></param>
        /// <param name="elements"></param>
        public HBox(RectangleF bounds, int spacing = 0, Action functionality = null, params MenuElement[] elements)
        : base(bounds, functionality, elements)
        {
            _spacing = spacing;
            OrderElements();
        }

        /// <summary>
        /// Returns height of the tallest element in the HBox.
        /// </summary>
        /// <returns></returns>
        private float HeightTallestElement()
        {
            if (_elements.Count == 0)
                return -1;

            float height = _elements[0].Bounds.Height;

            foreach (MenuElement m in _elements)
                if (m.Bounds.Height > height)
                    height = m.Bounds.Height;
            return height;
        }

        /// <summary>
        /// Returns width of the HBox. (See: OneNote "HBox Width Berechnung")
        /// </summary>
        /// <returns></returns>
        private float CalcWidth()
        {
            // HBox with no elements has a width of 0.
            if (_elements.Count == 0)
                return 0;

            float width = 0;

            // Sum of all elements' width values.
            foreach (MenuElement m in _elements)
                width += m.Bounds.Width;

            // Plus (number of elements - 1) times horizontal offset.
            width += (_elements.Count - 1) * _spacing;

            return width;
        }

        /// <summary>
        /// Positions elements horizontally.
        /// Position of element is dependant on position of element in element list.
        /// </summary>
        public override void OrderElements()
        {
            // No elements => do nothing.
            if (_elements.Count == 0)
                return;

            RectangleF boundsPointer;

            // Position first element at origin of HBox.
            boundsPointer = _elements[0].Bounds;
            boundsPointer.Location = this._bounds.Location;
            _elements[0].Bounds = boundsPointer;

            // No other elements => All is done.
            if (_elements.Count == 1)
                return;

            // Position every element (except first) at HBox.Y and HBox.X + previousElement.X + spacing.
            // Makes it so that elements aren't stacked on top of each other and variable spacing is possible.
            for (int i = 1; i < _elements.Count; i++)
            {
                boundsPointer = _elements[i].Bounds;
                boundsPointer.Location = new Vector2(_elements[i - 1].Bounds.Location.X + _elements[i - 1].Bounds.Width + _spacing,
                    this._bounds.Location.Y);
                _elements[i].Bounds = boundsPointer;
            }
        }


        /// <summary>
        /// Updates Layout(base.Update()) and the HBox's RectangleF position and size.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update Bounds.
            _bounds.Width = CalcWidth();
            _bounds.Height = HeightTallestElement();
        }

        /// <summary>
        /// Draws every Element of the HBox using the given SpriteBatch.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuElement m in _elements)
                m.Draw(spriteBatch);
        }

        public override void MouseHoverReaction()
        {
            // throw new NotImplementedException();
        }

        public override void CursorReaction(GameTime gameTime)
        {
            // throw new NotImplementedException();
        }
    }
}
