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
    BoxCollider2D exitCollider;

    const float animationSpeed = 7.5f;

    public Sprite frontStaticSprite;
    public Sprite[] frontWalkSprites;
    public Sprite sideStaticSprite; // default is right
    public Sprite[] sideWalkSprites;

    AudioSource audioSource;
    public AudioClip stepSound;


    public AudioClip keyPickupSound;
    public GameObject itemManager;
    public int keysHeld = 0;
    public int totalKeys;

    public GameObject doorManager;

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

    public void PickUpKey()
    {
        keysHeld++;
        audioSource.PlayOneShot(keyPickupSound, 0.5f);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = stepSound;
        totalKeys = itemManager.GetComponent<ItemManager>().keyCount;
        doorManager = GameObject.Find("Door");
        exitCollider = GameObject.Find("Exit").GetComponent<BoxCollider2D>();

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

        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        }

        // if close to the door
        if (Vector2.Distance(transform.position, doorManager.transform.position) < 1f) {
            if (Input.GetKey(KeyCode.F))
            {
                if (keysHeld == totalKeys)
                {
                    doorManager.GetComponent<DoorManager>().OpenDoor();
                }
            }
        }

        // touching the exit
        if (exitCollider.IsTouching(GetComponent<BoxCollider2D>()))
        {
            Debug.Log("Exit");
        }
    }
}
