using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
   
public class PlayerControl : MonoBehaviour                                                  //Attached to the char          
{                                                                                           //Control the player movement
    //Declare Variables
    public float moveSpeed;
    private Animator anim;
    private Rigidbody2D rigid;
    private bool playerMoving;
    private Vector2 lastMove;
    
    private static bool playerExists;
    public GameObject questManager;
    private QuestManager qMan;

    /*Initialize Variables*/
    void Start()    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        qMan = questManager.GetComponent<QuestManager>();

        if (!playerExists) { //Code to keep the same character throughout the game
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        playerMoving = false;
        Scene currentScene = SceneManager.GetActiveScene();
        

        if (currentScene.name == "Main" || currentScene.name == "School" && !qMan.isStopped)
        {
            if (System.Math.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f) //if a or d is pressed
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigid.velocity.y);
                playerMoving = true;                                        //For the animator 
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f); //To change the final resting position
            }
            else
            {
                rigid.velocity = new Vector2(0f, rigid.velocity.y);
            }

            if (System.Math.Abs(Input.GetAxisRaw("Vertical")) > 0.5f) //w or s
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                rigid.velocity = new Vector2(rigid.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
            else
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0f);
            }

            /*This is the updating the animator*/
            anim.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
            anim.SetFloat("lastMoveX", lastMove.x);
            anim.SetFloat("lastMoveY", lastMove.y);
            anim.SetBool("playerMoving", playerMoving);
        } else
        {

        }
    }
}
