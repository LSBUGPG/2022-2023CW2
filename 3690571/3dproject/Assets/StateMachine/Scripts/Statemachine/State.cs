using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField]
    private List<StateData> canTransitionTO = new List<StateData>();

    protected GameObject Gowner;

    protected CustomStateMachine owningObject;

    [HideInInspector]
    public bool canTick = false;

    protected float startTime;

    public void SetOwner(GameObject owner)
    {
        Gowner = owner;
        owningObject = owner.GetComponent<CustomStateMachine>();
        
    }

    public virtual void EnterState()
    {
        if (!canTick) return;
        startTime= Time.time;

    }   

    public virtual void PhysicsTick()
    {

    }

    public virtual void Tick(float delta)
    {
        
    }

    public virtual void ExitState() 
    {
        
    }

    public void HandleTransition(StateVariables svb)
    {
        for (int i = 0; i < canTransitionTO.Count; i++)
        {
            if (canTransitionTO[i].returnState(svb))
            {
                owningObject.ChangeState(canTransitionTO[i].returnState(svb));
            }
        }
   
    }

    private bool CheckBool(bool checkFor)
    {


        return true;
    }
}
