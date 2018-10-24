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

        /// <summary>
        /// RectangleF describing the Bounds of the HBox.
        /// </summary>
        private RectangleF _rec;

        #endregion
        #region Properties

        /// <summary>
        /// Returns the Width of the HBox.
        /// </summary>
        public override float Width => CalcWidth();

        /// <summary>
        /// Returns the Height of the HBox.
        /// </summary>
        public override float Height => HeightTallestElement();

        /// <summary>
        /// Returns, sets spacing inside HBox.
        /// </summary>
        public override int Spacing
        {
            get => _spacing;
            set => _spacing = value;
        }

        /// <summary>
        /// Returns Bounding Rec of HBox.
        /// </summary>
        public override RectangleF RectangleF { get; }

        #endregion

        /// <summary>
        /// Assigns given Parameters and initially orders elements.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="functionality"></param>
        /// <param name="spacing"></param>
        /// <param name="elements"></param>
        public HBox(Vector2 position, Action functionality = null, int spacing = 0, params MenuElement[] elements)
        : base(position, functionality, elements)
        {
            _spacing = spacing;
            OrderElements();
            _rec = new RectangleF(position.X, position.Y, Width, Height);
        }

        /// <summary>
        /// Returns height of the tallest element in the HBox.
        /// </summary>
        /// <returns></returns>
        private float HeightTallestElement()
        {
            if (_elements.Count == 0)
                return -1;

            float height = _elements[0].Height;

            foreach (MenuElement m in _elements)
                if (m.Height > height)
                    height = m.Height;
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
                width += m.Width;

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

            // Position first element at origin of HBox.
            _elements[0].Position = this._position;

            // No other elements => All is done.
            if (_elements.Count == 1)
                return;

            //// Position every element (except first) at HBox.Y and HBox.X + previousElement.X + spacing.
            //// Makes it so that elements aren't stacked on top of each other and variable spacing is possible.
            //for (int i = 1; i < _elements.Count; i++)
            //{
            //    _elements[i].Y = this._y;
            //    _elements[i].X = _elements[i - 1].X + _elements[i - 1].Width + _spacing;
            //}

            // Position every element (except first) at HBox.Y and HBox.X + previousElement.X + spacing.
            // Makes it so that elements aren't stacked on top of each other and variable spacing is possible.
            for (int i = 1; i < _elements.Count; i++)
                _elements[i].Position = new Vector2(_elements[i - 1].Position.X + _elements[i - 1].Width + _spacing,
                                                    this.Position.Y);
        }


        /// <summary>
        /// Updates Layout(base.Update()) and the HBox's RectangleF position and size.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update rec.
            _rec.X = _position.X;
            _rec.Y = _position.Y;
            _rec.Width = Width;
            _rec.Height = Height;
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
            throw new NotImplementedException();
        }

        public override void CursorReaction(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
