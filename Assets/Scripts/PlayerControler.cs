using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;
    Vector2 moveInput;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveInput.Normalize();
        // var pos = transform.position;
        // pos.x += moveInput.x * moveSpeed * Time.deltaTime;
        // pos.y += moveInput.y * moveSpeed * Time.deltaTime;
        // transform.position = pos;
        rb.velocity = moveInput * moveSpeed;
    }
}
