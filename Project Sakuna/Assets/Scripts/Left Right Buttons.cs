using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LeftRightButtons : MonoBehaviour
{
    public GameObject model; // Reference to the model GameObject
    public float rotationAngle = 90f; // Set the rotation angle
    public float rotationDuration = 1.0f; // Set the duration of rotation

    public Button button1; // Reference to Button 1
    public Button button2; // Reference to Button 2

    private bool isRotating = false; // Flag to check if rotation is in progress

    // Method for handling the right button press
    public void OnRightButtonPress()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateSphereCoroutine(-rotationAngle));
        }
    }

    // Method for handling the left button press
    public void OnLeftButtonPress()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateSphereCoroutine(rotationAngle));
        }
    }

    // Coroutine to smoothly rotate the model
    private IEnumerator RotateSphereCoroutine(float angle)
    {
        isRotating = true;
        // Disable buttons while rotating
        button1.interactable = false;
        button2.interactable = false;

        Quaternion startRotation = model.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f) * startRotation;
        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            float t = elapsedTime / rotationDuration;
            model.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        model.transform.rotation = targetRotation;
        isRotating = false;
        // Re-enable buttons after rotation is complete
        button1.interactable = true;
        button2.interactable = true;
    }

    // Method for handling Button 1 press
    public void OnButton1Press()
    {
        Debug.Log("Button 1 pressed!");
    }

    // Method for handling Button 2 press
    public void OnButton2Press()
    {
        Debug.Log("Button 2 pressed!");
    }
}
