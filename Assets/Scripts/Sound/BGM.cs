using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource bgmSound; // ประกาศตัวแปร AudioSource สำหรับเล่น BGM

    void Start()
    {
        bgmSound = gameObject.AddComponent<AudioSource>();
        bgmSound.Play();
    }
}