using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction {
    Left, Right, Up, Down
}

public class CardRowProducer : MonoBehaviour
{
    [SerializeField] int numberOfCards;
    [SerializeField] Direction direction;
    float shiftInXAxis;
    float shiftInYAxis;
    float shiftInZAxis;

    private void Awake() 
    {
        shiftInXAxis = 0.1f;
        shiftInYAxis = 0.1f;
        shiftInZAxis = 1f;
    }

    public int NumberOfCards 
    {
        get { return numberOfCards; }
        set { numberOfCards = value; }
    }

    public void SpawnCards(Card[] cardPrefabs, List<int> cardIndexes) 
    {
        int layerNumber = cardIndexes.Count;
        for (int i = 0; i < layerNumber; i++)
        {
            Card cardObject;
            switch (direction) 
            {
                case Direction.Right: cardObject = Instantiate(cardPrefabs[cardIndexes[i]], transform.position - new Vector3(i * shiftInXAxis, 0, i * shiftInZAxis), transform.rotation); break;
                case Direction.Left: cardObject = Instantiate(cardPrefabs[cardIndexes[i]], transform.position - new Vector3(-i * shiftInXAxis, 0, i * shiftInZAxis), transform.rotation); break;
                case Direction.Up: cardObject = Instantiate(cardPrefabs[cardIndexes[i]], transform.position - new Vector3(0, i * shiftInYAxis, i * shiftInZAxis), transform.rotation); break;
                case Direction.Down: cardObject = Instantiate(cardPrefabs[cardIndexes[i]], transform.position - new Vector3(0, -i * shiftInYAxis, i * shiftInZAxis), transform.rotation); break;
                default: continue;
            }

            cardObject.Origin = CardOrigin.Row;
            cardObject.CardIndex = 0;      // All cards from Row Producer has a zero index.
            cardObject.gameObject.transform.parent = this.transform;
            if (i == layerNumber - 1) { cardObject.IsTouchable = true; }
            else { cardObject.IsTouchable = false; }
        }
    }

    public void EnableCardInQueue() {
        if (transform.childCount >= 1) {
            transform.GetChild(transform.childCount - 1).GetComponent<Card>().IsTouchable = true;
        }
    }
}
