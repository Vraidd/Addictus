using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] drugs;
    public Vector3[] centreOfRect;
    public float width;
    public float height;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public int numberOfSpawnPoints;
    public int numberOfDrugTypes;
    public int numberOfDrugsToSpawn;
    public static int counter;
    public float spawnLocationZAxix;
    int randDrugs;
    int randCentreOfRect;

    void Start()
    {
        
        counter = 0;
    }

    
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait,spawnMostWait);
        if (counter < numberOfDrugsToSpawn)
        {
            StartCoroutine(waitSpawner());
        }
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (counter < numberOfDrugsToSpawn)
        {
            randDrugs = Random.Range (0,numberOfDrugTypes);
            counter += 1;
            randCentreOfRect = Random.Range(0,numberOfSpawnPoints);
            Vector3 spawnLocation = new Vector3 (Random.Range(centreOfRect[randCentreOfRect].x-width,centreOfRect[randCentreOfRect].x+width),Random.Range(centreOfRect[randCentreOfRect].y-height,centreOfRect[randCentreOfRect].y+height),spawnLocationZAxix);
            Instantiate (drugs[randDrugs],spawnLocation,gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
            
        }
    }
}
