using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    Rigidbody rb;

    public override void EnterState()
    {
        base.EnterState();
        rb = Gowner.GetComponent<Rigidbody>();
    }

    public override void Tick(float delta)
    {
        base.Tick( delta);
        Vector2 dir = Gowner.GetComponent<PlayerController>().moveDir;
        Vector3 pDir = new Vector3(dir.x*10, rb.velocity.y, dir.y*10);

        rb.velocity = pDir;
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
