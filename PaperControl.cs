using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperControl : MonoBehaviour                                               //Attached to the paper
{                                                                                       //Control the paper object
    //Declare Variables
    private DialogueManager dMan;
    private QuestManager qMan;
    
    //When the player touches the paper
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dMan = FindObjectOfType<DialogueManager>();
            qMan = FindObjectOfType<QuestManager>();
            dMan.ShowBox("You found papers.");
            qMan.isCompleted[0] = true; //update the quest manager
            Destroy(gameObject);
        }
    }
}
