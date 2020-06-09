using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDestination : MonoBehaviour
{
    private MoveButton thePlayer;
    private CameraFollow theCamera;
    public string point;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<MoveButton>();
        print("script started");
    }
    void Update()
    {
        print("this is running");
        if (thePlayer.startPoint == point)
        {
        thePlayer.transform.position = gameObject.transform.position;
        print("Player transported");
        theCamera = FindObjectOfType<CameraFollow>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        thePlayer.startPoint = null;
        }
    }
}
