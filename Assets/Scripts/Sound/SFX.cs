using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioClip jumpSFX;
    private AudioSource jumpSound;
    
    public AudioClip chargingSFX;
    private AudioSource chargingSound;
    private bool isChargingSoundPlaying = false;
    
    
    void Start()
    {
        jumpSound = gameObject.AddComponent<AudioSource>();
        jumpSound.clip = jumpSFX;
        
        chargingSound = gameObject.AddComponent<AudioSource>();
        chargingSound.clip = chargingSFX;
        chargingSound.loop = true;
    }
    
    public void PlayJumpSound()
    {
        jumpSound.Play();
    }
    
    public void PlaychargingSound()
    {
        chargingSound.Play();
        isChargingSoundPlaying = true;
    }
    
    public void StopchargingSound()
    {
        if (isChargingSoundPlaying && chargingSound.isPlaying)
        {
            chargingSound.Stop();
            isChargingSoundPlaying = false;
        }
    }
}
