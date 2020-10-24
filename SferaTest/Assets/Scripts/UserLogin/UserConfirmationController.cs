using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UserConfirmationController : MonoBehaviour
{
    [SerializeField] UserConfirmation user;

    [SerializeField] InputField userInput;
    [SerializeField] InputField passwordInput;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

  
    
    public void LogIn()
    {
        user.SetUserInput(userInput.text, passwordInput.text);
        StartCoroutine(user.CheckUserData(LogInStatus));
    }

    void LogInStatus(bool result)
    {
        if (result)
        {
            Debug.Log("Can log in");
        }
        else
            Debug.Log("Dont log in");
    }
}
