using UnityEngine;
using System.Collections;

public class PongController : MonoBehaviour                                             //Attached to the pong player
{                                                                                       //Control the pong 
    //Declare variables
    public float paddleSpeed;
    public UnityEngine.GameObject ballprefab;
    private Vector3 playerPos = new Vector3(0, -1.5f, 0);
    //public Transform parent;

    public float ballForce = 150f;
    private UnityEngine.GameObject newBall;

    private PongManager pongManager;
    UnityEngine.GameObject manager;
    /*initialize variables*/
    private void Start()
    {
        manager = UnityEngine.GameObject.Find("GameManager");
        pongManager = manager.GetComponent<PongManager>();
        SpawnBall();
    }


    public void SpawnBall() //Method is called when no ball exists
    {
        if (ballprefab == null)
        {
            Debug.Log("add ballPrefab");
            return;
        }
        Vector3 ballPos = transform.position + new Vector3(0, .4f, 0);
        newBall = Instantiate(ballprefab, ballPos, Quaternion.identity) as UnityEngine.GameObject;
        pongManager.isStarted = false;
        //newBall.transform.SetParent(parent);

    }

    void FixedUpdate() //fixed update for physics 
    {
        if (!pongManager.gameOver) { //As long as game is running
            float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
            playerPos = new Vector3(Mathf.Clamp(xPos, -1.43f, 1.5f), -1.5f, 0f);
            transform.position = playerPos;

            if (newBall) //as long as the newball exists
            {
                Rigidbody ballRigid = newBall.GetComponent<Rigidbody>();
                ballRigid.position = transform.position + new Vector3(0, .3f, 0);
                if (Input.GetKeyDown("space")) //start the game
                {
                    pongManager.isStarted = true;
                    ballRigid.AddForce(0, ballForce, 0);
                    newBall = null;

                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision) //Change the force of the ball based on where the ball hits
    {
        float direction = this.transform.position.x - collision.contacts[0].point.x;
        collision.rigidbody.AddForce(direction * -300, 0, 0);
    }
}