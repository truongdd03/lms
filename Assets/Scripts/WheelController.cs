using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] Rigidbody car;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider rearRight;
    [SerializeField] WheelCollider rearLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform rearRightTransform;
    [SerializeField] Transform rearLeftTransform;


    public float acceleration = 1000f;
    public float breakForce = 3000f;
    public float maxTurnAngle = 120f;
    public TMPro.TextMeshProUGUI speedText;
    public TMPro.TextMeshProUGUI lms;
    public float lmsTurnAngle = 0f;
    public int hasRightLane = 0;
    public int hasLeftLane = 0;
    public int leftSensorTrigger = 0;
    public int rightSensorTrigger = 0;

    private float currentAccerleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private void FixedUpdate() {
        currentAccerleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space)) {
            currentBreakForce = breakForce;
        } else {
            currentBreakForce = 0;
        }

        rearRight.motorTorque = currentAccerleration;
        rearLeft.motorTorque = currentAccerleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        rearRight.brakeTorque = currentBreakForce;
        rearLeft.brakeTorque = currentBreakForce;

        DisplayLMSStatus();
        UpdateTurnAngle();

        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(rearLeft, rearLeftTransform);
        UpdateWheel(rearRight, rearRightTransform);

        var vel = car.velocity;
        speedText.text = "Speed: " + Mathf.Round(vel.magnitude * 4.6f) + " mph";
    }

    void UpdateWheel(WheelCollider col, Transform trans) {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

    bool IsLMSActive() {
        return hasLeftLane > 0 && hasRightLane > 0;
    }

    void DisplayLMSStatus() {
        if (IsLMSActive()) {
            lms.text = "LMS: active";
            lms.color = Color.green;
        } else {
            lms.text = "LMS: inactive";
            lms.color = Color.grey;
        }
    }

    void UpdateTurnAngle() {
        float turnAngle = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) {
            // User's input should override lms
            lmsTurnAngle = 0;
            leftSensorTrigger = 0;
            rightSensorTrigger = 0;
        } else if (IsLMSActive() && (leftSensorTrigger > 0 || rightSensorTrigger > 0)) {
            if (rightSensorTrigger > 0) {
                turnAngle = -0.3f;
                lms.text = "LMS: <=====";
            } else {
                turnAngle = 0.3f;
                lms.text = "LMS: =====>";
            }
        }
        currentTurnAngle = maxTurnAngle * turnAngle;
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;
    }
}
