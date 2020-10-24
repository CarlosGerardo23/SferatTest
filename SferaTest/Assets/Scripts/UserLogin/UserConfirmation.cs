using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
[CreateAssetMenu(menuName = "User Confirmation")]
public class UserConfirmation : ScriptableObject
{

    public delegate void ConfirmUserData(bool canLogIn);


    UserData userInput;
    const string url = "https://raw.githubusercontent.com/Chezzar/PruebaUnityLogin/master/LoginUser";

   public void SetUserInput(string user, string password)
    {
        userInput = new UserData(user, password);
    }
    public IEnumerator CheckUserData(ConfirmUserData confirmData = null)
    {
        
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            string userJson = webRequest.downloadHandler.text;
            string userJson2 = JsonUtility.ToJson(userInput);

            UserData userWebData =new UserData( JsonUtility.FromJson<UserData>(userJson));

            confirmData(UserData.CanLogIn(userInput, userWebData));
        }
    }
}
