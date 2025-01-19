using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelect : MonoBehaviour
{
    public void LoadEasy()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro 1 to easy");
    }

    public void LoadHard()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro 1 to hard");
    }
}
