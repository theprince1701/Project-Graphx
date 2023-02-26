using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject bulletTracer;
    [SerializeField] private float swayAmount;
    [SerializeField] private float maxSway;
    [SerializeField] private float swaySmoothing;

    private float _nextFire;

    private Quaternion _originalRotation;
    private Animator _animator;

    private void Awake()
    {
        _originalRotation = transform.localRotation;
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Shooting();
        
        Sway();
    }

    private void Sway()
    {
        float x = Input.GetAxis("Mouse X") * swayAmount;
        float y = Input.GetAxis("Mouse Y") * swayAmount;

        x = Mathf.Clamp(x, -maxSway, maxSway);
        y = Mathf.Clamp(y, -maxSway, maxSway);
        
        transform.localRotation = Quaternion.Slerp(transform.localRotation, _originalRotation * Quaternion.Euler(-y, 0, x), Time.deltaTime * swaySmoothing);
    }

    private void Shooting()
    {
        bool firePressed = Input.GetMouseButton(0);

        if (firePressed && Time.time > _nextFire)
        {
            _nextFire = Time.time + fireRate;
            Fire();
        }
    }

    private void Fire()
    {
        muzzleFlash.Play();
        _animator.SetTrigger("Fire");
    }
}
