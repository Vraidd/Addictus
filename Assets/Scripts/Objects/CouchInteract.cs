using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouchInteract : MonoBehaviour
{
    public GameObject player;
    public GameObject interactionPanel;
    private DmgToPlayer dmgToPlayer;
    public float timer;
    public GameObject controllerKeys;
    public GameObject cooldownMenu;
    public GameObject timeBar;

    private Vector3 standPosition;
    private Vector3 couchPosition;
    private Collider2D boxCollider;
    private Rigidbody2D rb;
    private TimeBar timeBarScript;
    
    
    void Start()
    {
        timeBarScript = timeBar.GetComponent<TimeBar>();
    }

    IEnumerator waitTime() {
        
        yield return new WaitForSeconds(timer);
        player.transform.position = new Vector3(standPosition.x,standPosition.y,standPosition.z);
        boxCollider.isTrigger = false;
        player.GetComponent<MoveButton>().enabled = true;
        interactionPanel.SetActive(true);
        controllerKeys.SetActive(true);
        consumed();
    }
    public void WatchTV()
    {
        timeBar.SetActive(true);
        timeBarScript.maximumValue = timer;
        controllerKeys.SetActive(false);
        interactionPanel.SetActive(false);
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        player.GetComponent<MoveButton>().enabled = false;
        couchPosition = gameObject.transform.position;
        boxCollider = GetComponent<Collider2D>();
        boxCollider.isTrigger = true;
        standPosition = player.transform.position;
        rb.velocity = new Vector2(0f,0f);
        cooldownMenu.GetComponent<Cooldown>().consumed = true;
        cooldownMenu.SetActive(true);
        cooldownMenu.GetComponent<Cooldown>().nextFireTime = Time.time*288 + cooldownMenu.GetComponent<Cooldown>().cooldownTime*288;
        player.GetComponent<SpriteRenderer>().sortingOrder = -1;
        player.transform.position = new Vector3(couchPosition.x,couchPosition.y,standPosition.z);
        StartCoroutine (waitTime());
    }
    public void consumed()
    {
        dmgToPlayer = gameObject.GetComponent<DmgToPlayer>();
        dmgToPlayer.effectOnPlayer();
    }
    
}
