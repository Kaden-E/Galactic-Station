using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5.0f;
    public Color rayColor = Color.red;
    public float rayDistance = 100f;
    public float turretRange = 20f;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Check if the player is within range
        if (Vector3.Distance(transform.position, player.position) <= turretRange)
        {
            // Calculate the target rotation based on the player's position
            Vector3 targetPosition = player.position;
            targetPosition.y = transform.position.y;
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);

            // Clamp the rotation to the X axis only
            targetRotation = Quaternion.Euler(initialRotation.eulerAngles.x, targetRotation.eulerAngles.y, initialRotation.eulerAngles.z);

            // Smoothly rotate the turret towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Shoot a raycast in the direction the turret is facing
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
            {
                // Draw a debug line in the editor to show the raycast
                Debug.DrawLine(transform.position, hit.point, rayColor);
            }
            else
            {
                // If the raycast doesn't hit anything, draw a debug line at maximum distance
                Debug.DrawLine(transform.position, transform.position + transform.forward * rayDistance, rayColor);
            }
        }
        else
        {
            // If the player is out of range, swivel the turret
            transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, transform.rotation.eulerAngles.y + rotationSpeed * Time.deltaTime, initialRotation.eulerAngles.z);
        }
    }
}
