using System;
using System.Collections;
using System.Collections.Generic;
using OculusSampleFramework;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BotController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

	public InputActionProperty vehicleControlAction;

    public TextMeshProUGUI tmpro;

    public ToolBehaviour toolBehaviour;
    public ToolBehaviour weaponBehaviour;

    private float horizontalInput;
    private float verticalInput;
    private float currentbrakeForce;
    private float steeringAngle;
    private bool isBraking;
    private bool primaryButtonInput;
    private bool secondaryButtonInput;

    [SerializeField] private float motorForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    private void Start()
    {
        weaponBehaviour = GetComponentsInChildren<ToolBehaviour>()[0];
        toolBehaviour = GetComponentsInChildren<ToolBehaviour>()[1];
    }

    void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleWheelRotations();
        UpdateWheelVisuals();
        UseTool();
    }

    private void GetInput()
    {
        Vector2 xcInputVector = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if(xcInputVector.x == 0 && xcInputVector.y == 0)
            xcInputVector = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        
        //tmpro.text = $"x: {xcInputVector.x}\ny: {xcInputVector.y}";
        horizontalInput = Input.GetAxis(HORIZONTAL) + xcInputVector.x;
        verticalInput = -Input.GetAxis(VERTICAL) + -xcInputVector.y;
        
        primaryButtonInput = OVRInput.Get(OVRInput.RawButton.A);
        primaryButtonInput |= Input.GetKey(KeyCode.Space);
        
        secondaryButtonInput = OVRInput.Get(OVRInput.RawButton.B);
        secondaryButtonInput |= Input.GetKey(KeyCode.LeftControl);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        backLeftWheelCollider.motorTorque = verticalInput * motorForce;
        backRightWheelCollider.motorTorque = verticalInput * motorForce;

        currentbrakeForce = isBraking ? brakeForce : 0;
        if (isBraking)
        {
            ApplyBrakingForce();
        }
    }

    private void ApplyBrakingForce()
    {
        frontLeftWheelCollider.brakeTorque = currentbrakeForce;
        frontRightWheelCollider.brakeTorque = currentbrakeForce;
        backLeftWheelCollider.brakeTorque = currentbrakeForce;
        backRightWheelCollider.brakeTorque = currentbrakeForce;
    }

    private void HandleWheelRotations()
    {
        steeringAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steeringAngle;
        frontRightWheelCollider.steerAngle = steeringAngle;
    }

    private void UpdateWheelVisuals()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void UseTool()
    {
        if (primaryButtonInput) weaponBehaviour.ActuateTool();
        else weaponBehaviour.DisengageTool();
        if (secondaryButtonInput) toolBehaviour.ActuateTool();
        else toolBehaviour.DisengageTool();
    }
}
