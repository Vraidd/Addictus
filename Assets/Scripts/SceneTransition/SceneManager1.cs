using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager1 : MonoBehaviour
{
    public GameObject gridBedroom;
    public GameObject gridGameRoom;
    public GameObject gridLivingRoom;
    public GameObject gridKitchen;
    public GameObject gridStudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AllGridActive()
    {
        gridBedroom.SetActive(true);
        gridGameRoom.SetActive(true);
        gridLivingRoom.SetActive(true);
        gridKitchen.SetActive(true);
        gridStudio.SetActive(true);
    }
}
