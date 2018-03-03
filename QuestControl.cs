using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestControl : MonoBehaviour
{                                                                                               //For future use in expansion
    

    public void StartQuest()
    {
        gameObject.SetActive(true);
    }

    public void EndQuest()
    {
        gameObject.SetActive(false);
    }
}
