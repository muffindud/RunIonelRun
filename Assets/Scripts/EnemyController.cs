using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;

    [Range(0.0f, 2.0f)]
    public float moveSpeed = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * moveSpeed;
    }
}
