using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TheEngine.Graphics.Menu.MenuComponents;

namespace TheEngine.Graphics.Menu.Layouts
{
    /// <summary>
    /// A Layout organizes MenuElements on the screen.
    /// </summary>
    public abstract class Layout : MenuElement
    {
        #region MemberVariables

        /// <summary>
        /// Stores all MenuElements of this Layout.
        /// </summary>
        protected List<MenuElement> _elements = new List<MenuElement>();

        #endregion
        #region Properties

        /// <summary>
        /// Returns a List with all MenuElements of this Layout.
        /// </summary>
        public List<MenuElement> Elements => _elements;

        /// <summary>
        /// Space between each MenuElement of the Layout.
        /// </summary>
        public abstract int Spacing { get; set; }

        /// <summary>
        /// Each Layout must specify code for uniquely ordering it's MenuElements on the screen.
        /// </summary>
        public abstract void OrderElements();

        #endregion
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="functionality"></param>
        /// <param name="elements"></param>
        protected Layout(int x = 0, int y = 0, Action functionality = null, params MenuElement[] elements) : 
            base(x, y, functionality)
        {
            _x = x;
            _y = y;
            _elements.AddRange(elements);
        }

        /// <summary>
        /// Updates and orders Layout Elements.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            foreach (MenuElement m in _elements)
                m.Update(gameTime);
            OrderElements();
        }

        #endregion
    }
}
