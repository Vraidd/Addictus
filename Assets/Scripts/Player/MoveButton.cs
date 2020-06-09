using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveButton : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject panel;
    public static Vector2 lastMove;
    public string startPoint;
    public Vector3 pos;
    public PlayerData myData;
    public static MoveButton instance;

    private Animator anim;
    public static Rigidbody2D mybody;
    private bool playerMoving;
    private static bool playerExist;
    private Rigidbody2D rb;
    private float dirX;
    private float dirY;
    private Vector3 currentGrid;
    public GameObject canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        MakeInstance();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
        if (!playerExist)
        {
            playerExist = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        dirY = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(dirX, dirY);
        playerMoving = false;
        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.5f || CrossPlatformInputManager.GetAxis("Horizontal") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 0f);
        }

        if (CrossPlatformInputManager.GetAxis("Vertical") > 0.5f || CrossPlatformInputManager.GetAxis("Vertical") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(0f, CrossPlatformInputManager.GetAxis("Vertical"));
        }

        if (PauseButton.mainMenu)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
            gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, -99);
        }
        else if (!PauseButton.mainMenu)
        {
            currentGrid = GameObject.FindWithTag(LoadNewArea.currentActiveScene).GetComponent<Transform>().position;
            print(GameObject.FindWithTag(LoadNewArea.currentActiveScene));
            GetComponent<SpriteRenderer>().sortingOrder = 1;
            gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, currentGrid.z-0.5f);
            
        }
        if (!PauseButton.mainMenu && SaveSystem.loading)
        {
            currentGrid = GameObject.FindWithTag(LoadNewArea.currentActiveScene).GetComponent<Transform>().position;
            GetComponent<SpriteRenderer>().sortingOrder = 1;
            gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, currentGrid.z-0.5f);
            Movus.setPosition();
            SaveSystem.loading = false;
        }
        

        anim.SetFloat("Horizontal", CrossPlatformInputManager.GetAxis("Horizontal"));
        anim.SetFloat("Vertical", CrossPlatformInputManager.GetAxis("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

        
    }
    private void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
}
