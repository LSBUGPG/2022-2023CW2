using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundActive : MonoBehaviour
{
    public GameObject ground1;
    public GameObject ground2;
    void Start()
    {
        Invoke("Groundnotactive", 0.5f);
    }

    public void Groundnotactive()
    {
        ground1.SetActive(false);
        ground2.SetActive(true);
        Invoke("Groundactive", 1);
    }

    public void Groundactive()
    {
        ground1.SetActive(true);
        ground2.SetActive(false);
        Invoke("Groundnotactive", 1);
    }
}
