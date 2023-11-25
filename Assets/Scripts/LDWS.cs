using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LDWS : MonoBehaviour
{
    public Image warningImage;
    public Sprite warningImageSprite;

    void Start()
    {
        HideWarning();
    }

    public void ShowWarning() {
        // warningImage.gameObject.SetActive(true);
        // Invoke("HideWarning", 1f);
        StartCoroutine(FlashWarning());
    }

    private IEnumerator FlashWarning()
    {
        // Show the warning image
        warningImage.gameObject.SetActive(true);

        // Flash the image for 1 seconds
        float duration = 1f;
        float flashInterval = 0.2f; // Adjust the interval as needed
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Toggle the visibility of the image
            warningImage.gameObject.SetActive(!warningImage.gameObject.activeSelf);

            // Wait for the specified interval
            yield return new WaitForSeconds(flashInterval);

            // Update the elapsed time
            elapsedTime += flashInterval;
        }

        // Ensure the image is hidden at the end
        HideWarning();
    }

    public void HideWarning() {
        warningImage.gameObject.SetActive(false);
    }
}
