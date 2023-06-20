using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public static CarController instance;

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float maxHorizontalVal = 1;
    private float maxVerticalVal = 1;

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

    private void Awake()
    {
        instance = this;
    }


    private void FixedUpdate()
    {

        HandleMotor();
        HandleSteering();
        UpdateWheels();
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

    public void GoRight()
    {
        horizontalInput += 0.01f;
        if(horizontalInput>maxHorizontalVal)
        {
            horizontalInput = maxHorizontalVal;
        }
    }

    public void GoLeft()
    {
        horizontalInput -= 0.01f;
        if (horizontalInput < -maxHorizontalVal)
        {
            horizontalInput = -maxHorizontalVal;
        }
    }
    public void GoForward()
    {
        verticalInput += 0.01f;
        if (verticalInput > maxVerticalVal)
        {
            verticalInput = maxVerticalVal;
        }
    }

    public void GoBack()
    {
        verticalInput -= 0.01f;
        if (verticalInput < -maxVerticalVal)
        {
            verticalInput = -maxVerticalVal;
        }
    }

    public void ReturnRight()
    {
        if (horizontalInput == 0)
            return;
        else if (horizontalInput > 0)
        {
            horizontalInput -= 0.04f;
        }
        else
        {
            horizontalInput += 0.04f;
        }
    }

    public void ReturnForward()
    {
        if (verticalInput == 0)
            return;
        else if (verticalInput > 0)
        {
            verticalInput -= 0.04f;
        }
        else
        {
            verticalInput += 0.04f;
        }
    }

   

}
