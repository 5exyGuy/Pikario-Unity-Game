using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMouseHandler : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
