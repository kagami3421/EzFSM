using UnityEngine;
using System.Collections.Generic;

/*
 * State Class and Transition Class
 * Author : Kagami
*/

namespace Kagami.EasyFSM
{
    public abstract class State
    {
        public State(StateMachine context)
        {
            _context = context;
        }

        protected StateMachine _context;

        public virtual void Enter()
        {

        }

        public virtual State Stay()
        {
            return null;
        }

        public virtual void Exit()
        {

        }
    }
}
