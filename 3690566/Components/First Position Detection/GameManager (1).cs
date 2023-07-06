using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState
{
   Beginning, Running,Paused,Completed
}
public class GameManager : MonoBehaviour
{
    public GameState State = GameState.Beginning;
    public int lapnumber;
    public int TotalLaps;
    public GameObject[] Tracks;
    public bl_MiniMap map;
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    public void GameComplete()
    {
        if(State==GameState.Running)
        {
            Time.timeScale = 0f;
            State = GameState.Completed;
            UIManager.instance.GameCompletePanel.SetActive(true);


        }

    }
    public void IncrementLap()
    {
        lapnumber++;
        if(lapnumber==TotalLaps)
        {
            UIManager.instance.PositionText.text = "Position:" + (CheckPointManager.instance.Positions.Count + 1).ToString();
            UIManager.instance.TimerText.text = "Time:" + ((int)UIManager.instance.Timerv).ToString();
            GameComplete();
        }
        UIManager.instance.LapsText.text = "Lap:" + (lapnumber).ToString()+"/"+TotalLaps;
    }
    void Start()
    {
        Tracks[PlayerPrefs.GetInt("TRACK")].SetActive(true);
        map.Target = GameObject.FindGameObjectWithTag("Player").transform;

        TotalLaps = PlayerPrefs.GetInt("LAPS");
        if(PlayerPrefs.GetInt("MUSIC",1)==0)
        {
            this.GetComponent<AudioSource>().volume = 0f;
        }
  
        UIManager.instance.LapsText.text = "Lap:"+(lapnumber).ToString() + "/" + TotalLaps;
    }
    public void StartTheGame()
    {
        State = GameState.Running;
    }
    public void Resume()
    {
        State = GameState.Running;
        UIManager.instance.PausePanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(State!=GameState.Paused)
            {
                Time.timeScale = 0f;
                State = GameState.Paused;
                UIManager.instance.PausePanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                State = GameState.Running;
                UIManager.instance.PausePanel.SetActive(false);
            }
        }
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
   
}
