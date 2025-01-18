using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Sprite doorOpen;
    SpriteRenderer sr;
    BoxCollider2D bc;

    AudioSource audioSource;
    public AudioClip doorOpenSound;

    public void OpenDoor()
    {
        sr.sprite = doorOpen;
        bc.enabled = false;
        audioSource.PlayOneShot(doorOpenSound, 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
}
