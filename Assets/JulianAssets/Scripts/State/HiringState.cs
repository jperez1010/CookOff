using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiringState : TurnState
{
    public override TurnState nextState { get => new RoundState(); }
    public float totalTime = 30;

    public override void EnterState(TurnState previousState)
    {
        timer = totalTime;
        Debug.Log("Entering Hiring State");
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
