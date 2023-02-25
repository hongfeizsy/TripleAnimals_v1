using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimeSearcher : MonoBehaviour
{
    [SerializeField] GameObject oneChanceMessage;
    [SerializeField] GameObject noChanceMessage;

    public void LoadOneChanceMessage()
    {
        GameObject gmObj = GameObject.Find("PlayTimeIdentifier");
        if (gmObj.GetComponent<PlayTimeIdentifier>().PlayTime < 3) {
            oneChanceMessage.SetActive(true);
            gmObj.GetComponent<PlayTimeIdentifier>().IncreasePlayTime();
            SceneLoader loader = FindObjectOfType<SceneLoader>();
            loader.WaitAndLoadCurrentScene();
        }
        else 
        {
            noChanceMessage.SetActive(true);
        }
    }
}
