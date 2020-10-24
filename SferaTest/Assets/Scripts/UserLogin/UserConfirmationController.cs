using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UserConfirmationController : MonoBehaviour
{
    [SerializeField] UserConfirmation user;

    [SerializeField] InputField userInput;
    [SerializeField] InputField passwordInput;
    [SerializeField] SceneLoader sceneLoader;

    [SerializeField] Text debuggText;
    // Start is called before the first frame update
    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
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
            sceneLoader.GoToScene(1);
        }
        else
            debuggText.text="Dont log in";
    }
}
