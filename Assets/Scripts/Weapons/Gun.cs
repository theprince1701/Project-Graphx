using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitImpact;
    [SerializeField] private GameObject bulletTracer;
    [SerializeField] private Transform barrel;
    [SerializeField] private LayerMask shootLayer;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletTracerSpeed;

    [Space] 
    
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
        Sway();
        
        Fire();
    }

    private void Fire()
    {
        bool firePressed = Input.GetMouseButtonDown(0);

        if (firePressed && Time.time > _nextFire)
        {
            _nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 1000f,
                shootLayer))
        {
            Destroy(Instantiate(hitImpact, hit.point, Quaternion.LookRotation(hit.normal)), 1.0f);
        }
        
        muzzleFlash.Play();
        _animator.SetTrigger("Fire");

        Rigidbody tracer = Instantiate(bulletTracer, barrel.position, barrel.rotation)
            .GetComponent<Rigidbody>();
        
        tracer.AddForce(Camera.main.transform.forward * bulletTracerSpeed, ForceMode.Impulse);
    }

    private void Sway()
    {
        float x = Input.GetAxis("Mouse X") * swayAmount;
        float y = Input.GetAxis("Mouse Y") * swayAmount;

        x = Mathf.Clamp(x, -maxSway, maxSway);
        y = Mathf.Clamp(y, -maxSway, maxSway);
        
        transform.localRotation = Quaternion.Lerp(transform.localRotation,  _originalRotation * Quaternion.Euler(-y, 0, x), Time.deltaTime * swaySmoothing);
    }
}
