using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Pair 
{
    [SerializeField] Sprite upCardSprite;
    Card[] cards = new Card[2];
    bool isPairUp;
    public Card[] CreateCards(GameObject prefabCard,Sprite backImage,int index)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            GameObject tempCard = GameObject.Instantiate(prefabCard);
            tempCard.GetComponent<Card>().SetCardImage(backImage);
            tempCard.GetComponent<Card>().index=index;
            
        }
        return cards;
    }


}
