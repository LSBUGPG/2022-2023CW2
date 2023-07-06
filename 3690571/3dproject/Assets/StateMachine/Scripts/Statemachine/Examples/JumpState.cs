using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    Rigidbody rb;

    public override void EnterState()
    {
        base.EnterState();
        rb = Gowner.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up *5, ForceMode.Impulse);
    }

    public override void Tick(float delta)
    {
        base.Tick(delta);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
