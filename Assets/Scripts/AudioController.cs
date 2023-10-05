using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    private bool hasStartedAudio2 = false;

    void Start()
    {
        audioSource1.Play();
        Debug.Log("Playing Intro.");
    }

    void Update()
    {
        if (!audioSource1.isPlaying && !hasStartedAudio2)
        {
            audioSource2.Play();
            hasStartedAudio2 = true;
            Debug.Log("Playing Main Loop.");
        }
    }
}
