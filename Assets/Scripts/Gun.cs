using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public float fireRate = 0.1f;
    public int damage = 10;

    private Camera mainCamera;
    private float nextFireTime = 0f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            Debug.Log("Hit " + hit.transform.name);
            if (hit.transform.GetComponent<Target>()) 
            {
                hit.transform.GetComponent<Target>().TakeDamage(damage);
                Debug.Log(hit.transform.GetComponent<Target>());
            }
            else
            {
                return;
            }
        }
    }
}
