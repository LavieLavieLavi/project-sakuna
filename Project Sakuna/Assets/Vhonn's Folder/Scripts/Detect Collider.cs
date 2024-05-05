using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script detects the walls and puts them 
 * out of view by bringing them upwards*/

public class DetectCollider : MonoBehaviour
{
    // Speed of the movement
    public float moveSpeed = 2f;
    // Target y-position
    public float targetY;

    // This function is called when another collider enters the trigger zone of the static GameObject
    private IEnumerator OnTriggerEnter(Collider other)
    {
        // Check if the colliding GameObject has a specific tag or component to identify it
        if (other.CompareTag("Wall"))
        {
            // Get a reference to the Rigidbody component of the colliding GameObject
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Gradually move the GameObject up to the target y-position
                while (other.transform.position.y < targetY)
                {
                    // Calculate the new position based on the moveSpeed and deltaTime
                    float newY = Mathf.MoveTowards(other.transform.position.y, targetY, moveSpeed * Time.deltaTime);
                    // Update the position
                    other.transform.position = new Vector3(other.transform.position.x, newY, other.transform.position.z);
                    // Wait for the next frame
                    yield return null;
                }
            }
        }
    }

    // This function is called when another collider exits the trigger zone of the static GameObject
    private IEnumerator OnTriggerExit(Collider other)
    {
        // Get the new target y-position for when the GameObject exits the trigger zone
        float newTargetY = targetY - targetY + 1; // Example: Decrease y-position by 8 units

        // Check if the colliding GameObject has a specific tag or component to identify it
        if (other.CompareTag("Wall"))
        {
            // Get a reference to the Rigidbody component of the colliding GameObject
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Gradually move the GameObject down to the new target y-position
                while (other.transform.position.y > newTargetY)
                {
                    // Calculate the new position based on the moveSpeed and deltaTime
                    float newY = Mathf.MoveTowards(other.transform.position.y, newTargetY, moveSpeed * Time.deltaTime);
                    // Update the position
                    other.transform.position = new Vector3(other.transform.position.x, newY, other.transform.position.z);
                    // Wait for the next frame
                    yield return null;
                }
            }
        }
    }
}

