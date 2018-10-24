using System;
using Microsoft.Xna.Framework;
using TheEngine.Graphics.Primitive;
using TheEngine.Graphics.Sprites;

namespace TheEngine.Graphics.Menu.MenuElements
{
    ///// <summary>
    ///// MenuButton that uses an AnimatedSprite to animate itself.
    ///// </summary>
    //public class AnimatedMenuButton : AnimatedMenuElement
    //{
    //    #region MemberVariables

    //    #endregion

    //    #region Properties

    //    public override RectangleF RectangleF => _animSprite.BoundingBox;

    //    #endregion

    //    public AnimatedMenuButton(string name, AnimatedSprite animSprite, int x = 0, int y = 0, Action functionality = null) 
    //        : base(name, animSprite, x, y, functionality)
    //    {
    //    }

    //    public override void Update(GameTime gameTime)
    //    {
    //        base.Update(gameTime);

    //        if (OnLeftMouseClick())
    //            ExecuteFunctionality();
    //    }

    //    public override void MouseHoverReaction()
    //    {
    //        _animSprite.SetAnimation(IsMouseHover() ? EAnimation.MouseHover : EAnimation.Idle);
    //        if (IsMouseHover())
    //            _animSprite.SetAnimation(EAnimation.MouseHover);
    //        else if ((!IsMouseHover()) && (!_cursorOnIt))
    //            _animSprite.SetAnimation(EAnimation.Idle);
    //    }

    //    public override void CursorReaction(GameTime gameTime)
    //    {
    //        if (_cursorOnIt)
    //            _animSprite.SetAnimation(EAnimation.MouseHover);
    //    }
    //}
}
