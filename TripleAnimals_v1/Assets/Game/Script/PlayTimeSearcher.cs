using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimeSearcher : MonoBehaviour
{
    public void TriggerPlayTimeIncreaser()
    {
        GameObject gmObj = GameObject.Find("PlayTimeIdentifier");
        gmObj.GetComponent<PlayTimeIdentifier>().IncreasePlayTime();
    }
}
