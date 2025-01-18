using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

    public void LoadLevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
    }

    public void LoadLevelHard()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level Hard");
    }
}
