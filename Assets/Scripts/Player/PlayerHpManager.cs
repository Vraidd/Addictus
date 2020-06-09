using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpManager : MonoBehaviour
{

    public static PlayerHpManager instance;
    public float playerMaxHealth;
    public static float playerCurrentHealth;
    public float healthBarLength;
    // Start is called before the first frame update
    void Start()
    {
        MakeInstance();
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        if (playerCurrentHealth >= playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    
    public void DmgPlayer(float damageToGive)
    {
        playerCurrentHealth += damageToGive;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth -= playerMaxHealth;
    }
}
