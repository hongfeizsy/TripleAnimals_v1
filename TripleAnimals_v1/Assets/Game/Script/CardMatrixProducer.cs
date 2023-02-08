using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class CardMatrixProducer : MonoBehaviour
{
    [SerializeField] Card[] CardPrefabs;
    [SerializeField] Vector2 cardPairRange;
    [SerializeField] Vector2 matrixDimension;
    [SerializeField] int verticalShift = 3;     // Create some space for cards in rows.
    [SerializeField] List<CardRowProducer> rowProducerList;

    int maxlayer;         // It is only the up-boundary, and will never be reached.
    int row, column;
    bool[,,] occupiedIndicator;
    float cardWidth, cardHeight;
    List<int> cardIndex = new List<int>();   // This is just for cards from Matrix.
    List<Vector3> CoordidateList = new List<Vector3>();
    List<List<Vector3>> cardRelation = new List<List<Vector3>>();
    List<int> randCardArrangement = new List<int>();
    int totalNumberOfCardsFromRowProd;

    void Start()
    {
        Vector3 coordinate = new Vector3();
        cardWidth = CardPrefabs[0].GetComponent<BoxCollider2D>().size[0] + 0.1f;
        cardHeight = CardPrefabs[0].GetComponent<BoxCollider2D>().size[1] + 0.1f;
        float cardScalingFactor = CardPrefabs[0].gameObject.transform.localScale[0];
        
        maxlayer = 100;
        row = (int)matrixDimension.y;
        column = (int)matrixDimension.x;
        float shiftInZAxis = 1f;
        ProduceRandCardArrangement();

        // Row producer:
        totalNumberOfCardsFromRowProd = 0;
        foreach (CardRowProducer rowProducer in rowProducerList)
        {
            rowProducer.SpawnCards(CardPrefabs, randCardArrangement.GetRange(totalNumberOfCardsFromRowProd, rowProducer.NumberOfCards));
            totalNumberOfCardsFromRowProd += rowProducer.NumberOfCards;
        }
        randCardArrangement.RemoveRange(0, totalNumberOfCardsFromRowProd);

        // Matrix producer:
        System.Random rnd = new System.Random(123);
        int idx = 0;           // Same as cardTypeCount??? Necessary???
        int cardTypeIndex = 0;
        int myLayer = 0;
        for (int k = 0; k < maxlayer; k++) 
        {
            for (int j = 0; j < row; j++) 
            {
                for (int i = 0; i < column; i++) 
                {
                    if (CreateFillingCondition(k, j, i) && rnd.Next(100) <= 50) 
                    {
                        coordinate = new Vector3((int)(i - column / 2), (int)(j - row / 2) + verticalShift, (int)k);
                        cardTypeIndex = randCardArrangement[idx];
                        var cardObject = Instantiate(CardPrefabs[cardTypeIndex], 
                            new Vector3(coordinate.x * (cardWidth / 2) * cardScalingFactor, coordinate.y * (cardHeight / 2) * cardScalingFactor, 
                                - (shiftInZAxis * coordinate.z + 1)), Quaternion.identity, gameObject.transform);
                        cardObject.Origin = CardOrigin.Matrix;
                        CoordidateList.Add(coordinate);
                        cardObject.Coordidate = coordinate;
                        cardObject.CardIndex = idx + totalNumberOfCardsFromRowProd;
                        cardIndex.Add(cardObject.CardIndex);
                        idx++;
                        cardObject.IsTouchable = false;
                        if (idx >= randCardArrangement.Count) { goto EndStart; }
                    }
                }
            }
            myLayer++;
        }

        EndStart: 
        {
            cardRelation = IdentifyCardRelation(maxlayer);
            SetCardTouchability();
            FindObjectOfType<CardCountSlider>().InitialCardCount = randCardArrangement.Count + totalNumberOfCardsFromRowProd;
            print("How many layers finally? " + (myLayer + 1));
            print("How many cards in total? " + (randCardArrangement.Count + totalNumberOfCardsFromRowProd));
            print("How many cards produced by Matrix? " + cardRelation.Count);
        };
    }

    private void ProduceRandCardArrangement()
    {
        int numberOfType = CardPrefabs.Count();
        List<int> numberOfPairs = new List<int>();    // 3N cards for each type.
        List<int> cardArrangement = new List<int>();
        System.Random rnd = new System.Random();
        for (int i = 0; i < numberOfType; i++)
        {
            numberOfPairs.Add(rnd.Next((int)cardPairRange.x, (int)cardPairRange.y));
            cardArrangement.AddRange(Enumerable.Repeat(i, 3 * numberOfPairs[i]).ToList());
        }
        
        randCardArrangement = cardArrangement.OrderBy(x => rnd.Next()).ToList();    // Shuffle the cards.
        print(string.Format("The random card list: ({0})", string.Join(", ", randCardArrangement)));
    }

    private bool CreateFillingCondition(int layer, int col, int row) 
    {
        if (layer % 4 == 0 && col % 2 == 0 && row % 2 == 0) { return true; }
        if (layer % 4 == 1 && col % 2 == 0 && row % 2 == 1) { return true; }
        if (layer % 4 == 2 && col % 2 == 1 && row % 2 == 1) { return true; }
        if (layer % 4 == 3 && col % 2 == 1 && row % 2 == 0) { return true; }
        return false;
    }

    private List<List<Vector3>> IdentifyCardRelation(int layer) 
    {
        int x = 0, y = 0, z = 0;
        int _x = 0, _y = 0, _z = 0;
        List<List<Vector3>> cardRelation = new List<List<Vector3>>();
        int cardCounter = 0; 
        foreach (Vector3 coordinate in CoordidateList)
        {
            cardRelation.Add(new List<Vector3>());
            if (coordinate.z == layer - 1) { continue; }
            else 
            {
                foreach (Vector3 _coordinate in CoordidateList) 
                {
                    x = (int)coordinate.x;
                    y = (int)coordinate.y;
                    z = (int)coordinate.z;
                    _x = (int)_coordinate.x;
                    _y = (int)_coordinate.y;
                    _z = (int)_coordinate.z;
                    
                    if ((z < _z) && (x <= _x + 1 && x >= _x - 1) && (y <= _y + 1 && y >= _y - 1)) {
                        cardRelation[cardCounter].Add(new Vector3(_x, _y, _z));
                    }
                }
                cardCounter++;
            }
        }
        return cardRelation;
    }

    public void RemoveItemsFromLists(int cardIdx, Vector3 cardCoordinate)
    {
        int idx = cardIndex.IndexOf(cardIdx);
        cardIndex.RemoveAt(idx);
        cardRelation.RemoveAt(idx);
        foreach (List<Vector3> coordinateList in cardRelation)
        {
            if (coordinateList.Contains(cardCoordinate))
            {
                coordinateList.Remove(cardCoordinate);
            }
        }
    }

    public void SetCardTouchability() 
    {
        // List of CardIndex should always have the same length as List of CardRelation. Those are only for cards from Matrix.
        int idx = 0;

        Card[] cards = FindObjectsOfType<Card>();
        foreach (Card card in cards) 
        {
            if (card.Origin == CardOrigin.Matrix && cardIndex.Contains(card.CardIndex)) 
            {
                idx = cardIndex.IndexOf(card.CardIndex);
                if (cardRelation[idx].Count == 0) {
                    card.IsTouchable = true;
                }
                else {
                    card.IsTouchable = false;
                }
            }
        }
    }
}
