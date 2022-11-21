using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Cached reference
    public Transform playerTransform;

    private Vector3 offset = new Vector3(0, 6.0f, -10.0f);

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + offset;
        }
    }
}
