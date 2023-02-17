using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotter : MonoBehaviour
{
    int count = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ScreenCapture.CaptureScreenshot($"C:/Users/Hongfei/Desktop/Work/IOS/TripleAnimals/Screenshots/screenshot_{count++}.png");
        }
    }
}
