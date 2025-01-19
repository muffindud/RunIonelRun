using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameSelect()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game Select");
    }

    public void LoadSettings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Settings Menu");
    }

    public void LoadShop()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Shop Menu");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        }
    }
}
