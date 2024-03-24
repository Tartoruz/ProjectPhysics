using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager instance;

    private Vector3 _lastestCheckpointPosition;
    private int currentOder = -1;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetToCheckpoint(Transform targetTransform)
    {
        targetTransform.position = _lastestCheckpointPosition;
    }

    public void SaveCheckPoint(CheckPoint checkPoint)
    {
        if (checkPoint.CpInOder > currentOder)
        {
            _lastestCheckpointPosition = checkPoint.transform.position;
            currentOder = checkPoint.CpInOder;
        }
    }
}
