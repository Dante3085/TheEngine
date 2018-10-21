using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.Graphics.Menu.MenuElements;

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
        /// Rectangle describing the Bounds of the HBox.
        /// </summary>
        private Rectangle _rec;

        #endregion
        #region Properties

        /// <summary>
        /// Returns the Width of the HBox.
        /// </summary>
        public override int Width => CalcWidth();

        /// <summary>
        /// Returns the Height of the HBox.
        /// </summary>
        public override int Height => HeightTallestElement();

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
        public override Rectangle Rectangle { get; }

        #endregion

        /// <summary>
        /// Assigns given Parameters and initially orders elements.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="functionality"></param>
        /// <param name="spacing"></param>
        /// <param name="elements"></param>
        public HBox(int x = 0, int y = 0, Action functionality = null, int spacing = 0, params MenuElement[] elements)
        : base(x, y, functionality, elements)
        {
            _spacing = spacing;
            OrderElements();
            _rec = new Rectangle(x, y, Width, Height);
        }

        /// <summary>
        /// Returns height of the tallest element in the HBox.
        /// </summary>
        /// <returns></returns>
        private int HeightTallestElement()
        {
            if (_elements.Count == 0)
                return -1;

            int height = _elements[0].Height;

            foreach (MenuElement m in _elements)
                if (m.Height > height)
                    height = m.Height;
            return height;
        }

        /// <summary>
        /// Returns width of the HBox. (See: OneNote "HBox Width Berechnung")
        /// </summary>
        /// <returns></returns>
        private int CalcWidth()
        {
            // HBox with no elements has a width of 0.
            if (_elements.Count == 0)
                return 0;

            int width = 0;

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
            if (_elements.Count == 0)
                return;

            // Position first element at upper left corner of HBox.
            _elements[0].X = this._x;
            _elements[0].Y = this._y;

            if (_elements.Count == 1)
                return;

            // Position every element (except first) at HBox.Y and HBox.X + previousElement.X + spacing.
            // Makes it so that elements aren't stacked on top of each other and variable spacing is possible.
            for (int i = 1; i < _elements.Count; i++)
            {
                _elements[i].Y = this._y;
                _elements[i].X = _elements[i - 1].X + _elements[i - 1].Width + _spacing;
            }
        }


        /// <summary>
        /// Updates Layout(base.Update()) and the HBox's Rectangle position and size.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Update rec.
            _rec.X = _x;
            _rec.Y = _y;
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
