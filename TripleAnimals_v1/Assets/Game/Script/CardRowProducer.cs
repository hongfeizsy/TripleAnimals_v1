using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRowProducer : MonoBehaviour
{
    [SerializeField] int numberOfCards;
    float shiftInYAxis;
    float shiftInZAxis;

    private void Start() 
    {
        shiftInYAxis = 0.05f;
        shiftInZAxis = 0.01f;
    }

    public int NumberOfCards 
    {
        get {return numberOfCards; }
        set { numberOfCards = value; }
    }

    private void SpawnCards(Card[] cardPrefabs, List<int> cardIndexes) 
    {
        foreach (int idx in cardIndexes) {
            Card cardObject = Instantiate(cardPrefabs[idx], transform.position - new Vector3(0, shiftInYAxis, shiftInZAxis), transform.rotation);
        }
    }
}
