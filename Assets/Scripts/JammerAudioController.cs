using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammerAudioController : MonoBehaviour
{
    public AudioSource jammerAudioSource;
    public AudioClip jammerMadeSit;
    public AudioClip jammerCaught;
    public AudioClip jammerEscape;   
    public AudioClip jammerStartRunning;
    public void PlaySound(AudioClip audioToPlay){
        jammerAudioSource.clip = audioToPlay;
        jammerAudioSource.Play();
    }
}
