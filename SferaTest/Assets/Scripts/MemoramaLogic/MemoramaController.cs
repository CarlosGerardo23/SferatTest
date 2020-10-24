using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class MemoramaController : MonoBehaviour
{
    [SerializeField] Deck deck;
    [SerializeField] Transform deckHolder;
   [SerializeField] UnityEvent onSucces;
   [SerializeField] UnityEvent onFailure;
   [SerializeField] UnityEvent onVictory;
    // Start is called before the first frame update
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
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
                onFailure.Invoke();
                break;
            case PairStatus.POSITIVE:
                onSucces.Invoke();
                deck.IsPair(onVictory);
                break;
            case PairStatus.TRAP:
                onFailure.Invoke();
                StartCoroutine(deck.TrapCardActivated());
                break;
            default:
                break;
        }
      
    }
}
