using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRowProducer : MonoBehaviour
{
    [SerializeField] int numberOfCards;
    float shiftInXAxis;
    float shiftInZAxis;

    private void Awake() 
    {
        shiftInXAxis = 0.1f;
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
            Card cardObject = Instantiate(cardPrefabs[cardIndexes[i]], transform.position - new Vector3(i * shiftInXAxis, 0, i * shiftInZAxis), transform.rotation);
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
