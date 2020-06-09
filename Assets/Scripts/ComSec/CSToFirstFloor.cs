using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSToFirstFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Vector3 livingroom = new Vector3 (-27.75497f,11.89583f,34.82648f);
            collision.gameObject.transform.position = livingroom;
        }
        
    }
}
