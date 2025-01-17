using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < 1f)
        {
            player.GetComponent<PlayerControler>().keysHeld++;
            Destroy(gameObject);
        }
    }
}
