using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        winScreen.SetActive(true);
    }
}
