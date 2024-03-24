using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text coinText;
    public int currentCoin;
    public int coinInMap;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinText.text = $"Coin : {currentCoin.ToString()} / {coinInMap.ToString()}";
    }

    public void IncreaseCoin(int v)
    {
        currentCoin += v;
        coinText.text = $"Coin : {currentCoin.ToString()} / {coinInMap.ToString()}";
    }
}
