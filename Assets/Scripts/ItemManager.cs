using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private const int possibleKeyPositionsCount = 10;
    private readonly Vector2[] possibleKeyPositions = {
        new Vector2(-15f, 20f),
        new Vector2(-1f, 26.5f),
        new Vector2(6.5f, 28f),
        new Vector2(-13.5f, 10f),
        new Vector2(-12f, 6f),
        new Vector2(9f, 5.5f),
        new Vector2(7f, 0f),
        new Vector2(23f, 1.5f),
        new Vector2(-57f, -5f),
        new Vector2(35f, 1.5f)
    };

    [Range(1, possibleKeyPositionsCount)]
    public int keyCount = 3;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
