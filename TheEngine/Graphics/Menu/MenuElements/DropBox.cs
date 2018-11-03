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
        private Dictionary<string, Action> _selection;
        private List<TextButton> _textButtons = new List<TextButton>();
        private bool _expanded = false;

        public DropBox(RectangleF bounds, Color color, Dictionary<string, Action> selection
            /*List<TextButton> textButtons*/)
        : base(bounds)
        {
            _selection = selection;

            foreach (string s in selection.Keys)
                _textButtons.Add(new TextButton(new RectangleF(0, 0, bounds.Width, bounds.Height), 
                    s, color, selection[s]));

            _head = _textButtons[0];
            _textButtons.Remove(_head);
            _vBox = new VBox(bounds, 0, elements: _head);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _vBox.Bounds = _bounds;

            if (OnLeftMouseClick())
            {
                if (!_expanded)
                {
                    _vBox.Elements.AddRange(_textButtons);
                    _expanded = true;
                }
                else
                {
                    List<MenuElement> elements = _vBox.Elements;
                    foreach (TextButton t in _textButtons)
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
