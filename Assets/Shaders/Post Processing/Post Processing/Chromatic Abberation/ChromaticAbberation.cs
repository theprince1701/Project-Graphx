using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class ChromaticAbberation : MonoBehaviour
{
    private const int DistortionPass = 0;


    [SerializeField] private Shader distortionShader;

    [SerializeField, Range(-1f, 1f)]
    private float distortion;
    
    [SerializeField, Range(0, 10f)]
    private float scale;


    private Material _distortionMaterial;


    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (_distortionMaterial == null)
        {
            _distortionMaterial = new Material(distortionShader);
            _distortionMaterial.hideFlags = HideFlags.HideAndDontSave;
        }
        
        _distortionMaterial.SetFloat("_Distortion", distortion);
        _distortionMaterial.SetFloat("_Scale", scale);
        
        Graphics.Blit(src, dest, _distortionMaterial, DistortionPass);
    }
}
