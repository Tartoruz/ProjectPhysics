using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HowToPlay : MonoBehaviour
{
    [SerializeField] private Image tutorialBg;
    [SerializeField] private Slider playerProgress;
    public bool isTutorialClose = true;

    private EnterStage _enterStage;
    void Start()
    {
        _enterStage = GetComponent<EnterStage>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        OpenClose();
    }

    private void OpenClose()
    {
        if ( Input.GetKeyDown(KeyCode.Tab) && isTutorialClose == false)
        {
            tutorialBg.gameObject.SetActive(true);
            isTutorialClose = true;
            playerProgress.gameObject.SetActive(false);
            Debug.Log("Open");
            Time.timeScale = 0;
        }
        else if ( Input.GetKeyDown(KeyCode.Tab) && isTutorialClose == true)
        {
            tutorialBg.gameObject.SetActive(false);
            playerProgress.gameObject.SetActive(true);
            isTutorialClose = false;
            Debug.Log("Close");
            Time.timeScale = 1;
        }
    }
}
