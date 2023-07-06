using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerInput : MonoBehaviour
{
    public Slingshot player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SendMessage("SwitchBehaviours");

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.SendMessage("DoSlingshot");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SendMessage("Climb");
        }

    }
}
