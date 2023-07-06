using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StateVariables svb;



    public float speed = 6f;

    [HideInInspector]
    public Vector2 moveDir;

    public void Update()
    {

        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        moveDir = moveDir.normalized;
        svb.SetValue("walkVector", moveDir.magnitude.ToString());
        if (Input.GetKeyDown(KeyCode.Space))
        {
            svb.ActualSetTrigger("jump");
        }
    }

}
