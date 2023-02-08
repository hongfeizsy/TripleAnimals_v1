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
            foreach (GameObject identifier in FindObjectsOfType(GetType())) 
            {
                if (identifier.GetComponent<PlayTimeIdentifier>().playTime > 0) {
                    Destroy(identifier);
                }
            } 
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
