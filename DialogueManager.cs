using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour                                        //Attached to the canvas object 
{                                                                                   //This is the Dialogue Manager
    //Declare variables
    public UnityEngine.GameObject dBox;
    public Text dText;

    public bool dialogueActive;
		
	// Update is called once per frame
	void Update () {
		if(dialogueActive && Input.anyKeyDown) //If the player tries moving away after the text is shown 
        {
            dBox.SetActive(false);
            dialogueActive = false;
        }
	}

    public void ShowBox(string dialogue) //Method to display some dialogue
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }
}
