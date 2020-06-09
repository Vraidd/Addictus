using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 StartPos = new Vector3(0f, 0f ,0f);
        gameObject.transform.position = StartPos; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
