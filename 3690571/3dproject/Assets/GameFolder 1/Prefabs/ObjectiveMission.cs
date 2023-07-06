using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveMission : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        WorldObjective myObjective = GetComponent<WorldObjective>();
        if (myObjective == null) 
        {
            return;
        }
        else
        {
            myObjective.SetPlayerObjective();
        }
        Debug.Log("I have ben interacted with");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
