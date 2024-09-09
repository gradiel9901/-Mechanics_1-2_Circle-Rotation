using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45f;
    [SerializeField] private Transform rotateAround;

    private bool rotateClockwise = true;
    private bool gameStarted = false;

    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameStarted = true;
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotateClockwise = !rotateClockwise;
        }

        if (rotateClockwise)
        {
            this.transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.RotateAround(rotateAround.position, Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
    }
}
