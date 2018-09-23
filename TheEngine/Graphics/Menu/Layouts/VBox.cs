using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.Graphics.Menu.MenuComponents;

namespace TheEngine.Graphics.Menu.Layouts
{
    /// <summary>
    /// Layout that orders MenuElements vertically.
    /// </summary>
    public class VBox : Layout
    {
        #region MemberVariables

        /// <summary>
        /// Amount of vertical spacing in the VBox.
        /// </summary>
        private int _spacing;

        /// <summary>
        /// 
        /// </summary>
        private Rectangle _rec;

        #endregion

        #region Properties

        public override int Width => WidthWidestElement();
        public override int Height => CalcHeight();

        public override int Spacing
        {
            get => _spacing;
            set => _spacing = value;
        }

        public override Rectangle Rectangle => _rec;

        #endregion

        public VBox(int x = 0, int y = 0, int spacing = 0, Action functionality = null, params MenuElement[] elements) 
            : base(x, y, functionality, elements)
        {
            _spacing = spacing;
            OrderElements();
            _rec = new Rectangle(x, y, Width, Height);
        }

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
        /// Returns height of the VBox.
        /// </summary>
        /// <returns></returns>
        private int CalcHeight()
        {
            // VBox with no elements has a height of 0.
            if (_elements.Count == 0)
                return 0;

            int height = 0;

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
        private int WidthWidestElement()
        {
            if (_elements.Count == 0)
                return -1;

            int width = _elements[0].Width;

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
            if (_elements.Count == 0)
                return;

            // Position first element at upper left corner of VBox.
            _elements[0].X = this._x;
            _elements[0].Y = this._y;

            if (_elements.Count == 1)
                return;

            // Position every element (except first) at VBox.X and VBox.Y + previousElement.Y + spacing.
            // Makes it so that elements aren't stacked on top of each other and variables spacing is possible.
            for (int i = 1; i < _elements.Count; i++)
            {
                _elements[i].X = this._x;
                _elements[i].Y = _elements[i - 1].Y + _elements[i - 1].Height + _spacing;
            }
        }

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
