using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip alarm;
    public AudioClip bonk;
    public AudioClip sadge;
    public AudioClip defeat;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = alarm;
        audioSource.volume = 0.05f;
        audioSource.Play();
    }

    void Update()
    {
        if(audioSource.clip == alarm && audioSource.time >= 2)
        {
            audioSource.clip = bonk;
            audioSource.volume = 1f;
            audioSource.Play();
        }
        if (!audioSource.isPlaying || Input.GetKeyDown(KeyCode.Space))
        {
            if(audioSource.clip == alarm)
            {
                audioSource.clip = bonk;
                audioSource.volume = 1f;
                audioSource.Play();
            }
            else if(audioSource.clip == bonk)
            {
                audioSource.clip = sadge;
                audioSource.Play();
            }
            else if(audioSource.clip == sadge)
            {
                audioSource.clip = defeat;
                audioSource.volume = 0.1f;
                audioSource.Play();
            }
            else if(audioSource.clip == defeat)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game Won");
            }
        }
    }
}
