using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectiveController : MonoBehaviour
{
    public delegate void objectiveChanged();
    public static event objectiveChanged ObjectiveChanged;

    public static ObjectiveController instance;

    public Objectives currentObjectives = null;

    public event EventHandler<Objectives> newObjective;
    public event EventHandler<Objectives> objectiveSet;
    public event EventHandler<Objectives> objectiveSetComplete;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

    }

    public void SetNewObjective(Objectives newObjective)
    {
        if (currentObjectives == null)
        {
            currentObjectives = newObjective;
            CompleteTask();
            Debug.Log("Why");
        }
    }

    public void UpdateWorld()
    {
        newObjective(this, currentObjectives);
    }

    public void CompletedObjective()
    {
        objectiveSetComplete(this, currentObjectives);
    } 

    public void SetTaskState(string t)
    {
        currentObjectives.objectiveComplete(t);
        if (currentObjectives.subtasks.Length > 0)
        {
            CompleteTask();
        }
        else
        {
            CompletedObjective();
        }
    }

    public void CompleteTask()
    {
        objectiveSet(this, currentObjectives);
    }
}
