using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorWithButton : MonoBehaviour
{
    public Animator doorAnim;
    public Animator buttonAnim;
    public bool isPressed;
    public GameObject theDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        doorAnim = theDoor.GetComponent<Animator>();
        buttonAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        buttonAnim.SetBool("ButtonPressed", true);
    }
    private void OnTriggerExit(Collider other)
    {
        buttonAnim.SetBool("ButtonPressed", false);
    }


    // Update is called once per frame
    void Update()
    {
        if(buttonAnim.GetBool("ButtonPressed"))
        {
            isPressed = true;
            {
                doorAnim.SetBool("PlayerOn", true);
            }
        }
        else
        {
            isPressed = false;
            {
                doorAnim.SetBool("PlayerOn", false);
            }
        }
    }
}
