using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public static bool gameStart;
    public static NewGame instance;
    public GameObject canvas;
    public GameObject player;
    public GameObject cooldown1;
    public GameObject cooldown2;
    public GameObject cooldown3;
    
    private MoveButton thePlayer;
    private static bool objectExists;
    private int counter = 0;
    void Start()
    {
        MakeInstance();
        gameStart = false;
        thePlayer = FindObjectOfType<MoveButton>();
        if (!objectExists)
        {
            objectExists = true;
            DontDestroyOnLoad(transform.gameObject);
            
        }
        else if(PauseButton.mainMenu&&counter ==1)
        {
            Destroy(gameObject);
        }

        
    }
    
    public void loadFirstScene()
    {
        LoadNewArea.currentActiveScene = "Grid Bedroom&Office";
        gameStart = true;
        counter += 1;
        PauseButton.mainMenu = false;
        Time.timeScale = 1f;
        Timer.startTime = 0;
        player = GameObject.FindWithTag("Player");
        Vector3 pos = player.transform.position;
        pos = new Vector3 (0,0,0);
        player.transform.position = pos;
        PlayerHpManager.playerCurrentHealth = 100;
        PlayerHappManager.playerCurrentHapp = 100;
        PlayerProgManager.playerCurrentProg = 0;
        cooldown1.GetComponent<Cooldown>().nextFireTime = 0;
        cooldown2.GetComponent<Cooldown>().nextFireTime = 0;
        cooldown3.GetComponent<Cooldown>().nextFireTime = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    
}
