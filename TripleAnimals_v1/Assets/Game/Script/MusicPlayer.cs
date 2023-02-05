using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); }

        audioSource = GetComponent<AudioSource>();
    }

    public void SetVolume(float volumn) {
        audioSource.volume = volumn;
    }

}
