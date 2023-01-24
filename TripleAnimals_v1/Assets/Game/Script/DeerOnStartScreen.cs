using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Status {
    Watch, Eat
}

public class DeerOnStartScreen : MonoBehaviour
{
    Animator animator;
    float waitTime;
    Status currentStatus;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        waitTime = 0f;
        // animator.SetTrigger("Eat");
        currentStatus = Status.Watch;    
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime >= 2f) 
        {
            waitTime = 0;
            if (currentStatus == Status.Watch) 
            { 
                currentStatus = Status.Eat; 
                animator.SetTrigger("Eat");
            }
            else 
            { 
                currentStatus = Status.Watch; 
                animator.SetTrigger("Watch");
            }

        }
        else 
        {
            waitTime += Time.deltaTime;
        }
    }
}
