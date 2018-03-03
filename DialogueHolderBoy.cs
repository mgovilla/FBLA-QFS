using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolderBoy: MonoBehaviour                                           //Controls dialogue (red boy)
{                                                                                       //This is should be attached to the red boy
    //Declare variables
    public string dialogue; 
    private DialogueManager dMan;
    private QuestManager qMan;
   
    private bool inTrigger;
    private int count;
	
    /*Initialize variables*/
	void Start () {
        dMan = FindObjectOfType<DialogueManager>();
        qMan = FindObjectOfType<QuestManager>();

        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (inTrigger)
        {
            if (qMan.isCompleted[0]) //If the quest was completed(found paper)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    Debug.Log(count);
                    count++; //Dialogue switch once space is pressed
                    //Not an ideal solution because the player can walk away before fully completing the dialogue
                    switch (count)
                    {
                        default:
                            dMan.ShowBox("Thank you for finding the papers!");
                            break;
                        case 2:
                            if (qMan.quests[0]) { qMan.EndQuest(0); } //The papers were returned 
                            break;
                        case 3:
                            if (qMan.passTest == 0) { 
                                dMan.ShowBox("Let's take the test!");
                                qMan.takeTest = true;
                            }
                            break;
                    }
      
                }
            } else //The Quest was not completed yet
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    dMan.ShowBox(dialogue); //Show the dialogue (established in the GUI)
                    //textShown = true;
                }
                if (Input.GetAxisRaw("Fire3") > .5)// && textShown) //Y BUTTON
                {
                    Debug.Log("Quest Began");
                    //paper.SetActive(true);
                    //paper.GetComponent<SpriteRenderer>().enabled = true;
                    qMan.isAccepted[0] = true; //Update quest manager
                    qMan.StartQuest(0);
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
