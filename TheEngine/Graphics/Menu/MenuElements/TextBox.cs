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
        private string _parsedText;
        private SpriteFont _font;
        private Color _color;
        private float _opacity;

        /// <summary>
        /// Stores Color data for drawing the TextBox bounds.
        /// </summary>
        private Color[] _data;

        /// <summary>
        /// Stores Texture2D for drawing the TextBox bounds.
        /// </summary>
        private Texture2D _texture;

        /// <summary>
        /// string Text of this TextBox. 
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                _parsedText = ParseText(_text);
            }
        }

        public TextBox(RectangleF bounds, string text, SpriteFont font, Color color, float opacity = 1f) 
        : base (bounds)
        {
            _text = text;
            _font = font;
            _color = color;
            _opacity = opacity;
            _parsedText = ParseText(text);
            _texture = Contents.Texture(_bounds.Size);

            // Create Color data the size of bounds
            _data = new Color[(int)bounds.Width * (int)bounds.Height];

            // Set Color data's color.
            for (int i = 0; i < _data.Length; i++)
                _data[i] = color;

            // Set Color data to Texture2D.
            _texture.SetData(_data);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            Primitives.DrawRectangle(_bounds, _texture, spriteBatch, _opacity);
            spriteBatch.DrawString(_font, ParseText(_text), _bounds.Location, Color.White);
        }

        // TODO: Single Word Word-Wrapping
        /// <summary>
        /// Multi-Word-Wrapping
        /// Single-Word-Wrapping
        /// Inserts a newline once the length of the current line plus the length of the current word is longer than the
        /// width of the text box, and it repeats until there are no more words to process.
        /// </summary>
        /// <returns></returns>
        private string ParseText(string text)
        {
            string line = string.Empty;
            string returnString = string.Empty;
            string[] wordArray = text.Split(' ');

            foreach (string word in wordArray)
            {
                //// Single-Word-Wrapping
                //if (_font.MeasureString(word).Length() > _bounds.Width)
                //{
                //    char[] wordChars = word.ToCharArray();
                //    string firstHalf = string.Empty;
                //    string secondHalf = string.Empty;

                //    // Build string char by char.
                //    for (int i = 0; i < wordChars.Length; i++)
                //    {
                //        firstHalf += wordChars[i];

                //        // String is wider than bounds => Put firstHalf on currentLine, secondHalf on nextLine.
                //        if (_font.MeasureString(firstHalf).Length() > _bounds.Width)
                //        {
                //            firstHalf = firstHalf.Remove(firstHalf.Length - 2, 2);
                //            firstHalf = firstHalf.Insert(firstHalf.Length, "-");

                //            returnString += firstHalf + '\n';

                //            for (int y = i; y < wordChars.Length; y++)
                //                secondHalf += wordChars[y];

                //            returnString += secondHalf;

                //            break;
                //        }
                //    }
                //}

                // Multi-Word-Wrapping

                if (_font.MeasureString(line + word).Length() > _bounds.Width)
                {
                    returnString += line + '\n';
                    line = string.Empty;
                }

                line += word + ' ';
            }

            return returnString + line;
        }

        public override void MouseHoverReaction()
        {
            // if (IsMouseHover())
        }

        public override void CursorReaction(GameTime gameTime)
        {
            // throw new NotImplementedException();
        }
    }
}