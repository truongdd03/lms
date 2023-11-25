using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI leftSignalText;
    public TMPro.TextMeshProUGUI rightSignalText;
    private string currentSignal = null;

    public void ToggleLeftSignal() {
        if (currentSignal == "l") {
            currentSignal = null;
        } else {
            currentSignal = "l";
        }
        DisplaySignal();
    }

    public void ToggleRightSignal() {
        if (currentSignal == "r") {
            currentSignal = null;
        } else {
            currentSignal = "r";
        }
        DisplaySignal();
    }

    public bool IsSignalOn() {
        return currentSignal != null;
    }

    private void DisplaySignal() {
        // Reset first
        leftSignalText.color = Color.white;
        rightSignalText.color = Color.white;

        if (currentSignal == "l") {
            leftSignalText.color = Color.green;
        } else if (currentSignal == "r") {
            rightSignalText.color = Color.green;
        }
    }
}
