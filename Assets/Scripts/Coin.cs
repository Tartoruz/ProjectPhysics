using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    [SerializeField] private AudioClip coin;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.instance.IncreaseCoin(value);
            AudioSource.PlayClipAtPoint(coin,transform.position);
        }
    }
}
