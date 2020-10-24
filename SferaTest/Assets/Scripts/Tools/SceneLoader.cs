using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneLoader : MonoBehaviour
{

    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void QuitMemorama()
    {
        Application.Quit();
    }
}
