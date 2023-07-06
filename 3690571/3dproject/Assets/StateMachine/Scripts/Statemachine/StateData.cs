using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[Serializable]
public class StateData
{
    [HideInInspector]
    public enum transitionTypes {trigger, floatNum, integer, strin, boolean }
    public enum evaluationTypes {equals, notequals, greaterthan, lessthan, greaterorequal, lessorequal }

    public State toTransition;
    public transitionRules[] rules;

    [Serializable]
    public class transitionRules
    {
        public string name;
        public transitionTypes types;
        public evaluationTypes evaluation;
        public string data;
        
    }

    public State returnState(StateVariables svb)
    {
        for (int i = 0; i < svb.sd.Length; i++)
        {
            if (CheckType(svb.sd[i].namea,svb.sd[i].dataType,svb.sd[i].value))
            {

                return toTransition;
            }
        }
        return null;
    }

    public bool CheckType(string name,string ty , string val)
    {
        /*Debug.Log(ty + " " + val);
        if ( ty == "bool")
        {
            return checkforBool(name, val);
        }
        else if (ty == "float")
        {
            return returnCantransition(name, val);
        }
        else if (ty == "trigger")
        {
            return checkforBool(name, val);
        }*/




        for (int i = 0; i < rules.Length; i++)
        {
            switch (rules[i].types)
            {
                case transitionTypes.trigger:
                    if (ty == "trigger")
                    {
                        return checkforBool(name, val);
                    }
                    break;
                case transitionTypes.floatNum:
                    if (ty == "float")
                    {
                        return returnCantransition(name, val);
                    }
                    break;
                case transitionTypes.boolean:
                    if (ty == "bool")
                    {
                        return checkforBool(name, val);
                    }
                    break;
            }
        }
        return false;
    }


    public bool returnCantransition(string name, string val)
    {

        for (int i = 0; i < rules.Length; i++)
        {
            float newVal = float.Parse(val);
            float newData = float.Parse(rules[i].data);

            switch (rules[i].evaluation)
            {
                case evaluationTypes.equals:
                    if (newVal == newData)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case evaluationTypes.notequals:
                    if (newVal != newData)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case evaluationTypes.greaterthan:
                    if (newVal > newData)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case evaluationTypes.lessthan:
                    if (newVal < newData)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case evaluationTypes.greaterorequal:
                    if (newVal >= newData)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case evaluationTypes.lessorequal:
                    if (newVal <= newData)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            
        }
        return false;
    }


    private bool checkforBool(string name, string val)
    {
        return Convert.ToBoolean(val);
    }

}
