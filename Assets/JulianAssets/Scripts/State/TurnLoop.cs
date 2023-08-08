using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnLoop : MonoBehaviour
{
    public TurnState currentState;
    public TMP_Text text;

    void Start()
    {
        currentState = new RoundState();
        currentState.EnterState(null);
    }

    void Update()
    {
        text.text = currentState.timer.ToString("F2");
        TurnState nextState = currentState.Update();
        if (nextState != null)
        {
            TurnState previousState = currentState;
            currentState = nextState;
            currentState.EnterState(previousState);
        }
    }
}
