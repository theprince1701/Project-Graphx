using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] private Bloom bloom;
    [SerializeField] private ColorGrading colorGrading;
    [SerializeField] private Light sun;


    private void Start()
    {
        Debug.Log(FindObjectsOfType<MaterialChanger>().Length);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            colorGrading.enabled = !colorGrading.enabled;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bloom.enabled = !bloom.enabled;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            colorGrading.ToggleLUT();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            sun.enabled = !sun.enabled;
        }
    }
}
