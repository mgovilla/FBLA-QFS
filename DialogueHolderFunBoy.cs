using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolderFunBoy : MonoBehaviour                                       //Attached to dialogue zone(blue boy)
{                                                                                       //Dialogue for the blue boy
    //Declare variables
    private DialogueManager dMan;
    private QuestManager qMan;

    private bool inTrigger;
    /*Initialize variables*/
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        qMan = FindObjectOfType<QuestManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger)
        {
            if(qMan.fundScore == 5) //fundraising not done yet
            {
                //Not an ideal solution because y can be pressed without activating dialogue
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    dMan.ShowBox("Our FBLA chapter needs money! Will you help me collect some? Y|N");
                    //textShown = true;
                }
                if (Input.GetAxisRaw("Fire3") > .5)// && textShown) //Y BUTTON pressed
                {
                    Debug.Log("Play game");
                    //paper.SetActive(true);
                    //paper.GetComponent<SpriteRenderer>().enabled = true;
                    GetComponent<LoadNewScene>().LoadNextScene("Fundraise");
                }
            } else if(qMan.fundScore > 90) // if the fundraising was good
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    dMan.ShowBox("Well done dude! You got $" + qMan.fundScore.ToString()); 
                    //textShown = true;
                }
            } else if(qMan.fundScore < 0) //Failed the fundraising
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    dMan.ShowBox("Rough times... we can try again next year!");
                    //textShown = true;
                }
            } else //average fundraising
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    dMan.ShowBox("You should talk to the professor, at least we made something!");
                    //textShown = true;
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
