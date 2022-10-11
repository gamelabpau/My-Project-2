using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int moveSpeed = 50;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            // Move forward
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Move backwards
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        
        if (Input.GetKey(KeyCode.A) == true)
        {
            // Move left
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Move right
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        float rotationAngle = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotationAngle, 0);
    }
}
