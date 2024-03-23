using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    private Rigidbody rb;
    private float timeCountDown;
    private bool blockFall;
    private float blockDisappearTime;
    private bool isStepingOn = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        if (timeCountDown >= 8)
        {
            blockFall = true;
            rb.isKinematic = false;
            if (blockFall)
            {
                rb.useGravity = true;
                blockDisappearTime += Time.deltaTime;
            }

        }
        if (blockDisappearTime >= 3)
        {
            Destroy(gameObject);
        }
    }

}
