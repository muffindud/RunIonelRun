using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
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
        sr = GetComponent<SpriteRenderer>();

        sr.sprite = frontStaticSprite;
    }

    void Update()
    {
        Vector2 direction = target.transform.position - transform.position;
        sr.sprite = GetSprite(direction, direction != Vector2.zero);
    }
}
