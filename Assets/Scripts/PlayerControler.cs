using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
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
    public Sprite sideStaticSprite; // default is right
    public Sprite[] sideWalkSprites;

    AudioSource audioSource;
    public AudioClip stepSound;


    public GameObject itemManager;
    public int keysHeld = 0;
    private int totalKeys;

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
        else if (direction.y != 0) {
            return isWalking ? frontWalkSprites[(int)(Time.time * animationSpeed) % frontWalkSprites.Length] : frontStaticSprite;
        }

        return frontStaticSprite;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = stepSound;
        totalKeys = itemManager.GetComponent<ItemManager>().keyCount;

        sr.sprite = frontStaticSprite;
    }

    void Update()
    {
        bool isWalking = moveInput != Vector2.zero;
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveInput.Normalize();
        rb.velocity = moveInput * moveSpeed;
        sr.sprite = GetSprite(moveInput, isWalking);

        if (isWalking && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (Input.GetKey("escape"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        }
    }
}
