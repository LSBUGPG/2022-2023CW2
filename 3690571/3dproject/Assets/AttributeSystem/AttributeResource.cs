using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Attribute", menuName = "Attribute/AttributeResource")]
public class AttributeResource : ScriptableObject
{
    

    [Serializable]
    public class Attributes
    {
        private UnityEvent maxReached;

        public string attributeName;
        public float maxValue;
        public float minValue;
        public float currentValue;

        public Attributes()
        {
            currentValue = maxValue;
        }
        
        public void SetCurrent()
        {
            currentValue = maxValue;
        }

        public float GetCurrent()
        {
            return currentValue;
        }

        public void UpdateValue(float amount)
        {
            currentValue += amount;
        }
    }

    [SerializeField]
    public Attributes[] attributes;

}
