using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent interactAction;
    public GameObject optionMenu;

    
    void Start()
    {
        optionMenu.SetActive(false);
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            optionMenu.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            optionMenu.SetActive(false);
        }
    }
}
