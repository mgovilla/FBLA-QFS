using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenePublic : MonoBehaviour           //Attached to tiles to transition scenes
{
    public string sceneName;                            //Public for ease of scene addition


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            SceneManager.LoadScene(sceneName);
    }

}

