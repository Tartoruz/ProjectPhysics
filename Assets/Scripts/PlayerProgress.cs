using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour
{
    private Transform player;
    private float playerAt;
    private float endHeight = 1920f;
    [SerializeField] private Slider slider;
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAt = player.position.y;
        slider.value = playerAt / endHeight;
    }
}
