using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(GetCurrentScene());
        Time.timeScale = 1;
    }

    public void QuitGameSession()
    {
        Debug.Log("EXIT GAME");
        Application.Quit();
    }
}
