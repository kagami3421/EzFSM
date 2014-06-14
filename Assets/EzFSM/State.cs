using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * State Class and Transition Class
 * Author : Kagami
*/

public abstract class State
{
    private Dictionary<string, Transition> transList = new Dictionary<string, Transition>();

    public void AddTransition(State desState, string TransID)
    {
        if (desState == null)
        {
            Debug.LogError("Don't assign bullshit null guy!");
            return;
        }

        Transition _tmpTrans;

        if (transList.TryGetValue(TransID, out _tmpTrans))
        {
            Debug.LogError("Already have transtion which be added.");
            return;
        }
        else
        {
            _tmpTrans = new Transition(this, desState);
            transList.Add(TransID, _tmpTrans);
        }
    }

    public void RemoveTransition(string TransID)
    {
        Transition _remove;
        if (transList.TryGetValue(TransID, out _remove))
        {
            transList.Remove(TransID);
        }
        else
        {
            Debug.LogError("Can't find transtion which be deleted.");
        }
    }

    public void ChangeTransitionDest(State newDestination, string TransID)
    {
        if (newDestination == null)
        {
            Debug.LogError("Don't assign bullshit null guy!");
            return;
        }

        Transition _tmpTrans;
        if (transList.TryGetValue(TransID, out _tmpTrans))
        {
            _tmpTrans.Destination = newDestination;
        }
        else
        {
            Debug.LogError("Can't find transtion which be changed.");
        }
    }

    public Transition GetTransition(string TransitionID)
    {
        Transition _tmp;
        if (transList.TryGetValue(TransitionID, out _tmp))
        {
            return _tmp;
        }

        return _tmp;
    }

    public abstract void Enter(GameObject Go);
    public abstract void Stay(GameObject Go);
    public abstract void Exit(GameObject Go);
}

public struct Transition
{
    public Transition(State or, State des)
    {
        Origin = or;
        Destination = des;
    }

    public State Origin;
    public State Destination;
}
