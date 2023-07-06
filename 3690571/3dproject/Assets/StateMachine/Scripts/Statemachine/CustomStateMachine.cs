using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomStateMachine : MonoBehaviour
{
    public State activeState;

    [SerializeField]
    private State[] states;

    public StateVariables svb;

    private void Start()
    {
        for (int i = 0; i < states.Length; i++)
        {
            states[i].SetOwner(this.gameObject);
        }
        activeState.EnterState();
    }

    private void Update()
    {//Set the current state tick fuction and also handle transition automatically
        if (activeState != null)
        {
            activeState.Tick(Time.deltaTime);
            activeState.HandleTransition(svb);
        }
    }

    public void SetData()
    {
        
    }

    public void ChangeState(State newState)
    {
        if (activeState)
        {
            activeState.canTick = false;
            activeState.ExitState();
        }
        activeState = newState;
        activeState.EnterState();
        activeState.canTick = true;
    }
}
