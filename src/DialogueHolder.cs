using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueHolder : MonoBehaviour                                             //Attached to the Dialogue Zone (Old man)
{                                                                                       //This handles the dialogue of the old man                                        
    //Declare all variables
    public string dialogue;
    private DialogueManager dMan;
    private QuestManager qMan;
    public GameObject[] medals;//0 is gold, 1 is silver, 2 is bronze, 3 is fbla 
    
    private bool inTrigger;
    private bool next;
	// Update is called once per frame

	void Update () {    //Reference the pseudocode for entire layout of this elaborate if-statement
        if (inTrigger)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (qMan.isCompleted[1]) //if the fundraising is complete
                {
                    switch (qMan.passTest) //value of the test score
                    {
                        case -1:
                            if (qMan.fundScore > 100) //failed test but did well fundraising
                            {
                                medals[1].SetActive(true);
                                medals[3].SetActive(true);
                                dMan.ShowBox("Congratulations, you earned a silver medal! Play again for gold!");
                                qMan.isStopped = true;
                                next = true;
                            }
                            else if (qMan.fundScore > 50) //failed test but did alright in fundraise
                            {
                                medals[2].SetActive(true);
                                medals[3].SetActive(true);
                                dMan.ShowBox("Congratulations, you earned a bronze medal! Play again for gold!");
                                qMan.isStopped = true;
                                next = true;
                            }
                            else //failed test and failed the fundraising
                            {
                                dMan.ShowBox("Unfortunately this is game over, try harder next time!");
                                qMan.isStopped = true;
                                next = true;
                            }
                            break;
                        case 0: //Had not taken the test
                            if (qMan.takeTest) //Is eligible to take the test
                            {
                                dMan.ShowBox("Good luck on the test!");
                            }
                            break;
                        case 1: //Passed test
                            if (qMan.fundScore > 100) //Passed test and passed the fundraising game
                            {
                                medals[0].SetActive(true);
                                medals[3].SetActive(true);
                                dMan.ShowBox("Congratulations, you earned the gold medal! You're a model FBLA student ");
                                qMan.isStopped = true;
                                next = true;
                            }
                            else if (qMan.fundScore > 50) //Passed test and did alright in fundraising game
                            {
                                medals[1].SetActive(true);
                                medals[3].SetActive(true);
                                dMan.ShowBox("Congratulations, you earned a silver medal! Play again for gold!");
                                qMan.isStopped = true;
                                next = true;
                            }
                            else //Passed test but failed in fundraising game
                            {
                                medals[2].SetActive(true);
                                medals[3].SetActive(true);
                                dMan.ShowBox("Congratulations for passing the test, here is a bronze medal! Play again for gold!");
                                qMan.isStopped = true;
                                next = true;
                            }
                            break;
                    }
                }
                else //no fundraising 
                {
                    switch (qMan.passTest)
                    {
                        case -1: //No fundraising and failed the test
                            dMan.ShowBox("Better luck next time!");
                            break;
                        case 0: //Neither fundraising nor test
                            if (qMan.takeTest)
                                dMan.ShowBox("Good luck on the test!");
                            else
                                dMan.ShowBox("Welcome to FBLA!");

                            break;
                        case 1: //No fundraising but passed test
                            dMan.ShowBox("Great job on the test!");
                            break;
                    }
                }
            }
            if(next)
            {
                if(Input.GetKeyDown(KeyCode.Space)) {
                    Application.Quit();
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
            //Since dMan and qMan will not exist when the player leaves the scene, define them when the player is guaranteed 
            dMan = FindObjectOfType<DialogueManager>();
            qMan = FindObjectOfType<QuestManager>();
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
