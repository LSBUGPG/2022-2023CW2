using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public GameObject ground1;
    public GameObject ground2;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Groundnotactive", 4);
    }

    public void Groundnotactive()
    {
        ground1.SetActive(false);
        ground2.SetActive(true);
        Invoke("Groundactive", 8);
    }

    public void Groundactive()
    {
        ground1.SetActive(true);
        ground2.SetActive(false);
        Invoke("Groundnotactive", 8);
    }
}
