using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongManager : MonoBehaviour                                                    //Attached to the game object
{                                                                                           //Managing the pong game
    //Declare variables
    public int lives = 3;
    public int bricks = 9;
    public bool gameOver = false;
    public GameObject GameOver;
    public GameObject YouWin;
    public Text LivesText;

    public bool isStarted;

    private QuestManager qMan;



    // Use this for initialization
    void Start () {
        //youLose = GameObject.Find("GameOver");
        qMan = FindObjectOfType<QuestManager>();
    }
   

    // Update is called once per frame
    void Update () {
        LivesText.text = "Lives: " + lives.ToString();

		if(lives <= 0)
        {
            Debug.Log("Game Over");
            qMan.passTest = -1;
            GameOver.SetActive(true);
            gameOver = true;
        }

        if (bricks <= 0)
        {
            Debug.Log("You win");
            qMan.passTest = 1;
            YouWin.SetActive(true);
            gameOver = true;
        }

        if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                qMan.takeTest = false;
                GetComponent<LoadNewScene>().LoadNextScene("Main");
            }
        }
	}
}
