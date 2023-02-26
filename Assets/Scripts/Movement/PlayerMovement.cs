using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private Transform spawnPoint;

    private Rigidbody _rigidbody;

    private Vector2 _movementDir;
    private bool _isSprinting;
    private bool _jump;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _movementDir = new Vector2(x, y);

        _isSprinting = Input.GetKey(KeyCode.LeftShift);
        _jump = Input.GetKeyDown(KeyCode.Space);
    }


    

    private void FixedUpdate()
    {
        Vector3 nextPos = transform.position +
                          (transform.forward * _movementDir.y + transform.right * _movementDir.x) * CalculateSpeed() *
                          Time.fixedDeltaTime;

        
        _rigidbody.MovePosition(nextPos);

        if (_jump)
        {
            _rigidbody.AddForce(jumpHeight * Vector3.up, ForceMode.Impulse);
            _jump = false;
        }
    }
    
    private float CalculateSpeed()
    {
        float speed = movementSpeed;

        if (_isSprinting)
        {
            speed = sprintSpeed;
        }

        return speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = spawnPoint.position;
    }
}
