using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTableController : MonoBehaviour
{
    public ScreenCameraShader enabler;

    public MeshRenderer Tower;
    public Material tower1;
    public Material tower2;
    public Material tower3;
    public Material camera1;
    public Material camera2;
    public Material camera3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) 
        { 
            Tower.material= tower1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) 
        { 
            Tower.material= tower2;
        } 
        if(Input.GetKeyDown(KeyCode.Alpha3)) 
        { 
            Tower.material= tower3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)) 
        {
            enabler.enabled = !enabler.enabled; 
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)) 
        { 
            enabler.m_renderMaterial= camera1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)) 
        {
            enabler.m_renderMaterial = camera2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha7)) 
        {
            enabler.m_renderMaterial = camera3;
        }
    }
}
