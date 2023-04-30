using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int maxHealth = 100;
    private int _currentHealth;


    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
    
    
}
