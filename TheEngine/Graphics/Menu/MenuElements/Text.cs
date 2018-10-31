using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheEngine.DataManagement;
using TheEngine.Graphics.Primitive;

namespace TheEngine.Graphics.Menu.MenuElements
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
        // private Vector2 _textSize;

        /// <summary>
        /// Only used for DrawString.
        /// </summary>
        // private Vector2 _position = new Vector2();
        private Color _color = Color.DarkSlateGray;
        private Color _colorHover = Color.DeepSkyBlue;

        #region TextRectangle

        // private RectangleF _textRec;
        public bool _drawTextRec;

        #endregion

        private int currentAnim = 0;
        private double elapsedTime = 0;
        private bool forward = true;

        #endregion
        #region Properties

        /// <summary>
        /// Returns the string text of this Text.
        /// </summary>
        public string StringText
        {
            get => _text;
            set => _text = value;
        }

        #endregion
        #region Methods

        /// <summary>
        /// Constructs a Text with given fonts, text, position and functionality.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="fontNoHover"></param>
        /// <param name="fontHover"></param>
        /// <param name="text"></param>
        /// <param name="functionality"></param>
        public Text(RectangleF bounds, SpriteFont fontNoHover, SpriteFont fontHover, string text = "", Action functionality = null) 
            : base(bounds, functionality)
        {
            _text = text;
            _activeSpriteFont = fontNoHover;

            _bounds.Size = _activeSpriteFont.MeasureString(_text);
        }

        /// <summary>
        /// Constructs a text with given text, position and functionality.
        /// Fonts will be automatically set depending on screen size.</summary>
        /// <param name="position"></param>
        /// <param name="text"></param>
        /// <param name="functionality"></param>
        public Text(RectangleF bounds, string text = "", Action functionality = null) 
            : base(bounds, functionality)
        {
            _text = text;
            _activeSpriteFont = Contents.Arial12;

            _bounds.Size = _activeSpriteFont.MeasureString(_text);
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
            _bounds.Size = _activeSpriteFont.MeasureString(_text);

            if (OnLeftMouseClick())
                _functionality();
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
            base.Draw(spriteBatch);

            spriteBatch.DrawString(_activeSpriteFont, _text, _bounds.Location, 
                CursorOnIt == true ? _colorHover : _color);
        }

        #endregion
    }
}
