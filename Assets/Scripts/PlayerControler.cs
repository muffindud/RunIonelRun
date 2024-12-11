using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;
    Vector2 moveInput;
    Rigidbody2D rb;
    SpriteRenderer sr;

    const float animationSpeed = 7.5f;

    public Sprite frontStaticSprite;
    public Sprite[] frontWalkSprites;
    public Sprite backStaticSprite;
    public Sprite[] backWalkSprites;
    public Sprite sideStaticSprite; // default is right
    public Sprite[] sideWalkSprites;

    Sprite getSprite(Vector2 direction, bool isWalking)
    {
        sr.flipX = false;
        if (direction.y > 0)
        {
            return isWalking ? backWalkSprites[(int)(Time.time * animationSpeed) % backWalkSprites.Length] : backStaticSprite;
        }
        else if (direction.y < 0)
        {
            return isWalking ? frontWalkSprites[(int)(Time.time * animationSpeed) % frontWalkSprites.Length] : frontStaticSprite;
        }
        else if (direction.x > 0)
        {
            return isWalking ? sideWalkSprites[(int)(Time.time * animationSpeed) % sideWalkSprites.Length] : sideStaticSprite;
        }
        else if (direction.x < 0)
        {
            sr.flipX = true;
            return isWalking ? sideWalkSprites[(int)(Time.time * animationSpeed) % sideWalkSprites.Length] : sideStaticSprite;
        }

        return frontStaticSprite;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        sr.sprite = frontStaticSprite;
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveInput.Normalize();
        rb.velocity = moveInput * moveSpeed;
        sr.sprite = getSprite(moveInput, moveInput.magnitude > 0);
    }
}
