using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHappManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerHappManager instance;
    public float playerMaxHapp;
    public static float playerCurrentHapp;
    public float happBarLength;
    // Start is called before the first frame update
    void Start()
    {
        MakeInstance();
        playerCurrentHapp = playerMaxHapp;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHapp <= 0)
        {
            gameObject.SetActive(false);
        }
        if (playerCurrentHapp >= 100)
        {
            ;
        }
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    
    public void DmgPlayer(float happToGive)
    {
        playerCurrentHapp += happToGive;
    }
}
