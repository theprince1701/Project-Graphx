using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour {
    Rigidbody body;
    ControlScheme controls;
    [SerializeField] GameObject fpsCamera;

    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] Transform firingPoint;
    float bulletSpeed = 50.0f;
    bool firing = false;
    float shotDelay = 0.0f;
    
    float moveSpeed = 7.0f;
    float mouseSens = 0.1f;

    InputAction move, look, shoot;

    Vector2 moveDirection = Vector2.zero;
    Vector2 lookDirection = Vector2.zero;
    float lookVertical = 0;
    Transform facingAngle;

    void Awake(){
        controls = new ControlScheme();
        body = this.GetComponent<Rigidbody>();
        facingAngle = fpsCamera.transform;

        //Initialize inputs
        move = controls.Player.Move;
        move.Enable();
        look = controls.Player.Look;
        look.Enable();
        shoot = controls.Player.Shoot;
        shoot.Enable();

        shoot.started += ctx => firing = true;
        shoot.canceled += ctx => firing = false;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update(){
        moveDirection = move.ReadValue<Vector2>();
        lookDirection = look.ReadValue<Vector2>();
        if(firing){
            Shoot();
        }
    }
    void FixedUpdate(){
        Move();
        if(shotDelay > 0){
            shotDelay--;
            Mathf.Clamp(shotDelay, 0.0f, 50.0f);
        }
    }
    void LateUpdate(){
        Look();
    }

    void Move(){
        Vector3 movement = new Vector3(moveDirection.x, 0f, moveDirection.y);
        movement = facingAngle.forward * movement.z + facingAngle.right * movement.x;
        movement.y = 0;

        body.MovePosition(this.transform.position + (movement * moveSpeed) * Time.fixedDeltaTime);
    }

    void Look(){
        transform.Rotate(Vector3.up * lookDirection.x * mouseSens);

        lookVertical -= lookDirection.y * mouseSens;
        lookVertical = Mathf.Clamp(lookVertical, -90, 90);
        fpsCamera.transform.eulerAngles = new Vector3(lookVertical, fpsCamera.transform.eulerAngles.y, fpsCamera.transform.eulerAngles.z);
    }

    void Shoot(){
        if(shotDelay == 0.0f){
            GameObject spawnedBullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);

            spawnedBullet.GetComponent<Rigidbody>().AddForce(spawnedBullet.transform.forward * bulletSpeed, ForceMode.Impulse);
            shotDelay = 50.0f;
        }
    }

    void OnCollisionEnter(Collision thing){
        if(thing.gameObject.layer == LayerMask.NameToLayer("Ground")){
            transform.position = (new Vector3(0f, 11.5f, 0f));
        }
    }
}