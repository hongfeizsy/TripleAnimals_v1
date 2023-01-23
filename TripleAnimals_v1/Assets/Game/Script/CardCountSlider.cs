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

    private void Start() 
    {
        slider = GetComponent<Slider>();   
        handle = GameObject.Find("Handle");
        handleAnimalFigure = GameObject.Find("DeerHandle");
    }

    void Update()
    {
        remainingCardCount = FindObjectsOfType<Card>().Length;
        slider.value = 1 - (float)remainingCardCount / (float)initialCardCount;
        handleAnimalFigure.transform.position = handle.transform.position;
    }

    public int InitialCardCount
    {
        get { return initialCardCount; }
        set { initialCardCount = value; }
    }
}
