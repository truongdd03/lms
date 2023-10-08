using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorRightController : MonoBehaviour
{
    public GameObject car;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.StartsWith("SCut")) {
            car.GetComponent<WheelController>().lmsTurnAngle = -0.3f;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name.StartsWith("SCut") || car.GetComponent<WheelController>().lmsTurnAngle == 0) {
            car.GetComponent<WheelController>().lmsTurnAngle = 0;
        }
    }
}
