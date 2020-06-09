using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteract : MonoBehaviour
{
    public GameObject player;
    public GameObject interactionPanel;
    public DmgToPlayer dmgToPlayer;
    public float timer;
    public GameObject controllerKeys;
    public GameObject cooldownMenu;
    public GameObject timeBar;
    public static bool sleeping = false;
    public GameObject cooldown1;
    public GameObject cooldown2;
    public GameObject cooldown3;
    private Vector3 standPosition;
    private Vector3 bedPosition;
    private Collider2D boxCollider;
    private Rigidbody2D rb;
    private TimeBar timeBarScript;
    
    
    void Start()
    {
        timeBarScript = timeBar.GetComponent<TimeBar>();
    }


    IEnumerator waitTime() {
        
        yield return new WaitForSeconds(timer);
        sleeping = false;
        player.transform.position = new Vector3(standPosition.x,standPosition.y,standPosition.z);
        boxCollider.isTrigger = false;
        player.GetComponent<MoveButton>().enabled = true;
        interactionPanel.SetActive(true);
        controllerKeys.SetActive(true);
        consumed();
        cooldown1.GetComponent<Cooldown>().nextFireTime = 0;
        cooldown2.GetComponent<Cooldown>().nextFireTime = 0;
        cooldown3.GetComponent<Cooldown>().nextFireTime = 0;
    }
    public void Sleep()
    {
        sleeping = true;
        timeBar.SetActive(true);
        timeBarScript.maximumValue = timer;
        controllerKeys.SetActive(false);
        interactionPanel.SetActive(false);
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        player.GetComponent<Movus>().enabled = false;
        player.GetComponent<MoveButton>().enabled = false;
        bedPosition = gameObject.transform.position;
        boxCollider = GetComponent<Collider2D>();
        boxCollider.isTrigger = true;
        standPosition = player.transform.position;
        rb.velocity = new Vector2(0f,0f);
        cooldownMenu.GetComponent<Cooldown>().consumed = true;
        cooldownMenu.SetActive(true);
        cooldownMenu.GetComponent<Cooldown>().nextFireTime = Time.time*288 + cooldownMenu.GetComponent<Cooldown>().cooldownTime*288;
        player.GetComponent<SpriteRenderer>().sortingOrder = -1;
        player.transform.position = new Vector3(bedPosition.x,bedPosition.y,standPosition.z);
        StartCoroutine (waitTime());
    }
    public void consumed()
    {
        dmgToPlayer = gameObject.GetComponent<DmgToPlayer>();
        dmgToPlayer.effectOnPlayer();
    }
    
}
