using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveExists : MonoBehaviour
{
    private static bool saveExists;
    // Start is called before the first frame update
    void Start()
    {
        if (!saveExists)
        {
            saveExists = true;
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
