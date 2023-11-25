using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorLeftWarning : MonoBehaviour
{
    public GameObject car;

    private void OnTriggerEnter(Collider other) {
        WheelController wheelController = car.GetComponent<WheelController>();
        LDWS lDWS = car.GetComponent<LDWS>();
        if (other.gameObject.name.StartsWith("Marker") && wheelController.IsInLane()) {
            lDWS.ShowWarning();
        }
    }
}
