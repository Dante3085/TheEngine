using System;

namespace TheEngine.Graphics.Menu.MenuElements
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException() : base()
        { }

        public ElementNotFoundException(string message) : base(message)
        { }
    }
}
