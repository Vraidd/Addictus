using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDrug : MonoBehaviour
{
    public DmgToPlayer dmgToPlayer;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Spawner.counter -= 1;
            dmgToPlayer = gameObject.GetComponent<DmgToPlayer>();
            dmgToPlayer.effectOnPlayer();
        }
    }
}
