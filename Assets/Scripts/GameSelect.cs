using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelect : MonoBehaviour
{
    public void LoadEasy()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
    }

    public void LoadHard()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelHard");
    }
}
