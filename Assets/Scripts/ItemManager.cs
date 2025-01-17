using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private const int possibleKeyPositionsCount = 10;
    private readonly Vector2[] possibleKeyPositions = {
        new(-15f, 20f),
        new(-1f, 26.5f),
        new(6.5f, 28f),
        new(-13.5f, 10f),
        new(-12f, 6f),
        new(9f, 5.5f),
        new(7f, 0f),
        new(23f, 1.5f),
        new(-57f, -5f),
        new(35f, 1.5f)
    };

    [Range(1, possibleKeyPositionsCount)]
    public int keyCount = 3;

    List<Vector2> keyPositions = new();

    void Start()
    {
        for (int i = 0; i < keyCount; i++)
        {
            int randomIndex = Random.Range(0, possibleKeyPositionsCount);
            while (keyPositions.Contains(possibleKeyPositions[randomIndex]))
            {
                randomIndex = Random.Range(0, possibleKeyPositionsCount);
            }
            keyPositions.Add(possibleKeyPositions[randomIndex]);
        }

        GameObject keyPrefab = Resources.Load<GameObject>("Prefabs/Key");
        foreach (Vector2 position in keyPositions)
        {
            GameObject key = Instantiate(keyPrefab, position, Quaternion.identity);
            key.transform.SetParent(transform, worldPositionStays: false);
        }

        Destroy(this);
    }

    void Update()
    {
        
    }
}
