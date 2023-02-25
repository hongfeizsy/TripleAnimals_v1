using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChanceCounter : MonoBehaviour
{
    PlayTimeIdentifier playtimeId;
    
    void Start()
    {
        playtimeId = FindObjectOfType<PlayTimeIdentifier>();        
        RawImage[] foxImages = this.transform.GetComponentsInChildren<RawImage>();
        for (int i = 0; i < foxImages.Length; i++) {
            if (i >= (4 - playtimeId.PlayTime)) {
                foxImages[i].enabled = false;
            }
        }
    }
}
