using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField] private GameObject FallingBlockSpawbPoint;
    private Rigidbody rb;
    private float timeCountDown;
    private bool blockFall;
    private float blockDisappearTime;
    private bool isStepingOn = false;
    private bool _isReturn = true;
    
    Color lerpedColor = Color.white;
    Renderer renderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStepingOn == true)
        {
            BlockFallen();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isStepingOn = true;
        }
    }

    private void BlockFallen()
    {
        timeCountDown += Time.deltaTime;
        lerpedColor = Color.Lerp(Color.white, Color.black, timeCountDown / 8);
        renderer.material.color = lerpedColor;
        Debug.Log(timeCountDown);
        if (timeCountDown >= 8 && _isReturn == true)
        {
            Debug.Log("timeCountDown > 8");
            rb.isKinematic = false;
            rb.useGravity = true;
            blockDisappearTime += Time.deltaTime;
            

        }
        if (blockDisappearTime >= 3)
        {
            blockDisappearTime = 0;
            timeCountDown = 0;
            transform.position = FallingBlockSpawbPoint.transform.position;
            transform.rotation = FallingBlockSpawbPoint.transform.rotation;
            _isReturn = true;
            lerpedColor = Color.white;
            renderer.material.color = Color.white;
            rb.isKinematic = true;
            rb.useGravity = false;
            isStepingOn = false;
        }
    }

}
