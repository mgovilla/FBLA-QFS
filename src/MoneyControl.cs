using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoneyControl : MonoBehaviour                                           //Attached to money prefabs           
{                                                                                   //Control the money with random force
    //Declare Variables
    Rigidbody2D rigid;
    Vector2 initForce;

    
    /*Initialize Variables*/
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        initForce = new Vector2(Random.Range(-50, 50), 0); //Random movement 
        rigid.AddForce(initForce);
                
	}
}
