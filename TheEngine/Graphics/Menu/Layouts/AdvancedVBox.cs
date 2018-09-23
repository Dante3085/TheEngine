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
    /// ScreenSize responsive VBox.
    /// </summary>
    public class AdvancedVBox : Layout
    {
        #region MemberVariables

        private HBox _hBox;

        #endregion
        #region Properties

        public override int Width { get; }
        public override int Height { get; }
        public override Rectangle Rectangle { get; }
        public override int Spacing { get; set; }

        #endregion

        #region Methods

        public AdvancedVBox(int x, int y, Action functionality = null, int verticalOffset = 0,
            int horizontalOffset = 0, params MenuElement[] elements) : base(x, y, functionality, elements)
        {
            // TODO
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void OrderElements()
        {
            //// Check if furthest to right VBox that resides in HBox is higher
            //// than screenHeight.
            //List<MenuElement> hBoxElements = _hBox.Elements;
            //for (int i = 0; i < hBoxElements.Count; i++)
            //{
            //    if (hBoxElements[i].Y + hBoxElements[i].Height > Game1.screenHeight)
            //    {
            //        VBox vbox = new VBox(elements: new MenuElement[hBoxElements.Count - i]);
            //        for (int y = 0; i < hBoxElements.Count; y++)
            //            vbox.Elements.Add(hBoxElements[y]);
            //        hBoxElements.Add(vbox);
            //        break;
            //    }
            //}

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _hBox.Draw(spriteBatch);
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

        #endregion
    }
}
