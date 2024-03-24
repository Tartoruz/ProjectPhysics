using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    private PlayerMM playerMm;
    [SerializeField] private GameObject parachutePrefab;
    private bool isParachute = false;
    private Rigidbody rb;
    private float airResistantY;
    void Start()
    {
        playerMm = GetComponent<PlayerMM>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerMm.grounded == false )
        {
            parachutePrefab.SetActive(!isParachute);
            playerMm.stopMove = !playerMm.stopMove;
        }
    }
}
