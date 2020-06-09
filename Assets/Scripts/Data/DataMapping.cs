using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataMapping : MonoBehaviour
{
    public PlayerHpManager hpManager;
    public PlayerHappManager happManager;
    public PlayerProgManager progManager;
    public MoveButton movement;
    public GameObject bed;
    public bool bedConsumed;
    public float bedNextFireTime;
    // Start is called before the first frame update
    void Start()
    {
        LoadNewArea.currentActiveScene = "Bedroom";
        MoveButton player = GameObject.FindObjectOfType<MoveButton>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bedConsumed = bed.GetComponent<Cooldown>().consumed;
        bedNextFireTime = bed.GetComponent<Cooldown>().nextFireTime;
        Saver.playerHealth = PlayerHpManager.playerCurrentHealth;
        Saver.playerHapp = PlayerHappManager.playerCurrentHapp;
        Saver.playerProg = PlayerProgManager.playerCurrentProg;
        Saver.lastScene = LoadNewArea.currentActiveScene;
        Saver.lastMove.x = MoveButton.lastMove.x;
        Saver.lastMove.y = MoveButton.lastMove.y;
        Saver.position.x = gameObject.transform.position.x;
        Saver.position.y = gameObject.transform.position.y;
        Saver.position.z = gameObject.transform.position.z;
        Saver.startTime = Timer.startTime;
        Saver.bedConsumed = bedConsumed;
        Saver.bedSleepCooldown = bedNextFireTime - Time.time*288;
    }
}
