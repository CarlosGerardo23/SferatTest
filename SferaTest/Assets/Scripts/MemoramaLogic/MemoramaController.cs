using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoramaController : MonoBehaviour
{
    [SerializeField] Deck deck;
    [SerializeField] Transform deckHolder;
    // Start is called before the first frame update
    void Start()
    {
        deck.CreateDeck(deckHolder);
    }

    // Update is called once per frame
    void Update()
    {
        switch (deck.pairStatus)
        {
            case PairStatus.NULL:
                break;
            case PairStatus.NEGATIVE:
                StartCoroutine(deck.NotPair());
                break;
            case PairStatus.POSITIVE:
                deck.IsPair();
                break;
            case PairStatus.TRAP:
                StartCoroutine(deck.TrapCardActivated());
                break;
            default:
                break;
        }
      
    }
}
