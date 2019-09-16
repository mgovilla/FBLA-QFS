using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour                                             //Attached to the camera
{                                                                                       //This is the script to move the camera

    //Declaring variables
    public GameObject followTarget;                                                     //Will be the player 
    private Vector3 targetPos;
    public float moveSpeed;
    private static bool cameraExists;

	// Use this for initialization
	void Start () {
        //This is to keep the same camera throughout the game
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject); //delete duplicates
        }
    }
	
	// Update is called once per frame
	void Update () {
        //This makes the position of the camera the same as the player 
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed); //Add slight delay with Linear Interpolation
	}
}
