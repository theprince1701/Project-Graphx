using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                _renderer.material = materials[i];
            }
        }
    }
}
