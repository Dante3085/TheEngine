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
    /// VBox that handles being taller than the ScreenHeight.
    /// Uses HBox to horizontally place VBoxes in case of being taller than the ScreenHeight.
    /// </summary>
    public class AdvancedVBox : Layout
    {
        #region MemberVariables

        /// <summary>
        /// HBox that stores several VBoxes.
        /// </summary>
        private HBox _hBox;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the AdvancedVBox's Width.
        /// </summary>
        public override int Width => CalcWidth();

        /// <summary>
        /// Returns the AdvancedVBox's Height.
        /// </summary>
        public override int Height => CalcHeight();

        /// <summary>
        /// Returns Bounding Rec of AdvancedVBox.
        /// </summary>
        public override Rectangle Rectangle => _hBox.Rectangle;

        /// <summary>
        /// Returns, sets spacing inside AdvancedVBox.
        /// </summary>
        public override int Spacing
        {
            get => _hBox.Spacing;
            set => _hBox.Spacing = value;
        }

        #endregion

        #region Methods

        public AdvancedVBox(int x, int y, int horiSpacing, int vertSpacing, params MenuElement[] elements)
        {
            _hBox = new HBox(x, y, null, horiSpacing, new VBox(spacing: vertSpacing, elements: elements));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach(MenuElement m in _hBox.Elements)
                m.Update(gameTime);
        }

        public override void OrderElements()
        {
            //var lastBox = _hBox.Elements[_hBox.Elements.Count - 1];
            //if (lastBox.Height > ScreenManager.ScreenHeight)
            //{
            //    var lastEl = lastBox[lastBox.]
            //    _hBox.Elements.Add(new VBox(elements: new MenuElement[]));
            //}
        }                                             

        private int CalcWidth()
        {
            int width = 0;
            foreach (MenuElement m in _hBox.Elements)
                width += m.Width;
            return width;
        }

        private int CalcHeight()
        {
            int height = 0;
            foreach (MenuElement m in _hBox.Elements)
                height += m.Height;
            return height;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _hBox.Draw(spriteBatch);
        }

        public override void MouseHoverReaction()
        {
            throw new NotImplementedException();
        }

        public override void CursorReaction(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
