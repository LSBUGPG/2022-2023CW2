using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatFloor : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;
    public GameObject floor5;
    public GameObject floor6;
    public GameObject floor7;
    public GameObject floor8;


    void Start()
    {
        Invoke("Floor1", 4.125f);
    }

    public void Floor1()
    {
        floor1.SetActive(false);
        floor2.SetActive(true);
        Invoke("Floor2", 0.5f);
    }

    public void Floor2()
    {
        floor2.SetActive(false);
        floor3.SetActive(true);
        Invoke("Floor3", 0.5f);
    }

    public void Floor3()
    {
        floor3.SetActive(false);
        floor4.SetActive(true);
        Invoke("Floor4", 0.5f);
    }

    public void Floor4()
    {
        floor4.SetActive(false);
        floor5.SetActive(true);
        Invoke("Floor5", 0.5f);
    }

    public void Floor5()
    {
        floor5.SetActive(false);
        floor6.SetActive(true);
        Invoke("Floor6", 0.5f);
    }

    public void Floor6()
    {
        floor6.SetActive(false);
        floor7.SetActive(true);
        Invoke("Floor7", 0.5f);
    }

    public void Floor7()
    {
        floor7.SetActive(false);
        floor8.SetActive(true);
        Invoke("Floor8", 0.5f);
    }

    public void Floor8()
    {
        floor8.SetActive(false);
        floor1.SetActive(true);
        Invoke("Floor1", 0.5f);
    }
}
