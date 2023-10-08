using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMS : MonoBehaviour
{
    [SerializeField] BoxCollider leftSensor;
    [SerializeField] BoxCollider rightSensor;

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject);
    }
}
