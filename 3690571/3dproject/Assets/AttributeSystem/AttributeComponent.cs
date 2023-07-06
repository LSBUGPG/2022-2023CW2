using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Media;
using UnityEngine;

public class AttributeComponent : MonoBehaviour
{

    public AttributeResource attributes;

    private AttributeResource privAttribute;

    private void Start()
    {
        privAttribute =ScriptableObject.Instantiate(attributes);
        foreach (AttributeResource.Attributes curVal in privAttribute.attributes)
        {
            curVal.SetCurrent();
            print(curVal.GetCurrent());
            return;
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeCurrentValue("Health", -1.1f);
        }
        
    }



    public void ChangeCurrentValue(string value, float amount)
    {
       foreach (AttributeResource.Attributes curVal in privAttribute.attributes)
        {
            if (curVal.attributeName == value)
            {
                curVal.UpdateValue(amount);
                return;
            }
        }
    }
}
