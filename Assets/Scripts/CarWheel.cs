using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheel : MonoBehaviour
{
    [SerializeField] private float maxAngle;
    [SerializeField] private float minAngle;

    [SerializeField] private WheelController wheelController;

    private WheelCollider wheelCollider;

    [SerializeField] private Transform wheelObj;

    private void Awake()
    {
        wheelCollider = GetComponent<WheelCollider>();
    }

    private void FixedUpdate()
    {
        wheelCollider.steerAngle = -wheelController.wheelRotation / 2;
    }
}
