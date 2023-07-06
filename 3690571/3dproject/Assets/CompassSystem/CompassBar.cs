using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassBar : MonoBehaviour
{
    public RectTransform compassBarTransform;

    public RectTransform objectiveMarkerTransform;
    public RectTransform northMarkerTransform;
    public RectTransform southMarkerTransform;
    public RectTransform eastMarkerTransform;
    public RectTransform westMarkerTransform;

    public Transform cameraObjectTransform;
    public Transform objectiveObjecttransform;

    // Update is called once per frame
    void Update()
    {
        SetMarkerPosition(objectiveMarkerTransform, objectiveObjecttransform.position);
        SetMarkerPosition(northMarkerTransform, Vector3.forward * 10000);
        SetMarkerPosition(southMarkerTransform, Vector3.back * 10000);
        SetMarkerPosition(eastMarkerTransform, Vector3.right * 10000);
        SetMarkerPosition(westMarkerTransform, Vector3.left * 10000);
    }

    private void SetMarkerPosition(RectTransform markerTransform, Vector3 worldPosition)
    {
        Vector3 directionToTarget = worldPosition - cameraObjectTransform.position;
        float angle = Vector2.SignedAngle(new Vector2(directionToTarget.x, directionToTarget.z), new Vector2(cameraObjectTransform.transform.forward.x, cameraObjectTransform.transform.forward.z));
        float compassPositionX = Mathf.Clamp(2 * angle / Camera.main.fieldOfView, -1, 1);
        markerTransform.anchoredPosition = new Vector2(compassBarTransform.rect.width / 2 * compassPositionX, 0);
    }

    public void SetObjective(Transform newObjective)
    {
        objectiveObjecttransform = newObjective;
    }
}
