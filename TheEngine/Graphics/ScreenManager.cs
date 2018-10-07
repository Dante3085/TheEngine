using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheEngine.Graphics
{
    public static class ScreenManager
    {
        #region MemberVariables

        public static int ScreenWidth;
        public static int ScreenHeight;

        #endregion

        #region Methods

        public static void Update()
        {
            // Update Screen Size.
            ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        #endregion
    }
}