using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorLeftStatusController : MonoBehaviour
{
    public GameObject car;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.StartsWith("Marker")) {
            car.GetComponent<WheelController>().hasLeftLane += 1;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name.StartsWith("Marker")) {
            car.GetComponent<WheelController>().hasLeftLane -= 1;
        }
    }
}
