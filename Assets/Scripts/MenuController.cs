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
}
