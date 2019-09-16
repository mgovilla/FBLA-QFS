using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickControl : MonoBehaviour                                           //Attached to each brick
{                                                                                   
    private PongManager pongManager;                                                //This is the main background class
    UnityEngine.GameObject manager;

    /*Initialize the variables*/
    void Start()
    {
        manager = UnityEngine.GameObject.Find("GameManager");
        pongManager = manager.GetComponent<PongManager>();
    }

    private void OnCollisionEnter(Collision collision)                              //This method is called when the ball hits the brick
    {                                                                               
        Destroy(gameObject);                                                         
        pongManager.bricks--;                                                       //Update the main manager
    }
}
