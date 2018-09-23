using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEngine.Logging;

namespace TheEngine.StateMachine
{
    public class FiniteStateMachineException : Exception
    {
        public FiniteStateMachineException() : base()
        {
            Logger.Log("FiniteStateMachineException");
        }

        public FiniteStateMachineException(string msg) : base(msg)
        {
            Logger.Log("FiniteStateMachineException: " + msg);
        }
    }
}
