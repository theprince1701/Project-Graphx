using System;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public bool CanLook { get; set; }
    
    [SerializeField] private Transform camTransform;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 cameraBaseOffset;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float lookSmooth;
    [SerializeField] private float maxLookAngleY;
    [SerializeField] private float maxLookAngleX;

    
    private Vector2 _lookRotation;
    private Quaternion _nativeRotation;

    private float _lookX;
    private float _lookY;
    
    private float _fov;
    private float _defaultFOV;

    public Camera Camera { get; private set; }

    public float RawLookX { get; private set; }
    public float RawLookY { get; private set; }


    private void Awake()
    {
        _lookRotation.x = playerTransform.eulerAngles.y;
        _lookRotation.y = camTransform.eulerAngles.y;

        _nativeRotation.eulerAngles = new Vector3(0f, _lookRotation.y, 0f);

        Camera = GetComponentInChildren<Camera>();
        _defaultFOV = Camera.fieldOfView;
        _fov = _defaultFOV;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CanLook = true;
    }

    private void Update()
    {
        _lookX = Input.GetAxis("Mouse X");
        _lookY = Input.GetAxis("Mouse Y");
    }

    private void LateUpdate()
    {
        if (!CanLook)
        {
            return;
        }
        
        UpdateCameraLook();
    }

    private void UpdateCameraLook()
    {
        float nextHorizontal = _lookX * Time.deltaTime * mouseSensitivity;
        float nextVertical = _lookY * Time.deltaTime * mouseSensitivity;

        RawLookX = nextHorizontal;
        RawLookY = nextVertical;
        
        _lookRotation.x += nextHorizontal;
        _lookRotation.y += nextVertical;
        
        _lookRotation.y = Mathf.Clamp(_lookRotation.y, -maxLookAngleY, maxLookAngleY);
        
        
        Quaternion camTargetRotation = _nativeRotation * Quaternion.AngleAxis(_lookRotation.y + (0), Vector3.left);
        Quaternion bodyTargetRotation = _nativeRotation * Quaternion.AngleAxis(_lookRotation.x + (0), Vector3.up);
        
        
        camTransform.localRotation =  Quaternion.Slerp(camTransform.localRotation, camTargetRotation, lookSmooth);
        playerTransform.localRotation = Quaternion.Slerp(playerTransform.localRotation, bodyTargetRotation, lookSmooth);
        Camera.fieldOfView = Mathf.Lerp(Camera.fieldOfView, _fov, Time.deltaTime * 5f);
    }
}
