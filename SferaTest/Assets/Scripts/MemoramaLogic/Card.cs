using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Card : MonoBehaviour
{
    public delegate void SpecialEffect();
    Image cardImage;
    [HideInInspector] public Deck myDeck;
    [HideInInspector] public bool cardUp;

    [HideInInspector] public int index;

    void Awake()
    {
        cardImage = GetComponent<Image>();
    }

    public void SetCardImage(Sprite cardSprite)
    {
        cardImage.sprite = cardSprite;
    }

}
