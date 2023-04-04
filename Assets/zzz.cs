using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zzz : MonoBehaviour
{
    public DepthOfField dof;

    private bool _isOn;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isOn = !_isOn;
        }

        dof.enabled = _isOn;
    }
}
