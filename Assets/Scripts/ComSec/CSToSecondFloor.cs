using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSToSecondFloor : MonoBehaviour
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
            Vector3 livingroom = new Vector3 (-5.912507f,8.286814f,0f);
            collision.gameObject.transform.position = livingroom;
        }
        
    }
}
