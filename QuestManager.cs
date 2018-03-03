using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour                                                       //This is attached to the character
{                                                                                               //This manages the quests and holds global variables
    //Declaring variables
    public QuestControl[] quests;
    public bool[] isAccepted;
    public bool[] isCompleted;
    private DialogueManager dMan;
    public bool takeTest = false;
    public bool isStopped = false;
    private GameObject paper;

    public int passTest = 0;
    public int fundScore = 5; //impossible value if they had played

    // Update is called once per frame
    void Update () {
        if (Input.GetKey("escape"))         //In case the use wants to quit
            Application.Quit();

        Scene currentScene = SceneManager.GetActiveScene(); //Check the current scene since paper is only in one
        
        if (paper) //check if paper is null
        {
            if (isAccepted[0] && !isCompleted[0])
            {
                //paper.GetComponent<SpriteRenderer>().enabled = true;
                paper.SetActive(true); //Show the paper after the player accepts the quest and hasnt completed
            }
            else
            {
                paper.SetActive(false);
            }
        } else //if so, define it
        {
            if(currentScene.name == "Main") //if the scene contains paper
            {
                paper = GameObject.Find("Paper"); //definition
            }
        }

    }

    public void StartQuest(int number)
    {
        dMan = FindObjectOfType<DialogueManager>();
        quests[number].StartQuest();
        dMan.ShowBox("Quest Accepted");
    }

    public void EndQuest(int number)
    {
        dMan = FindObjectOfType<DialogueManager>();
        quests[number].EndQuest();
        dMan.ShowBox("Quest Completed!");   
    }
}
