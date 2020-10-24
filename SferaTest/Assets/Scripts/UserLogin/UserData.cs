using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{

    public string user;
    public string password;
    public UserData(string userInput, string passwordInput)
    {
        user = userInput;
        password = passwordInput;
    }

    public UserData(UserData externalData)
    {
        user = externalData.user;
        password = externalData.password;
    }
    static public bool CanLogIn(UserData userData1, UserData userData2)
    {
        return string.Equals(userData1.user, userData2.user) && string.Equals(userData1.password, userData2.password);
    }
}
