using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private float shootYOffset;

    [Space] 
    
    [SerializeField] private float swayAmount;
    [SerializeField] private float maxSway;
    [SerializeField] private float swaySmoothing;
    [SerializeField] private float positionMultiplier = 0.05f;

    [Space]
    
    [SerializeField] private Vector3 aimPos;
    [SerializeField] private float aimSpeed;
    [SerializeField] private Transform aimTransform;

    [Space] 
    
    [SerializeField] private TextMeshProUGUI ammoText;

    [SerializeField] private AnimationClip reloadClip;
    [SerializeField] private int maxMagSize = 6;
    [SerializeField] private int maxReserveAmmoSize = 500;

    private float _nextFire;

    private Quaternion _originalRotation;
    private Animator _animator;

    private ZombieControl _currentZombie;

    private Vector3 _defaultAimPos;
    private Vector3 _originalPosition;

    private int _currentAmmo;
    private int _currentReserveAmmo;

    private bool _canShoot;
    private bool _isReloading;
    

    private void Awake()
    {
        _originalRotation = transform.localRotation;
        _defaultAimPos = aimTransform.localPosition;
        _originalPosition = transform.localPosition;
        _animator = GetComponentInChildren<Animator>();

        _currentAmmo = maxMagSize;
        _currentReserveAmmo = maxReserveAmmoSize;
        _canShoot = true;
    }

    private void Update()
    {
        Sway();
        
        Fire();

        if (Physics.Raycast(Camera.main.transform.position + new Vector3(0, shootYOffset, 0), Camera.main.transform.forward, out RaycastHit hit, 1000f,
                shootLayer))
        {
            if (hit.collider.TryGetComponent(out ZombieControl zombie))
            {
                if (_currentZombie != null)
                {
                 //   _currentZombie.StopLook();
                    _currentZombie = null;
                }

                _currentZombie = zombie;
         //       _currentZombie.OnLook();
            }
            else
            {
                if (_currentZombie != null)
                {
              //      _currentZombie.StopLook();
                    _currentZombie = null;
                }
            }
        }
        else
        {
            if (_currentZombie != null)
            {
            //    _currentZombie.StopLook();
                _currentZombie = null;
            }
        }
        
        Aim();
        
        Reload();
    }

    void Reload()
    {
        ammoText.text = _currentAmmo + "/" + _currentReserveAmmo;
        bool reloadPressed = Input.GetKeyDown(KeyCode.R);

        if (reloadPressed && _currentAmmo < maxMagSize && !_isReloading)
        {
            StartCoroutine(IE_Reload());
        }
    }

    private IEnumerator IE_Reload()
    {
        _isReloading = true;
        _canShoot = false;
        _animator.SetTrigger("Reload");

        yield return new WaitForSeconds(reloadClip.length);

        int ammoNeeded = maxMagSize - _currentAmmo;

        _currentAmmo += ammoNeeded;
        _currentReserveAmmo -= ammoNeeded;
        
        _isReloading = false;
        _canShoot = true;
    }
    
    void Aim()
    {
        bool aimPressed = Input.GetMouseButton(1);

        Vector3 pos = aimPressed ? aimPos : _defaultAimPos;

        aimTransform.localPosition = Vector3.Lerp(aimTransform.localPosition, pos, Time.deltaTime * aimSpeed);
    }

    private void Fire()
    {
        bool firePressed = Input.GetMouseButtonDown(0);

        if (firePressed && Time.time > _nextFire && _currentAmmo > 0)
        {
            _nextFire = Time.time + fireRate;
            _currentAmmo--;
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(Camera.main.transform.position + new Vector3(0, shootYOffset, 0), Camera.main.transform.forward, out RaycastHit hit, 1000f,
                shootLayer))
        {
            if (hit.collider.TryGetComponent(out ZombieControl zombie))
            {
                zombie.Die();
            }
            
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
        
        transform.localRotation = Quaternion.Lerp(transform.localRotation,  _originalRotation * Quaternion.Euler(-y, x, x), Time.deltaTime * swaySmoothing);
        transform.localPosition = Vector3.Lerp(transform.localPosition, _originalPosition + new Vector3(x, 0) * positionMultiplier,
            Time.deltaTime * swaySmoothing);
    }
}
