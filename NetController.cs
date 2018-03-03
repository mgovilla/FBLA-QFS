using UnityEngine;
using System.Collections;

public class NetController : MonoBehaviour                                              //Attached to the net
{                                                                                       //Control the net
    //Declare Variables
    public float paddleSpeed;
    
    private Vector3 playerPos = new Vector3(0, -3.7f, 0);
    //public Transform parent;

    private FundManager fundManager;
    GameObject manager;
    /*Initialize Variables*/
    private void Start()
    {
        manager = GameObject.Find("GameManager");
        fundManager = manager.GetComponent<FundManager>();
        
    }

    
    
    void Update()
    {
        if (!fundManager.gameOver)
        {
            float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
            playerPos = new Vector3(Mathf.Clamp(xPos, -4.5f, 4.5f), -3.7f, 0f);
            transform.position = playerPos;
      
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "good")
            fundManager.score += 10;

        if (collision.gameObject.tag == "bad")
            fundManager.score -= 10;

        Destroy(collision.gameObject);
    }
}