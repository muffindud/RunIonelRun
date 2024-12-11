using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;

    [Range(0.0f, 2.0f)]
    public float moveSpeed = 1.0f;
    public SpriteRenderer sr;

    const float animationSpeed = 5.0f;

    public Sprite frontStaticSprite;
    public Sprite[] frontWalkSprites;
    public Sprite backStaticSprite;
    public Sprite[] backWalkSprites;
    public Sprite sideStaticSprite; // default is right
    public Sprite[] sideWalkSprites;

    Sprite getSprite(Vector2 direction, bool isWalking)
    {
        sr.flipX = false;
        if (direction.y > 0 && Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            return isWalking ? backWalkSprites[(int)(Time.time * animationSpeed) % backWalkSprites.Length] : backStaticSprite;
        }
        else if (direction.y < 0 && Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            return isWalking ? frontWalkSprites[(int)(Time.time * animationSpeed) % frontWalkSprites.Length] : frontStaticSprite;
        }
        else if (direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            return isWalking ? sideWalkSprites[(int)(Time.time * animationSpeed) % sideWalkSprites.Length] : sideStaticSprite;
        }
        else if (direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
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
        sr.sprite = getSprite(direction, direction != Vector2.zero);
    }
}
