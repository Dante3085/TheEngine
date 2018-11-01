using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.Graphics.Menu.Layouts;
using TheEngine.Graphics.Primitive;

namespace TheEngine.Graphics.Menu.MenuElements
{
    public class DropBox : MenuElement
    {
        private VBox _vBox;
        private TextButton _head;
        private List<TextButton> _selection;
        private bool _expanded = false;

        public DropBox(RectangleF bounds, List<TextButton> selection)
        : base(bounds)
        {
            _head = selection[0];
            _selection = selection;
            _selection.Remove(_head);
            _vBox = new VBox(bounds, 0, elements: _head);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Game1.gameConsole.Log(_vBox.Bounds.ToString());
            _vBox.Bounds = _bounds;

            if (OnLeftMouseClick())
            {
                if (!_expanded)
                {
                    _vBox.Elements.AddRange(_selection);
                    _expanded = true;
                }
                else
                {
                    List<MenuElement> elements = _vBox.Elements;
                    foreach (TextButton t in _selection)
                        elements.Remove(t);
                    _expanded = false;
                }
            }
            _vBox.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            _vBox.Draw(spriteBatch);
        }

        public override void MouseHoverReaction()
        {
            // throw new NotImplementedException();
        }

        public override void CursorReaction(GameTime gameTime)
        {
            // throw new NotImplementedException();
        }
    }
}
