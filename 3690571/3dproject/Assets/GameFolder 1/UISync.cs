using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISync : MonoBehaviour
{
    ObjectiveController controller;
    CompassBar cBar;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<ObjectiveController>();
        cBar= FindObjectOfType<CompassBar>();

    }

}
