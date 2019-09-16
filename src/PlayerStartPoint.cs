using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour                                               //Attached to an empty game object
{                                                                                           //For the beginning of the scene
    //Declare variables
    private PlayerControl thePlayer;
    private CameraMovement theCamera;

	/*Initialize Variables*/
	void Start () {
        thePlayer = FindObjectOfType<PlayerControl>();
        thePlayer.transform.position = transform.position; //Put the character at the start point

        theCamera = FindObjectOfType<CameraMovement>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
