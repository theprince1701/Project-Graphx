using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float _xInput;
    public float _yInput;

    public float _xRotation;
    public float _yRotation;

    public Transform _currentOrientation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible= false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _xInput;   
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _yInput;

        _yRotation += mouseX;
        _xRotation -= mouseY;    

        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _currentOrientation.rotation = Quaternion.Euler(0, _yRotation, 0);    
    }
}
