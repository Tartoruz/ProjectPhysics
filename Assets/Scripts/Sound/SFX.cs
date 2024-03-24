using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioClip jumpSound;
    private AudioSource jumpSource;

    public AudioClip chargingSound;
    private AudioSource chargingSource;
    private bool isChargingSoundPlaying = false;
    
    public AudioClip  ParachuteSound;
    private AudioSource  ParachuteSource;
    
    public AudioClip  CoinSound;
    private AudioSource  CoinSource;

    void Start()
    {
        jumpSource = gameObject.AddComponent<AudioSource>();
        jumpSource.clip = jumpSound;

        chargingSource = gameObject.AddComponent<AudioSource>();
        chargingSource.clip = chargingSound;
        chargingSource.loop = true;
        
        ParachuteSource = gameObject.AddComponent<AudioSource>();
        ParachuteSource.clip = ParachuteSound;
        
        CoinSource = gameObject.AddComponent<AudioSource>();
        CoinSource.clip = ParachuteSound;
        
    }

    public void PlayJumpSound()
    {
        jumpSource.Play();
    }

    public void PlayChargingSound()
    {
        chargingSource.Play();
        isChargingSoundPlaying = true;
    }

    public void StopChargingSound()
    {
        if (isChargingSoundPlaying && chargingSource.isPlaying)
        {
            chargingSource.Stop();
            isChargingSoundPlaying = false;
        }
    }
    
    public void PlayParachuteSound()
    {
        ParachuteSource.Play();
    }

    public void CoinCollect()
    {
        CoinSource.Play();
    }
}
