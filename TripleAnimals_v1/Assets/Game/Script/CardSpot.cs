using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpot : MonoBehaviour
{
    [SerializeField] int spotNumber;
    [SerializeField] CardType cardType;
    [SerializeField] Card cardInSpot;
    [SerializeField] GameObject disappearanceVFX;
    

    bool isOccupied = false;

    public int SpotNumber
    {
        get { return spotNumber; }
    }

    public bool SpotOccupied
    {
        get { return isOccupied; }
        set { isOccupied = value; }
    }

    public CardType CardTypeInSpot   // I think this is unnecessary, and should be deleted later.
    {
        get { return cardType; }
        set { cardType = value; }
    }

    public Card CardInSpot
    {
        get { return cardInSpot; }
        set { cardInSpot = value; }
    }

    public void DestroyCardInSpot() {
        Destroy(cardInSpot.gameObject);
        cardType = CardType.Null;
        cardInSpot = null;
    }

    public void PlayDisVFX()
    {
        GameObject vfx = Instantiate(disappearanceVFX, transform.position, transform.rotation);
        Destroy(vfx, 0.5f);
    }
}
