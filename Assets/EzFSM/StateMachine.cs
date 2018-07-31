using UnityEngine;
using System.Collections.Generic;

/*
 * State Machine Class , only for inheriting
 * Author : Kagami
*/

namespace Kagami.EasyFSM
{
    public abstract class StateMachine : MonoBehaviour
    {
        private State currentState;
        private Dictionary<string, State> states = new Dictionary<string, State>();

        protected void Start()
        {
            InitFSM();

            if(currentState != null)
                currentState.Enter();
        }

        protected void FixedUpdate()
        {
            if (currentState == null)
                return;

            State nextState = currentState.Stay();
            if (nextState != null)
            {
                currentState.Exit();
                currentState = nextState;
                nextState.Enter();
            }
        }

        /// <summary>
        /// Init State Machine
        /// </summary>
        public virtual void InitFSM()
        {

        }

        protected void AddState(string Name , State state , bool defaultState)
        {
            if (states.ContainsKey(Name))
                Debug.LogErrorFormat("State: {0} Is Exist!", Name);
            else
            {
                states.Add(Name, state);

                if(defaultState)
                    currentState = state;
            }
        }

        /// <summary>
        /// Get State by Name
        /// </summary>
        public State GetState(string StateName)
        {
            if (states.ContainsKey(StateName))
                return states[StateName];
            else
            {
                Debug.LogErrorFormat("State: {0} Not Found!", StateName);
                return null;
            }
        }

        /// <summary>
        /// Force Change State from AnyState
        /// </summary>
        public void ForceChangeState(string StateName)
        {
            State nextState = null;
            if (states.TryGetValue(StateName, out nextState))
            {
                currentState.Exit();
                currentState = nextState;
                nextState.Enter();
            }
            else
                Debug.LogErrorFormat("State: {0} Not Found!", StateName);
        }
    }
}