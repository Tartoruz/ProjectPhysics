using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HowToPlay : MonoBehaviour
{
    [SerializeField] private Image tutorialBg;
    public bool isTutorialClose = true;

    private EnterStage _enterStage;
    void Start()
    {
        _enterStage = GetComponent<EnterStage>();
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
            Debug.Log("Open");
            Time.timeScale = 0;
        }
        else if ( Input.GetKeyDown(KeyCode.Tab) && isTutorialClose == true)
        {
            tutorialBg.gameObject.SetActive(false);
            isTutorialClose = false;
            Debug.Log("Close");
            Time.timeScale = 1;
        }
    }
}
