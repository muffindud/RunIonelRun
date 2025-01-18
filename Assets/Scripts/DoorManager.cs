using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Sprite doorOpen;
    SpriteRenderer sr;
    BoxCollider2D bc;

    public void OpenDoor()
    {
        sr.sprite = doorOpen;
        bc.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }
}
