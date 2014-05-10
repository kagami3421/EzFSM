using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class StateMachine : MonoBehaviour
{
    private Dictionary<string, State> stateList = new Dictionary<string, State>();

    public string currentStateID
    {
        get
        {
            return currentSID;
        }
    }
    private string currentSID;

    public State CurrentState
    {
        get
        {
            return currentS;
        }
    }
    private State currentS;

    void FixedUpdate()
    {
        //Debug.Log(currentS);
        if (currentS != null)
            currentS.Stay(this.gameObject);
    }

    public void AddState(State target, string targetID)
    {
        if (target == null)
        {
            Debug.LogError("Don't assign bullshit null guy!");
            return;
        }

        State _tmpState;
        if (stateList.TryGetValue(targetID, out _tmpState))
        {
            Debug.LogError("Already have state which be added.");
            return;
        }
        else
        {
            if (stateList.Count == 0)
            {
                currentSID = targetID;
                currentS = target;
            }

            stateList.Add(targetID, target);
        }
    }

    public void RemoveState(string targetID)
    {
        State _remove;
        if (stateList.TryGetValue(targetID, out _remove))
        {
            stateList.Remove(targetID);
        }
        else
        {
            Debug.LogError("Can't find state which be deleted.");
        }
    }

    public void ChangeState(string TransitionID)
    {
        if (TransitionID.Length == 0)
        {
            Debug.LogError("Empty string!");
            return;
        }

        Transition _tmp = currentS.GetTransition(TransitionID);

        if (_tmp.Destination == null)
        {
            Debug.LogError("Can't find suitable transition!");
        }
        else
        {
            foreach (KeyValuePair<string, State> e in stateList)
            {
                if (e.Value == _tmp.Destination)
                {
                    currentS.Exit(this.gameObject);

                    currentS = _tmp.Destination;

                    currentS.Enter(this.gameObject);

                    break;
                }
            }
        }
    }

    void OnDestory()
    {
        stateList.Clear();
        currentS = null;
        currentSID = "";
    }
}