using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEngine.StateMachine
{
    /// <summary>
    /// Describes Objects that can interact with each other.
    /// </summary>
    public interface IInteractable
    {
        void Interact(IInteractable other);
        void HandleInteraction();
    }
}
