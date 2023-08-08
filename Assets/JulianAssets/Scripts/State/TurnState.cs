using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnState
{
    public abstract TurnState nextState
    {
        get;
    }
    public float timer;

    public abstract void EnterState(TurnState previousState);
    public abstract TurnState Update();
    public abstract TurnState Transition();
}
