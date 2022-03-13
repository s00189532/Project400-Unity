using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Node_Base : ScriptableObject
{
    public enum State
    {
        Running,
        Failure,
        Success
    }

    public State state = State.Running;
    public bool started = false;

    public string guid;

    public State Update()
    {
        if (!started)
        {
            OnStart();
            started = true;
        }

        state = OnUpdate();

        if (state != State.Running)
        {
            OnStop();
            started = false;
        }

        return state;
    }

    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract State OnUpdate();
}
