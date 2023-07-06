using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveDisplay : MonoBehaviour
{
    public ObjectiveController controller;

    public TextMeshProUGUI objectiveTitle;
    public TextMeshProUGUI objectiveDescription;
    public GameObject displayTask;

    private void Awake()
    {
        controller = FindObjectOfType<ObjectiveController>();
        controller.objectiveSet += updateObjective;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void updateObjective(object sender, Objectives e)
    {
        objectiveTitle.text = e.title;
        for (int i = 0; i < e.subtasks.Length; i++)
        {
            GameObject myDisplay = Instantiate(displayTask);
            myDisplay.transform.SetParent(transform, false);
            TextMeshProUGUI d =  myDisplay.GetComponent<TextMeshProUGUI>();
            d.text = e.subtasks[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
