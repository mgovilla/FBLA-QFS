using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadzoneControl : MonoBehaviour                                            //This is attached to the bottom gameObject
{                                                                                       //Destroy the ball and update the lives
    //Declare the variables
    private PongManager pongManager;
    UnityEngine.GameObject manager;

	/*Initialize the Variables*/
	void Start () {
        manager = UnityEngine.GameObject.Find("GameManager");
        pongManager = manager.GetComponent<PongManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void OnTriggerEnter(Collider other)                                          //Called when the ball enters the zone
    {
        BallControl ballControl = other.GetComponent<BallControl>();                    //Get the ball control
        if(ballControl)
        {
            ballControl.Die();                                                          //Destroy the ball and respawn
            pongManager.lives--;                                                        //Update the manager
        }
    }
}
