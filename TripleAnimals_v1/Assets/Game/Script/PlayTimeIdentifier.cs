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
        print(FindObjectsOfType(GetType()).Length);
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
        if (playTime == 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playTime++;
        }
    }
}
