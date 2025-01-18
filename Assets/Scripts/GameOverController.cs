using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameSelect()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game Select");
    }
}
