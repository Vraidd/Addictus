using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public static bool paused = false;
    public static bool mainMenu = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PauseGame()
    {
        Time.timeScale = 0f;
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void MainMenuPage()
    {
        mainMenu = true;
    }
    void update()
    {
        
    }
    
}
