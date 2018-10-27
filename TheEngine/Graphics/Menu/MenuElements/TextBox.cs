using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.DataManagement;
using TheEngine.Graphics.Menu.MenuElements;
using TheEngine.Graphics.Primitive;

/**
 * Web-References:
 *      1. https://danieltian.wordpress.com/2008/12/24/xna-tutorial-typewriter-text-box-with-proper-word-wrapping-part-1/
 */

namespace TheEngine.Graphics.Menu.MenuElements
{
    /// <summary>
    /// Displays Text(Also: Wrapping, Scrolling, etc.)
    /// </summary>
    public class TextBox : MenuElement
    {

        private string _text;
        private SpriteFont _font;
        private Color _color;
        private float _opacity;
        private Color[] _colorData;

        // TODO: Width and Height unnecessary. See also: MenuElement Width and Height.
        public override float Width => _bounds.Width;
        public override float Height => _bounds.Height;
        public override RectangleF RectangleF => _bounds;

        public TextBox(RectangleF bounds, string text, SpriteFont font, Color color, float opacity = 1f) 
        : base (bounds)
        {
            _text = text;
            _font = font;
            _color = color;
            _opacity = opacity;
            _colorData = new Color[(int)bounds.Width * (int)bounds.Height];
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Primitives.DrawRectangle(_bounds, Contents.Texture(_bounds.Size), _colorData, _color, spriteBatch, _opacity);
            Primitives.DrawRectangle(_bounds, Contents.Texture(_bounds.Size), _colorData, _color, spriteBatch, _opacity);
            Primitives.DrawRectangle(_bounds, Contents.Texture(_bounds.Size), _colorData, _color, spriteBatch, _opacity);
            Primitives.DrawRectangle(_bounds, Contents.Texture(_bounds.Size), _colorData, _color, spriteBatch, _opacity);
            Primitives.DrawRectangle(_bounds, Contents.Texture(_bounds.Size), _colorData, _color, spriteBatch, _opacity);
            spriteBatch.DrawString(_font, ParseText(_text), _bounds.Location, Color.White);
        }

        /// <summary>
        /// Word-Wrapping...
        /// Inserts a newline once the length of the current line plus the length of the current word is longer than the
        /// width of the text box, and it repeats until there are no more words to process.
        /// </summary>
        /// <returns></returns>
        private string ParseText(string text)
        {
            string line = string.Empty;
            string returnString = string.Empty;
            string[] wordArray = _text.Split(' ');

            foreach (string word in wordArray)
            {
                if (_font.MeasureString(line + word).Length() > _bounds.Width)
                {
                    returnString = returnString + line + '\n';
                    line = string.Empty;
                }

                line = line + word + ' ';
            }

            return returnString + line;
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