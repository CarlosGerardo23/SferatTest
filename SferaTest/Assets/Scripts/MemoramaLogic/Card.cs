using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Card : MonoBehaviour
{
    public delegate void SpecialEffect();
    Image cardImage;
    public Deck myDeck;
    Button myButton;

    [HideInInspector] public bool isPairUp;
    [HideInInspector] public bool cardUp;

    [HideInInspector] public int index;

    [HideInInspector] public Sprite upSprite;
    void Awake()
    {
        cardImage = GetComponent<Image>();
        myButton = GetComponent<Button>();
    }

    public void UpCard()
    {
        cardImage.sprite = upSprite;
    }
    public void DownCard(Sprite cardSprite)
    {
        cardImage.sprite = cardSprite;
    }
   
    public void PickCard()
    {
        myDeck.CheckCardsInHand(this);
        myButton.interactable = false;
        cardUp = true;
    }

    public void SetButtonInteraction(bool status)
    {
        myButton.interactable = status;
    }
}
