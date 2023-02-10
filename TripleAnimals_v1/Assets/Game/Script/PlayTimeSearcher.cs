using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimeSearcher : MonoBehaviour
{
    [SerializeField] GameObject oneChanceMessage;
    [SerializeField] GameObject noChanceMessage;

    // public void TriggerPlayTimeIncreaser()
    // {
    //     GameObject gmObj = GameObject.Find("PlayTimeIdentifier");
    //     // gmObj.GetComponent<PlayTimeIdentifier>().IncreasePlayTime();
    //     if (gmObj.GetComponent<PlayTimeIdentifier>().PlayTime < 1) {
    //         gmObj.GetComponent<PlayTimeIdentifier>().IncreasePlayTime();
    //     }
    // }

    public void LoadOneChanceMessage()
    {
        GameObject gmObj = GameObject.Find("PlayTimeIdentifier");
        if (gmObj.GetComponent<PlayTimeIdentifier>().PlayTime < 1) {
            oneChanceMessage.SetActive(true);
            gmObj.GetComponent<PlayTimeIdentifier>().IncreasePlayTime();
            SceneLoader loader = FindObjectOfType<SceneLoader>();
            loader.WaitAndLoadCurrentScene();
        }
        else 
        {
            noChanceMessage.SetActive(true);
            // StartCoroutine(WaitAndKillNoChanceWin());
        }
    }

    // private IEnumerator WaitAndKillNoChanceWin()
    // {
    //     noChanceMessage.SetActive(true);
    //     yield return new WaitForSeconds(1f);
    //     noChanceMessage.SetActive(false);
    // }
}
