using System;
using TheEngine.Logging;

namespace TheEngine.StateManagement
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
