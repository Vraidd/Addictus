using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    private static bool cameraExists;


    // Start is called before the first frame update
    void Start()
    {
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else if (cameraExists)
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, followTarget.transform.position.z-0.5f);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        //if (PauseButton.mainMenu && counter==1)
        {
            //Destroy(gameObject);
        }
    }

}
