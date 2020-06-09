using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerProgManager instance;
    public float playerMaxProg;
    public static float playerCurrentProg;
    public float ProgBarLength;
    // Start is called before the first frame update
    void Start()
    {
        MakeInstance();
        playerCurrentProg = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentProg >= 0)
        {
            
        }
        if (playerCurrentProg <= 100)
        {
            ;
        }
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    
    public void DmgPlayer(float progToGive)
    {
        playerCurrentProg += progToGive;
    }
}
