using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OptionsScreen()
    {
        SceneManager.LoadScene(2);
    }

   public void QuitGame()
    {
        Application.Quit();
    }

    public void MenuScreen()
    {
        SceneManager.LoadScene(1);
    }
}
