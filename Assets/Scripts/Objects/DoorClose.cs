using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public Collider2D door;
    private float randInterval;
    public float minimumIntervalTime;
    public float maximumIntervalTime;
    public float closeDuration;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<Collider2D>();
        door.isTrigger = true;
        doorClosure();
    }

    // Update is called once per frame
    void Update()
    {
        randInterval = Random.Range(minimumIntervalTime,maximumIntervalTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Door is closed.");
        }
    }
    IEnumerator doorCloseTime()
    {
        yield return new WaitForSeconds(randInterval);
        door.isTrigger = false;
        yield return new WaitForSeconds(closeDuration);
        door.isTrigger = true;
        doorClosure();
    }
    private void doorClosure()
    {
        StartCoroutine(doorCloseTime());
    }
}
