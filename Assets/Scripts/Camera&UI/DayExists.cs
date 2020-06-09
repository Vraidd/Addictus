using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayExists : MonoBehaviour
{
    private static bool dayExists;
    void Start()
    {
        if (!dayExists)
        {
            dayExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
