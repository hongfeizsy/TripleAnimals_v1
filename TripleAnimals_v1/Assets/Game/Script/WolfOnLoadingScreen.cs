using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfOnLoadingScreen : MonoBehaviour
{
    SceneLoader sceneLoader;
    float waitTime;
    Animator animator;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        waitTime = 0f;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (waitTime >= 3f) 
        { 
            animator.SetTrigger("Howl"); 
            waitTime = 0f;
        }
        waitTime += Time.deltaTime;
    }
}
