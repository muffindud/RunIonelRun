using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;

    [Range(0.0f, 5.0f)]
    public float moveSpeed = 1.0f;
    public SpriteRenderer sr;

    const float animationSpeed = 5.0f;

    public Sprite frontStaticSprite;
    public Sprite[] frontWalkSprites;
    public Sprite sideStaticSprite; // default is right
    public Sprite[] sideWalkSprites;

    Sprite GetSprite(Vector2 direction, bool isWalking)
    {
        sr.flipX = false;
        if (direction.x > 0)
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
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * moveSpeed;
        sr.sprite = GetSprite(direction, direction != Vector2.zero);
    }
}
