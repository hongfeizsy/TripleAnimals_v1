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
        // FindObjectOfType<SceneLoader>().WaitAndLoadNextScene();
    }

    void Update()
    {
        if (waitTime >= 1f) 
        { 
            animator.SetTrigger("Howl"); 
        }
        waitTime += Time.deltaTime;
    }
}
