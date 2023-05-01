using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

public class PlayerHealth : MonoBehaviour
{
    private float _health;
    private float _lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

    void Start()
    {
        _health = maxHealth;
    }

    private void Update()
    {
        _health = Mathf.Clamp(_health, 0, maxHealth);
        UpdateHealthUI();
        if (Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(5);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            RestoreHealth(5);
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(_health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = _health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            _lerpTimer += Time.deltaTime;
            float percentComplete = _lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            _lerpTimer += Time.deltaTime;
            float percentComplete = _lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _lerpTimer = 0f;
    }

    public void RestoreHealth(float healAmount)
    {
        _health += healAmount;
        _lerpTimer = 0f;
    }
    
    
    
    
    
}
