using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCountSlider : MonoBehaviour
{
    Slider slider;
    int initialCardCount, remainingCardCount;
    GameObject handle;
    GameObject handleAnimalFigure;

    void Start()
    {
        slider = GetComponent<Slider>();   
        initialCardCount = FindObjectsOfType<Card>().Length;
        remainingCardCount = FindObjectsOfType<Card>().Length;
        handle = GameObject.Find("Handle");
        handleAnimalFigure = GameObject.Find("DeerHandle");
    }

    void Update()
    {
        remainingCardCount = FindObjectsOfType<Card>().Length;
        slider.value = 1 - (float)remainingCardCount / (float)initialCardCount;
        handleAnimalFigure.transform.position = handle.transform.position;
    }
}
