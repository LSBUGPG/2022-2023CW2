using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public int CurrentCheckPoint = 0;
    public List<Checkpoint>AllCheckPoints=new List<Checkpoint>();
    public static CheckPointManager instance;
    public List<GameObject> Positions = new List<GameObject>();
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    int wrongcheckpoint=-1;
    public void CheckpointPassed(int i)
    {
        if(i==CurrentCheckPoint)
        {
            Debug.Log("CHECKPOINTPASSED");
            AllCheckPoints[CurrentCheckPoint].GetComponent<bl_MiniMapItem>().HideItem();
         
            if(CurrentCheckPoint==AllCheckPoints.Count-1)
            {
                CurrentCheckPoint = 0;
                GameManager.instance.IncrementLap();
            }
            else
            CurrentCheckPoint++;
            AllCheckPoints[CurrentCheckPoint].GetComponent<bl_MiniMapItem>().ShowItem();

            if (PlayerPrefs.GetInt("SOUDN", 1) == 1)
                UIManager.instance.CheckpointSound.Play();
        }
        else
        {
            //Debug.Log("CHECKPOINTFAILED:" );
            //if (wrongcheckpoint==-1 && i!=CurrentCheckPoint-1)
            //{
            //    wrongcheckpoint = i;
            //    UIManager.instance.WrongDirection.SetActive(true);
            //}
            //else
            //{
            //    if(i==wrongcheckpoint)
            //    {
            //        wrongcheckpoint =-1;
            //        UIManager.instance.WrongDirection.SetActive(false);
            //    }
            //}
          
        }
    }
    void Start()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            AllCheckPoints.Add(transform.GetChild(i).GetComponent<Checkpoint>());
        
        }

        Invoke("DelayOff", 1f);
     

        
    }
    public void DelayOff()
    {
        for (int i = 1; i < AllCheckPoints.Count; i++)
        {
            AllCheckPoints[i].GetComponent<bl_MiniMapItem>().HideItem();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AiCheckPointReached(AIController ai)
    {
      
        if (ai.CurrentCheckpoint == AllCheckPoints.Count - 1)
        {
            ai.CurrentCheckpoint = 0;
            ai.CurrentLap++;
            if (ai.CurrentLap == GameManager.instance.TotalLaps)
            {
                Positions.Add(ai.gameObject);
                ai.gameObject.SetActive(false);
            }
        }
        else
            ai.CurrentCheckpoint++;

        ai.target = AllCheckPoints[ai.CurrentCheckpoint].transform;
    }
}
