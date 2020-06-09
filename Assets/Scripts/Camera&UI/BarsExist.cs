using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsExist : MonoBehaviour
{
    private static bool barsExist;
    // Start is called before the first frame update
    void Start()
    {
        if (!barsExist)
        {
            barsExist = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
