using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CSMove : MonoBehaviour
{
    public float moveSpeed;
    public GameObject panel;
    public Vector2 lastmove;
    public string startPoint;
    public PlayerData myData;

    public Animator anim;
    private Rigidbody2D mybody;
    private bool playerMoving;
    private static bool playerExist;
    
    void Start()
    {
        //anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sortingOrder = 1;
        gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0);
        if (!playerExist)
        {
            playerExist = true;
            DontDestroyOnLoad(gameObject);
        }
        else if(playerExist)
        {
            Destroy(gameObject);
        }
        
    }

    
    void Update()
    {
        playerMoving = false;
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            mybody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, mybody.velocity.y);
            playerMoving = true;
            lastmove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            mybody.velocity = new Vector2(mybody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMoving = true;
            lastmove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            mybody.velocity = new Vector2(0f, mybody.velocity.y);
            playerMoving = false;
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            mybody.velocity = new Vector2(mybody.velocity.x, 0f);
            playerMoving = false;
        }
        
        anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastmove.x);
        anim.SetFloat("LastMoveY", lastmove.y);
    }
    public static void setPosition()
    {
        GameObject _player = GameObject.FindWithTag("Player");
        Vector3 newPos = new Vector3 (Saver.position.x,Saver.position.y,Saver.position.z);
        _player.transform.position = newPos;
    }
    IEnumerator waitTime() {
        yield return new WaitForSeconds(0.3f);
    }
}
