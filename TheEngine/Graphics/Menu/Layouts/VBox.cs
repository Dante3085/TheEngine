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
    /// Layout that orders MenuElements vertically.
    /// </summary>
    public class VBox : Layout
    {
        #region MemberVariables

        /// <summary>
        /// Stores the amount of vertical space between each Element of the VBox.
        /// </summary>
        private int _spacing;

        #endregion
        #region Properties

        /// <summary>
        /// Returns, sets spacing inside VBox.
        /// </summary>
        public override int Spacing
        {
            get => _spacing;
            set => _spacing = value;
        }

        #endregion

        /// <summary>
        /// Assigns given Parameters and initially orders Elements.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="spacing"></param>
        /// <param name="functionality"></param>
        /// <param name="elements"></param>
        public VBox(RectangleF bounds, int spacing = 0, Action functionality = null, params MenuElement[] elements) 
            : base(bounds, functionality, elements)
        {
            _spacing = spacing;
            OrderElements();
            _bounds.Width = WidthWidestElement();
            _bounds.Height = CalcHeight();
        }

        /// <summary>
        /// Updates Layout(base.Update()) and the VBox's RectangleF position and size.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update Bounds.
            _bounds.Width = WidthWidestElement();
            _bounds.Height = CalcHeight();
        }

        /// <summary>
        /// Returns height of the VBox.
        /// </summary>
        /// <returns></returns>
        private float CalcHeight()
        {
            // VBox with no elements has a height of 0.
            if (_elements.Count == 0)
                return 0;

            float height = 0;

            // Sum of all elements' height values.
            foreach (MenuElement m in _elements)
                height += m.Bounds.Height;

            // Plus (number of elements - 1) times vertical offset.
            height += (_elements.Count - 1) * _spacing;

            return height;
        }

        /// <summary>
        /// Returns width of the widest element in VBox.
        /// </summary>
        /// <returns></returns>
        private float WidthWidestElement()
        {
            if (_elements.Count == 0)
                return -1;

            float width = _elements[0].Bounds.Width;

            foreach (MenuElement m in _elements)
                if (m.Bounds.Width > width)
                    width = m.Bounds.Width;
            return width;
        }

        /// <summary>
        /// Orders elements vertically.
        /// Position of element is dependant on position of element in element list.
        /// </summary>
        public override void OrderElements()
        {
            // No elements => do nothing.
            if (_elements.Count == 0)
                return;

            // Position first element at upper left corner of VBox.
            RectangleF boundsPointer = _elements[0].Bounds;
            boundsPointer.Location = this._bounds.Location;
            _elements[0].Bounds = boundsPointer;

            // No other elements => All is done.
            if (_elements.Count == 1)
                return;

            for (int i = 1; i < _elements.Count; i++)
            {
                boundsPointer = _elements[i].Bounds;
                boundsPointer.Location = new Vector2(this._bounds.Location.X,
                    _elements[i - 1].Bounds.Location.Y + _elements[i - 1].Bounds.Height + _spacing);
                _elements[i].Bounds = boundsPointer;
            }
        }


        /// <summary>
        /// Draws every Element of the VBox using the given SpriteBatch.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuElement m in _elements)
                m.Draw(spriteBatch);
        }

        public override void MouseHoverReaction()
        {
            throw new NotImplementedException();
        }

        public override void CursorReaction(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
