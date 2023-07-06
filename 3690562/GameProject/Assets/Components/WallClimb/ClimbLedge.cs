using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLedge : MonoBehaviour
{
    private int LedgeLayer;
    public Camera cam;
    private float playerHeight = 3.8f;
    private float playerRadius = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        LedgeLayer = LayerMask.NameToLayer("Ledge");
        LedgeLayer = ~LedgeLayer;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Climb()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out var firstHit, 1f, LedgeLayer))
        {
            print("climbable surface ahead");
            if (Physics.Raycast(firstHit.point + (cam.transform.forward * playerRadius) + (Vector3.up * 0.6f * playerHeight), Vector3.down, out var secondHit, playerHeight))
            {
                print("found place to land");
                StartCoroutine(LerpLedgeClimb(secondHit.point + Vector3.up * 0.5f * playerHeight, 0.8f));
            }
        }
    }

    IEnumerator LerpLedgeClimb(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
