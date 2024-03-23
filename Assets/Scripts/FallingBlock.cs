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
    
    public Material mat;
    public Color startCol;
    public Color maxCol;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mat.color = Color.white;
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
        mat.color = Color.Lerp(startCol, maxCol, timeCountDown / 8);

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
