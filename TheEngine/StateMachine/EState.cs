using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEngine.StateMachine
{
    /// <summary>
    /// Enum used by FiniteStateMachine to switch between States.
    /// </summary>
    public enum EState
    {
        EmptyState,
        MainMenuState,
        TestLevelState,
        InventoryState,
    }
}
