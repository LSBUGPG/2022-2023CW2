using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateVariables:MonoBehaviour
{
    public stateData[] sd;

    [Serializable]
    public class stateData
    {
        public string namea;
        public string dataType;
        public string value;
    }

    public void SetValue(string name, string val)
    {
        for (int i = 0; i < sd.Length; i++)
        {
            if (sd[i].namea == name)
            {
                sd[i].value = val; break;
            }
        }
    }

    public void ActualSetTrigger(string val)
    {
        StartCoroutine(SetTrigger(val));
    }

    public IEnumerator SetTrigger(string name)
    {
        for (int i = 0; i < sd.Length; i++)
        {
            if (sd[i].namea == name)
            {
                sd[i].value = true.ToString();
                yield return 0;
                sd[i].value = false.ToString();

            }
        }
    }

    public string ReturnValue(string name)
    {
        for (int i = 0; i < sd.Length; i++)
        {
            if (sd[i].namea == name)
            {
                return sd[i].value;
            }
        }
        return null;
    }
}
