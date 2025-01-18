using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    TextMeshPro textMesh;
    public GameObject player;

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        textMesh.text = player.GetComponent<PlayerControler>().keysHeld.ToString() + "/" + player.GetComponent<PlayerControler>().totalKeys.ToString();
    }
}
