using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour           //Attached to anything to transition scenes
    {
        
        public void LoadNextScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
   
    }

