using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundState : TurnState
{
    public override TurnState nextState { get => new HiringState(); }
    public float totalTime = 60;

    public override void EnterState(TurnState previousState)
    {
        timer = totalTime;
        Debug.Log("Entering Round State");
    }
    public override TurnState Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            return this.Transition();
        }
        return null;
    }
    public override TurnState Transition()
    {
        return this.nextState;
    }
}
