using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public float horizontalInput;
    public float verticalInput;
    public float currentSteerAngle;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField]private WheelCollider frontLeftCollider;
    [SerializeField]private WheelCollider frontRightCollider;
    [SerializeField]private WheelCollider rearLeftCollider;
    [SerializeField]private WheelCollider rearRightCollider;

    [SerializeField]private Transform frontLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform rearLeftTransform;
    [SerializeField] private Transform rearRightTransform;
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);            
    }

    private void HandleMotor()
    {
        frontLeftCollider.motorTorque = verticalInput * motorForce;
        frontRightCollider.motorTorque = verticalInput * motorForce;
      
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftCollider.steerAngle = currentSteerAngle;
        frontRightCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftCollider, frontLeftTransform);
        UpdateSingleWheel(frontRightCollider, frontRightTransform);
        UpdateSingleWheel(rearLeftCollider, rearLeftTransform);
        UpdateSingleWheel(rearRightCollider, rearRightTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
