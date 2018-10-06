using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine;
using TheEngine.DataManagement;
using TheEngine.Input;

namespace TheEngine.Graphics.Menu.MenuComponents
{
    /// <summary>
    /// Interactive and locatable Text, primarily used in Menus.
    /// </summary>
    public class Text : MenuElement
    {
        #region MemberVariables

        /// <summary>
        /// Text's text.
        /// </summary>
        private string _text;

        /// <summary>
        /// SpriteFont used while drawing this Text.
        /// </summary>
        private SpriteFont _activeSpriteFont = Contents.Arial12;

        /// <summary>
        /// Stores various fonts this Text can use.
        /// </summary>
        private Dictionary<string, SpriteFont> _fonts = new Dictionary<string, SpriteFont>()
        {
            { "noHover", Contents.Arial12 },
            { "hover", Contents.Arial15 }
        };

        /// <summary>
        /// Stores size of this Text.
        /// </summary>
        private Vector2 _textSize;

        /// <summary>
        /// Only used for DrawString.
        /// </summary>
        private Vector2 _position = new Vector2();
        private Color _color = Color.DarkSlateGray;
        private Color _colorHover = Color.DeepSkyBlue;

        #region TextRectangle

        private Rectangle _textRec;
        private Rectangle[] _textRecLines = {new Rectangle(), new Rectangle(), new Rectangle(), new Rectangle()};
        public bool _drawTextRec;

        #endregion

        private int currentAnim = 0;
        private double elapsedTime = 0;
        private bool forward = true;

        #endregion
        #region Properties

        public override int Width => _textRec.Width;
        public override int Height => _textRec.Height;
        public override Rectangle Rectangle => _textRec;

        #endregion
        #region Methods

        /// <summary>
        /// Constructs a Text with given fonts, text, position and functionality.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fontNoHover"></param>
        /// <param name="fontHover"></param>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="functionality"></param>
        public Text(SpriteFont fontNoHover, SpriteFont fontHover, int x = 0, int y = 0, string text = "", Action functionality = null) 
            : base(x, y, functionality)
        {
            

            _text = text;
            _activeSpriteFont = Contents.Arial12;

            _textSize = _activeSpriteFont.MeasureString(_text);
            _textRec = new Rectangle(_x, _y, (int)_textSize.X, (int)_textSize.Y);
        }

        /// <summary>
        /// Constructs a text with given text, position and functionality.
        /// Fonts will be automatically set depending on screen size.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="functionality"></param>
        public Text(int x = 0, int y = 0, string text = "", Action functionality = null) 
            : base(x, y, functionality)
        {
            _activeSpriteFont = Contents.Arial12;

            _text = text;

            _textSize = _activeSpriteFont.MeasureString(_text);
            _textRec = new Rectangle(_x, _y, (int)_textSize.X, (int)_textSize.Y);
        }

        public void SetColor(Color color)
        {
            _color = color;
        }

        public void SetColorHover(Color colorHover)
        {
            _colorHover = colorHover;
        }

        public void SetText(string text)
        {
            _text = text;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _textSize = _activeSpriteFont.MeasureString(_text);

            // Update Rec position.
            _textRec.X = _x;
            _textRec.Y = _y;

            // Update Rec size.
            _textRec.Width = (int)_textSize.X;
            _textRec.Height = (int)_textSize.Y;

            // Update Vector2 for DrawString.
            _position.X = _x;
            _position.Y = _y;

            if (OnLeftMouseClick())
                ExecuteFunctionality();
        }

        //public void Animate(GameTime gameTime, int speed)
        //{
        //    elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
        //    if (elapsedTime >= speed)
        //    {
        //        elapsedTime = 0;
        //        if (forward)
        //        {
        //            currentAnim++;
        //            if (currentAnim == fonts.Length)
        //                forward = false;
        //        }
        //        if(!forward)
        //        {
        //            currentAnim--;
        //            if (currentAnim == -1)
        //            {
        //                currentAnim++;
        //                forward = true;
        //            }
        //        }
        //    }

        //    _activeSpriteFont = fonts[currentAnim];
        //}

        public override void ExecuteFunctionality()
        {
            if (_functionality != null)
                _functionality();
        }

        /// <summary>
        /// Handles Reactions that MenuButton will have on MouseHover.
        /// </summary>
        public override void MouseHoverReaction()
        {
            _activeSpriteFont = IsMouseHover() ? _fonts["hover"] : _fonts["noHover"];
        }

        public override void CursorReaction(GameTime gameTime)
        {
            //if (_cursorOnIt)
            //{
            //    _activeSpriteFont = _spriteFontHover;
            //    Animate(gameTime, 200);
            //}
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_activeSpriteFont, _text, _position, CursorOnIt == true ? _colorHover : _color);

            if (MenuElement._drawRecs)
                Primitives.DrawRectangleOutline(_textRec, _textRecLines, Contents.rectangleTex, Color.Red, spriteBatch);
        }

        #endregion
    }
}
