using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedoMeter : MonoBehaviour
{
    public Rigidbody CarRigidBody;
    public Text CarSpeedText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CarSpeedText.text = (int)(CarRigidBody.velocity.magnitude * 3.6) + "Km/h";
    }
}
