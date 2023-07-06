using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourSwitch : MonoBehaviour
{
    public Behaviour[] behaviours;
    public void SwitchBehaviours()
    {
        foreach (var behaviour in behaviours)
        {
            behaviour.enabled = !behaviour.enabled;
        }
    }
}
