using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgToPlayer : MonoBehaviour
{
    public PlayerHpManager playerHpManager;
    public float hitPoints;
    public PlayerHappManager playerHappManager;
    public float happPoints;
    public PlayerProgManager playerProgManager;
    public float progPoints;
    public GameObject player;
    public static DmgToPlayer instance;
    // Start is called before the first frame update
    void Start()
    {
        MakeInstance();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void effectOnPlayer()
    {
        player = GameObject.FindWithTag("Player");
        playerHpManager = player.GetComponent<PlayerHpManager>();
        playerHpManager.DmgPlayer(hitPoints);
        playerHappManager = player.GetComponent<PlayerHappManager>();
        playerHappManager.DmgPlayer(happPoints);
        playerProgManager = player.GetComponent<PlayerProgManager>();
        playerProgManager.DmgPlayer(progPoints);
    }
    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
}
