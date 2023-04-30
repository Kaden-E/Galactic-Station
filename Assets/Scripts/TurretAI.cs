using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5.0f;
    public Color rayColor = Color.red;
    public float rayDistance = 100f;
    public float turretRange = 20f;
    public float fireRate = 3f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public Transform shootPoint;

    private Quaternion initialRotation;
    private float nextFireTime = 0f;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= turretRange)
        {
            Vector3 targetPosition = player.position;
            targetPosition.y = transform.position.y;
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            targetRotation = Quaternion.Euler(initialRotation.eulerAngles.x, targetRotation.eulerAngles.y, initialRotation.eulerAngles.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            if (Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + fireRate;
                GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, transform.rotation.eulerAngles.y + rotationSpeed * Time.deltaTime, initialRotation.eulerAngles.z);
        }
    }
}