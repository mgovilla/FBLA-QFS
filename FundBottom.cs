using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundBottom : MonoBehaviour                                             //This attaches to the bottom 
{                                                                                   //This simply destroys the money not collected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);                                              
    }
}
