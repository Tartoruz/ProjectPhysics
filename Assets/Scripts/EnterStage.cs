using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnterStage : MonoBehaviour
{
    [SerializeField] private CanvasGroup StageImage;
    [SerializeField] private TextMeshProUGUI StageNameTxt;
    public int StageNum;
    private float _fadeCountDown;
    private bool _isEnterStage;
    private bool _fadein;
    private bool _fadeout;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isEnterStage == true)
        {
            EnteringStage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isEnterStage = true;
            _fadein = true;
        }
    }

    private void EnteringStage()
    {
        if (StageNum == 0)
        {
            StageNameTxt.text = "<color=#1F6357> The Fallen </color>";
        }
        else if (StageNum == 1)
        {
            StageNameTxt.text = "<color=#C19A6B> Every Dream End Here </color>";
        }
        else if (StageNum == 2)
        {
            StageNameTxt.text = "<color=#0000A0> Inevitable Destination </color>";
        }
        else if (StageNum == 3)
        {
            StageNameTxt.text = "<color=#0C090A> The End ?... </color>";
        }
        
        if (StageImage.alpha < 1 && _fadein == true)
        {
            
            StageImage.alpha += Time.deltaTime * 0.5f;
            if (StageImage.alpha >= 1)
            {
                _fadeout = true;
            }
        }
        

        if (_fadeout == true)
        {
            _fadein = false;
            _fadeCountDown += Time.deltaTime;
            if (_fadeCountDown >= 3)
            {
                StageImage.alpha -= Time.deltaTime * 0.5f;
            }

        }

        if (StageImage.alpha <= 0 && _fadeout == true)
        {
            _fadeout = false;
            _fadeCountDown = 0;
            _isEnterStage = false;
            
        }
    }
}
