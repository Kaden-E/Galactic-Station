using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Speed at which the object moves forward
    public float speed = 5f;

    // Camera offset from the object
    public Vector3 cameraOffset = new Vector3(0f, 1.5f, -5f);

    // Reference to the camera object
    private Camera mainCamera;

    private void Start()
    {
        // Create a new camera as a child of the object
        GameObject cameraObj = new GameObject("MainCamera");
        mainCamera = cameraObj.AddComponent<Camera>();
        cameraObj.transform.SetParent(transform);
        cameraObj.transform.localPosition = cameraOffset;
        cameraObj.transform.rotation = Quaternion.LookRotation(transform.forward);
    }

    private void Update()
    {
        // Move the object forward based on the speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}