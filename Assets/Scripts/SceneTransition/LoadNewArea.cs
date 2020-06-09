using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string exitPoint;

    private MoveButton thePlayer;
    public GameObject player;
    public static Vector2 lastMove;
    public Vector3 nextPosition;
    public GameObject sceneToOff;
    public GameObject sceneToOn;
    public static string currentActiveScene;
    public string nextScene;


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<MoveButton>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.transform.position = new Vector3 (nextPosition.x,nextPosition.y,nextPosition.z);
            lastMove = MoveButton.lastMove;
            sceneToOff.SetActive(false);
            sceneToOn.SetActive(true);
            currentActiveScene = nextScene;
        }
        
    }
    
}
