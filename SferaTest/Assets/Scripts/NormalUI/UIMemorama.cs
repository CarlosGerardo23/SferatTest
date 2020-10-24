using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIMemorama : MonoBehaviour
{
    [SerializeField] UserConfirmation user;
    [SerializeField] Deck deck;
    [SerializeField] Text welcomeText;
    [SerializeField] Text scoreText;
    [SerializeField] Text timerText;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        welcomeText.text += user.UserInput.user;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = ((int)timer).ToString();
        scoreText.text = deck.score.ToString();
    }
}
