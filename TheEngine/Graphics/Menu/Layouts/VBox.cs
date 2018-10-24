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

        /// <summary>
        /// RectangleF describing the Bounds of the VBox.
        /// </summary>
        private RectangleF _rec;

        #endregion

        #region Properties

        /// <summary>
        /// Returns Width of VBox.
        /// </summary>
        public override float Width => WidthWidestElement();

        /// <summary>
        /// Returns Height of VBox.
        /// </summary>
        public override float Height => CalcHeight();

        /// <summary>
        /// Returns, sets spacing inside VBox.
        /// </summary>
        public override int Spacing
        {
            get => _spacing;
            set => _spacing = value;
        }

        /// <summary>
        /// Returns Bounding Rec of VBox.
        /// </summary>
        public override RectangleF RectangleF => _rec;

        #endregion

        /// <summary>
        /// Assigns given Parameters and initially orders Elements.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="spacing"></param>
        /// <param name="functionality"></param>
        /// <param name="elements"></param>
        public VBox(Vector2 position, int spacing = 0, Action functionality = null, params MenuElement[] elements) 
            : base(position, functionality, elements)
        {
            _spacing = spacing;
            OrderElements();
            _rec = new RectangleF(position.X, position.Y, Width, Height);
        }

        /// <summary>
        /// Updates Layout(base.Update()) and the VBox's RectangleF position and size.
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
                height += m.Height;

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

            float width = _elements[0].Width;

            foreach (MenuElement m in _elements)
                if (m.Width > width)
                    width = m.Width;
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
            _elements[0].Position = this.Position;

            // No other elements => All is done.
            if (_elements.Count == 1)
                return;

            //// Position every element (except first) at VBox.X and VBox.Y + previousElement.Y + spacing.
            //// Makes it so that elements aren't stacked on top of each other and variables spacing is possible.
            //for (int i = 1; i < _elements.Count; i++)
            //{
            //    _elements[i].X = this._x;
            //    _elements[i].Y = _elements[i - 1].Y + _elements[i - 1].Height + _spacing;
            //}

            for (int i = 1; i < _elements.Count; i++)
                _elements[i].Position = new Vector2(this.Position.X, _elements[i - 1].Position.Y + 
                                                    _elements[i - 1].Height + _spacing);
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
