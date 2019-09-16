using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolderCPU : MonoBehaviour                                      //Attached to the dialogue zone(CPU)
{                                                                                   //Dialogue for the CPU
    
   //Declare Variables
    private DialogueManager dMan;
    private QuestManager qMan;

    private bool inTrigger;

	/*Initialize variables*/
	void Start () {
        dMan = FindObjectOfType<DialogueManager>();
        qMan = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (inTrigger)
        {
            if (qMan.takeTest) //IF the player is eligible for the test (completed quest[0])
            {
                //Not an ideal solution, as the y button can be pressed without starting the conversation
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    dMan.ShowBox("Do you want to take the test? Y|N");
                }
                if (Input.GetAxisRaw("Fire3") > .5)// && textShown) //Y BUTTON 
                {
                    Debug.Log("Y pressed");
                    GetComponent<LoadNewScene>().LoadNextScene("Break");
                }
            } else if(qMan.passTest == -1) //if the test was taken and failed
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    dMan.ShowBox("Better luck next time");
                }
                
            }
            else if (qMan.passTest == 1) //taken and passed
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    dMan.ShowBox("Congratulations!");
                }

            }

        }
    }
    /*Since OnTriggerStay2D was not working well. This alternative toggles a bool as the collider enters/leaves*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTrigger = false;
        }
    }
}
