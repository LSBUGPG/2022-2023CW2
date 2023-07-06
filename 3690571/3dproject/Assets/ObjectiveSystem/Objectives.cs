using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveState
{
    Idle, Active, Completed
}
[CreateAssetMenu(fileName = "ObjectiveBase", menuName = "Objectives/ObjectiveBase")]
public class Objectives : ScriptableObject
{
    

    public string title;
    [TextArea(20, 30)]
    public string description;

    public string[] subtasks;

    public void objectiveComplete(string task)
    {
        for (int i = 0; i < subtasks.Length; i++)
        {
            if(subtasks[i] == task)
            {
                subtasks[i].Remove(i);
            }
        }
    }

}
