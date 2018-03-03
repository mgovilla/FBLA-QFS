using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {                                              //Attached to Ball prefab
    /*Declare variables*/

    private PongManager pongManager;                                                    //This is the main background class
    GameObject manager;
    private Rigidbody rigid;                                                            //For physics for the ball

    /*Initialize the variables*/
    void Start () {
        manager = GameObject.Find("GameManager"); 
        pongManager = manager.GetComponent<PongManager>();
        rigid = gameObject.GetComponent<Rigidbody>(); 
    }                                                                                   
	
	// Update is called once per frame
	void Update () {
        if (rigid.velocity.y == 0 && rigid.velocity.x == 0 && pongManager.isStarted)
        {
            rigid.AddForce(0, 20, 0);                                                   //In case the ball gets stuck in the corner, 
        }                                                                               //Add some y force to kickstart it

        if(pongManager.gameOver)
        {
            gameObject.SetActive(false);                                                //When the game finishes, stop the ball
        }
    }

    public void Die()                                                                   //This method should be called when the 
    {                                                                                   //ball reaches the bottom
        Destroy(gameObject);
        GameObject paddle = GameObject.Find("Paddle");
        PongController pongController = paddle.GetComponent<PongController>();
        pongController.SpawnBall();                                                     //Spawn the ball again
    }
}
