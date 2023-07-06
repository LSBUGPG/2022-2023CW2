using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float speed = 1f;
    float end;

        // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorWayClose;
    }

    private void OnDoorwayOpen()
    {
        end = 3f;
    }

    private void OnDoorWayClose()
    {
        end = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 EndPos = transform.localPosition;
        EndPos.y = end;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, EndPos, speed * Time.deltaTime);
    }
}
