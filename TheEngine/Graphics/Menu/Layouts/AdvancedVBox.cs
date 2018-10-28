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
    ///// <summary>
    ///// VBox that handles being taller than the ScreenHeight.
    ///// Uses HBox to horizontally place VBoxes in case of being taller than the ScreenHeight.
    ///// </summary>
    //public class AdvancedVBox : Layout
    //{
    //    #region MemberVariables

    //    /// <summary>
    //    /// HBox that stores several VBoxes.
    //    /// </summary>
    //    private HBox _hBox;

    //    #endregion

    //    #region Properties

    //    /// <summary>
    //    /// Returns, sets spacing inside AdvancedVBox.
    //    /// </summary>
    //    public override int Spacing
    //    {
    //        get => _hBox.Spacing;
    //        set => _hBox.Spacing = value;
    //    }

    //    #endregion

    //    #region Methods

    //    public AdvancedVBox(RectangleF bounds, int horiSpacing, int vertSpacing, params MenuElement[] elements)
    //    : base(bounds)
    //    {
    //        _hBox = new HBox(bounds, null, horiSpacing, new VBox(bounds, spacing: vertSpacing, elements: elements));
    //    }

    //    public override void Update(GameTime gameTime)
    //    {
    //        base.Update(gameTime);

    //        foreach(MenuElement m in _hBox.Elements)
    //            m.Update(gameTime);
    //    }

    //    public override void OrderElements()
    //    {
    //        //var lastBox = _hBox.Elements[_hBox.Elements.Count - 1];
    //        //if (lastBox.Height > ScreenManager.ScreenHeight)
    //        //{
    //        //    var lastEl = lastBox[lastBox.]
    //        //    _hBox.Elements.Add(new VBox(elements: new MenuElement[]));
    //        //}
    //    }                                             

    //    private float CalcWidth()
    //    {
    //        float width = 0;
    //        foreach (MenuElement m in _hBox.Elements)
    //            width += m.Bounds.Width;
    //        return width;
    //    }

    //    private float CalcHeight()
    //    {
    //        float height = 0;
    //        foreach (MenuElement m in _hBox.Elements)
    //            height += m.Bounds.Height;
    //        return height;
    //    }

    //    public override void Draw(SpriteBatch spriteBatch)
    //    {
    //        _hBox.Draw(spriteBatch);
    //    }

    //    public override void MouseHoverReaction()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void CursorReaction(GameTime gameTime)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    #endregion
    //}
}
