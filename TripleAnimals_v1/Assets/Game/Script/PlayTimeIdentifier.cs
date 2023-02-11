using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTimeIdentifier : MonoBehaviour
{
    int playTime;

    void Start()
    {
        playTime = 0;
        if (FindObjectsOfType(GetType()).Length > 1) 
        {
            foreach (PlayTimeIdentifier identifier in FindObjectsOfType(typeof(PlayTimeIdentifier)))
            {
                if (identifier.playTime > 0) {
                    identifier.playTime = 0;
                }
            } 
            Destroy(gameObject);
        }
        else { DontDestroyOnLoad(gameObject); }
    }

    public void IncreasePlayTime() 
    {
        playTime++;
    }

    public int PlayTime {
        get { return playTime; }
        set { playTime = value; }
    }
}
