using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Deck")]
public class Deck : ScriptableObject
{
    [Range(1, 24)]
    int numberOfPairs;

    [SerializeField] GameObject cardPrefab;
    [SerializeField] Sprite cardBackGround;
    [SerializeField] Sprite cardtrap;

    [SerializeField] bool useCardTrap;


    [SerializeField] List<Pair> deckPairs;
    List<Card> cardsOnGame;
    public void CreateDeck(Transform parent)
    {
        cardsOnGame = new List<Card>();
        for (int i = 0; i < deckPairs.Count; i++)
            AddCardsOnGame(deckPairs[i].CreateCards(cardPrefab, cardBackGround, i));

        ShuffleCards();
        SetCardsOnGame(parent);
    }
    public void ShuffleCards()
    {
        for (int i = 0; i < cardsOnGame.Count; i++)
        {
            Card temp = cardsOnGame[i];
            int randomIndex = Random.Range(i, cardsOnGame.Count);
            cardsOnGame[i] = cardsOnGame[randomIndex];
            cardsOnGame[randomIndex] = temp;
        }
    }
    public void SetCardsOnGame(Transform parent)
    {
        for (int i = 0; i < cardsOnGame.Count; i++)
        {
            Card temp = cardsOnGame[i];
            temp.gameObject.transform.SetParent(parent);
        }
    }
    void AddCardsOnGame(Card[] tempCards)
    {
        for (int i = 0; i < tempCards.Length; i++)
            cardsOnGame.Add(tempCards[i]);
    }
}
