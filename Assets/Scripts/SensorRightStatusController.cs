using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorRightStatusController : MonoBehaviour
{
    public GameObject car;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.StartsWith("SCut")) {
            car.GetComponent<WheelController>().hasRightLane += 1;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name.StartsWith("SCut")) {
            car.GetComponent<WheelController>().hasRightLane -= 1;
        }
    }
}
