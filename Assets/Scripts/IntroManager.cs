using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    private string currentScene;

    void Start()
    {
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying || Input.GetKeyDown(KeyCode.Space))
        {
            if (currentScene == "Intro 1 to easy")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Intro 2 to easy");
            }

            if (currentScene == "Intro 1 to hard")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Intro 2 to hard");
            }

            if (currentScene == "Intro 2 to easy")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
            }

            if (currentScene == "Intro 2 to hard")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelHard");
            }
        }
    }
}
