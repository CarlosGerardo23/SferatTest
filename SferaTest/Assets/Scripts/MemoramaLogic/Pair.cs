using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Pair
{
    [SerializeField] Sprite upCardSprite;

    public Card[] CreateCards(GameObject prefabCard, Sprite backImage, int index)
    {
   
        Card[] cards = new Card[2];
        for (int i = 0; i < cards.Length; i++)
        {
            GameObject tempCard = GameObject.Instantiate(prefabCard);
            tempCard.GetComponent<Card>().upSprite=upCardSprite;
            tempCard.GetComponent<Card>().DownCard(backImage);
            tempCard.GetComponent<Card>().index = index;
            cards[i] = tempCard.GetComponent<Card>();
        }
        return cards;
    }

    public static bool IsPairUp(Card card1,Card card2)
    {

        return card1.index == card2.index;
         
    }


}
