using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI dayText;
    public static float startTime;
    public GameObject newGame;
    public NewGame newGameScript;
    public static bool timerExist;
    private float b;
    private float t;
    void Start()
    {
        if (!timerExist)
        {
            timerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else if (timerExist)
        {
            print("timer will destroy");
            Destroy(gameObject);
        }
        //gameObject.SetActive(false);
        newGame = GameObject.FindWithTag("LoadNewScene");
        newGameScript = newGame.GetComponent<NewGame>();
        
    }

    void Update()
    {
        
        startTime += Time.deltaTime;
        
        if (BedInteract.sleeping)
        {
            startTime += Time.deltaTime*18.95f;
        }
        else
        {
            startTime = startTime*1;
        }
        float t = startTime*288;
        float m = (t/60);
        float h = (m/60)%24;
        float h1 = m/60;
        float g = (int) m%60;
        float day = (int)(h1/24+1);

        string minutes = ((int) m%60).ToString();
        string hours = ((int) (m/60)%24).ToString();
        if (g < 10 && h < 10)
        {
            timerText.text = "0" + hours + "0" + minutes ;
        }
        else if (g < 10 && h >= 10)
        {
            timerText.text = hours + "0" + minutes;
        }
        else if (g >= 10 && h < 10)
        {
            timerText.text = "0" + hours + minutes;
        }
        else if (g >= 10 && h >= 10)
        {
            timerText.text = hours + minutes;
        }
        dayText.text = "Day " + day;
        
    }

}
