using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip[] stepSounds_AR;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Step_sound_play()
    {
        audioSource.PlayOneShot(stepSounds_AR[Random.Range(0,stepSounds_AR.Length)]);
        print ("step_1");
        print ("step_2");
    }
}
