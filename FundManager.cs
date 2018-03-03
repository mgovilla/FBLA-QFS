using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FundManager : MonoBehaviour                                        //Attached to the fund manager object
{                                                                               //This manages the fund game
    //Declare Variables
    public bool gameOver = false;
    public int score = 0;

    public float timeElapsed;
    public int timeLeft;
    public Text timeText;
    public Text scoreText;
    public GameObject cont;

    public GameObject img;
    
    public GameObject badMoney;
    public GameObject goodMoney;

    Vector2 initPos;

    private QuestManager qMan;
    /*Initialize Variables*/
    void Start () {
        qMan = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () { //Physics calculations in fixed update according to convention
        timeElapsed += Time.deltaTime; //sum the time elapsed
        timeLeft = (int) Math.Round(45 - timeElapsed); //integer value of time left (maybe better to truncate)

        if (timeLeft > 0) //While the game is active
        {
            timeText.text = "Time left: " + timeLeft.ToString(); 
            scoreText.text = "Score: " + score.ToString();
            initPos = new Vector2(UnityEngine.Random.Range(-3.4f, 3.4f), 5);

            if (Math.Abs((timeElapsed % 3) - 1.5) < .025) { //Not an ideal solution: maybe dependent on frame rate
                
                Instantiate(badMoney, initPos, Quaternion.identity);

            } else if (Math.Abs(timeElapsed % 3 - 0) < .025) 
            {

                Instantiate(goodMoney, initPos, Quaternion.identity); //Add the money in the screen every time
            }

        } else
        {
            gameOver = true;
            img.SetActive(true); //Show the time up
            cont.SetActive(true);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (qMan)
                {
                    qMan.fundScore = score; //update the quest manager
                    qMan.isCompleted[1] = true;
                }
                    
                GetComponent<LoadNewScene>().LoadNextScene("School"); //Go back to school
            }
        }

        
	}
}
