using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScene : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NewGame.gameStart)
        {
            if (LoadNewArea.currentActiveScene == sceneName)
            {
                gameObject.SetActive(true);
                print(gameObject.transform.position);
            }
            else if (LoadNewArea.currentActiveScene != sceneName)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
