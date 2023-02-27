using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    
    private Renderer _renderer;

    public float CurrentHealth { get; set; }

    private PlayerManager _manager;

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void ApplyDamage(float amt = 20)
    {
        CurrentHealth -= amt;

        if (CurrentHealth <= 0)
        {
            
        }
    }
}
