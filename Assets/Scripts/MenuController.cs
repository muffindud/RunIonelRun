using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public void LoadLevel1()
    {
        Debug.Log("Loading Level 1");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
        gameObject.SetActive(false);
    }
}
