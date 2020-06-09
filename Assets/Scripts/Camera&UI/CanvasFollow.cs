using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasFollow : MonoBehaviour
{
    public Slider healthBar;
    public PlayerHpManager playerHealth;
    public Slider progBar;
    public PlayerProgManager playerProg;
    public Slider happBar;
    public PlayerHappManager playerHapp;
    private static bool canvasExist;
    // Start is called before the first frame update
    private void Awake() 
    {
        //playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHpManager>();
        //playerProg = GameObject.FindWithTag("Player").GetComponent<PlayerProgManager>();
        //playerHapp = GameObject.FindWithTag("Player").GetComponent<PlayerHappManager>();
    }
    void Start()
    {
        if (!canvasExist)
        {
            canvasExist = true;
        }
        else if (canvasExist)
        {
            Destroy(gameObject);
        }
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHpManager>();
        playerProg = GameObject.FindWithTag("Player").GetComponent<PlayerProgManager>();
        playerHapp = GameObject.FindWithTag("Player").GetComponent<PlayerHappManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = PlayerHpManager.playerCurrentHealth;
        happBar.maxValue = playerHapp.playerMaxHapp;
        happBar.value = PlayerHappManager.playerCurrentHapp;
        progBar.maxValue = playerProg.playerMaxProg;
        progBar.value = PlayerProgManager.playerCurrentProg;
        
        
    }
    
}
