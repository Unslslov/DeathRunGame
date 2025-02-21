using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNull : MonoBehaviour
{
    private void Awake() 
    {
        PlayerPrefs.DeleteAll();

        Debug.Log("0: " + (PlayerPrefs.GetInt(TuttorTag.TutorialCompletedKey, 0) == 0));
        
        Debug.Log("1: " + (PlayerPrefs.GetInt(TuttorTag.TutorialCompletedKey, 1) == 1));

        PlayerPrefs.DeleteKey(TuttorTag.TutorialCompletedKey);
        PlayerPrefs.Save();

        Debug.Log("0: " + (PlayerPrefs.GetInt(TuttorTag.TutorialCompletedKey, 0) == 0));
        
        Debug.Log("1: " + (PlayerPrefs.GetInt(TuttorTag.TutorialCompletedKey, 1) == 1));
    }       
}

