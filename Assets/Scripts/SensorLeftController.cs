using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorLeftController : MonoBehaviour
{
    public GameObject car;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.StartsWith("Marker")) {
            car.GetComponent<WheelController>().leftSensorTrigger += 1;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name.StartsWith("Marker")) {
            WheelController carController = car.GetComponent<WheelController>();
            carController.leftSensorTrigger = Mathf.Max(0, carController.leftSensorTrigger - 1);        }
    }
}
