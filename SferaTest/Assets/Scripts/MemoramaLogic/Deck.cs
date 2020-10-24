using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Deck")]
public class Deck : ScriptableObject
{
    [Range(1, 48)]
    public int numberOfCards;


    [SerializeField] GameObject cardPrefab;
    [SerializeField] Sprite cardBackGround;
    [SerializeField] Sprite cardtrap;

    [SerializeField] bool useCardTrap;


    [SerializeField] List<Pair> deckPairs;

   [HideInInspector] public PairStatus pairStatus;
    List<Card> cardsOnGame;
    Transform parent;
    Card[] cardsInHand;
    public void CreateDeck(Transform refParent)
    {
        parent = refParent;
        numberOfCards = numberOfCards % 2 != 0 ? numberOfCards - 1 : numberOfCards;
        pairStatus = PairStatus.NULL;
        cardsOnGame = new List<Card>();
        if (useCardTrap)
            CreateDemonCard();
        for (int i = 0; i < deckPairs.Count; i++)
        {
            if (!AddCardsOnGame(deckPairs[i].CreateCards(cardPrefab, cardBackGround, i)))
                break;
        }


        ShuffleCards();
        SetCardsOnGame(parent);
        cardsInHand = new Card[2];
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
    public void CreateDemonCard()
    {
        GameObject tempCard = GameObject.Instantiate(cardPrefab);
        tempCard.GetComponent<Card>().upSprite = cardtrap;
        tempCard.GetComponent<Card>().DownCard(cardBackGround);
        tempCard.GetComponent<Card>().index = -1;
        cardsOnGame.Add(tempCard.GetComponent<Card>());
    }
    public void SetCardsOnGame(Transform parent)
    {
        for (int i = 0; i < cardsOnGame.Count; i++)
        {
            Card temp = cardsOnGame[i];
            temp.gameObject.transform.SetParent(parent);
        }
    }
    bool AddCardsOnGame(Card[] tempCards)
    {
        if (cardsOnGame.Count >= numberOfCards)
            return false;

        for (int i = 0; i < tempCards.Length; i++)
        {

            cardsOnGame.Add(tempCards[i]);
        }
        return true;
    }

    public void CheckCardsInHand(Card newCard)
    {
        newCard.UpCard();
        if (newCard.index == -1)
        {
            pairStatus = PairStatus.TRAP;
            return;
        }

        if (cardsInHand[0] == null)
        {
            cardsInHand[0] = newCard;
        }

        else
        {
            cardsInHand[1] = newCard;
            DesactivateAllCards(false);
            if (Pair.IsPairUp(cardsInHand[0], cardsInHand[1]))
            {
                for (int i = 0; i < cardsInHand.Length; i++)
                {
                    cardsInHand[i].isPairUp = true;
                }
                pairStatus = PairStatus.POSITIVE;
            }
            else
            {
                pairStatus = PairStatus.NEGATIVE;
            }
        }

    }
    public IEnumerator TrapCardActivated()
    {
        pairStatus = PairStatus.NULL;

        yield return new WaitForSeconds(0.5f);
        DesactivateAllCards(true);
        for (int i = 0; i < cardsInHand.Length; i++)
        {
            if (cardsInHand[i] == null)
                continue;

            if (cardsInHand[i].index == -1)
                cardsInHand[i].SetButtonInteraction(false);

            cardsInHand[i].isPairUp = false;
            cardsInHand[i].DownCard(cardBackGround);
            cardsInHand[i] = null;
        }

        SetCardsOnGame(null);
        ShuffleCards();
        SetCardsOnGame(parent);
        yield return new WaitForSeconds(0.5f);
        pairStatus = PairStatus.NULL;

    }
    public IEnumerator NotPair()
    {
        pairStatus = PairStatus.NULL;

        yield return new WaitForSeconds(1f);
        DesactivateAllCards(true);
        for (int i = 0; i < cardsInHand.Length; i++)
        {
            cardsInHand[i].isPairUp = false;
            cardsInHand[i].DownCard(cardBackGround);
            cardsInHand[i] = null;
        }

    }

    public void IsPair()
    {
        pairStatus = PairStatus.NULL;
        DesactivateAllCards(true);

        for (int i = 0; i < cardsInHand.Length; i++)
        {
            cardsInHand[i].isPairUp = true;
            cardsInHand[i].SetButtonInteraction(false);
            cardsInHand[i] = null;
        }
        if (CheckAllCards())
        {
            Debug.Log("Ganaste");
        }

    }

    public bool CheckAllCards()
    {
        for (int i = 0; i < cardsOnGame.Count; i++)
        {
            if (cardsOnGame[i].index == -1)
                continue;
            if (!cardsOnGame[i].isPairUp)
                return false;
        }
        return true;
    }
    public void DesactivateAllCards(bool activation)
    {
        for (int i = 0; i < cardsOnGame.Count; i++)
        {
            if (cardsOnGame[i].index == -1&&cardsOnGame[i].cardUp)
                continue;

            if (!cardsOnGame[i].isPairUp)
                cardsOnGame[i].SetButtonInteraction(activation);

        }

    }
}

public enum PairStatus { NULL, NEGATIVE, POSITIVE, TRAP }