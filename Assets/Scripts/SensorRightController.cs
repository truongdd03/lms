using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorRightController : MonoBehaviour
{
    public GameObject car;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.StartsWith("SCut")) {
            car.GetComponent<WheelController>().rightSensorTrigger += 1;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name.StartsWith("SCut")) {
            WheelController carController = car.GetComponent<WheelController>();
            carController.rightSensorTrigger = Mathf.Max(0, carController.rightSensorTrigger - 1);
        }
    }
}
