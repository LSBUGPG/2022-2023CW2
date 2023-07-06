using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WorldObjective : MonoBehaviour
{
    private ObjectiveController controller;
    public Objectives objective;
    private Objectives myObjectivePrefab;

    private void Awake()
    {
        myObjectivePrefab = ScriptableObject.Instantiate(objective);
        controller = FindObjectOfType<ObjectiveController>();
        //SetPlayerObjective();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ObjectiveController.instance.UpdateWorld();
        }
    }

    public void SetPlayerObjective()
    {
        controller.SetNewObjective(myObjectivePrefab);
        SceneManager.LoadScene(0);
    }

}
