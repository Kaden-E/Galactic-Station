using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int startingHealth = 100;
    public GameObject explosionEffect; 
    public bool playExplosionEffect = true; 

    private int currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (playExplosionEffect)
        {
            
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion, 2f); // Destroy the explosion effect after 2 seconds
        }
        
        // Destroy the target object
        Destroy(gameObject);
    }
}