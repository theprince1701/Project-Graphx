using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class DepthOfField : MonoBehaviour
{
    [SerializeField] private Shader depthOfFieldShader;

    [SerializeField, Range(0.1f, 100f)]
    private float focusDistance;

    [SerializeField, Range(0.1f, 1000f)] 
    private float focusRange = 3f;

    [SerializeField, Range(1f, 10f)] 
    private float bokehRadius;
    
    [NonSerialized] 
    private Material _dofMaterial;

    private const int _circleOfConfusionPass = 0;
    private const int _preFilterPass = 1;
    private const int _bokehPass = 2;
    private const int _postFilterPass = 3;
    private const int _postPass = 4;

    
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (_dofMaterial == null)
        {
            _dofMaterial = new Material(depthOfFieldShader);
            depthOfFieldShader.hideFlags = HideFlags.HideAndDontSave;
        }
        
        _dofMaterial.SetFloat("_FocusDistance", focusDistance);
        _dofMaterial.SetFloat("_BokehRadius", bokehRadius);
        _dofMaterial.SetFloat("_FocalRange", focusRange);

        RenderTexture coc = RenderTexture.GetTemporary(src.width, src.height, 0, RenderTextureFormat.RHalf,
            RenderTextureReadWrite.Linear);

        int width = src.width / 2;
        int height = src.height / 2;
        RenderTextureFormat format = src.format;

        RenderTexture dof0 = RenderTexture.GetTemporary(width, height, 0, format);
        RenderTexture dof1 = RenderTexture.GetTemporary(width, height, 0, format);
        
        Graphics.Blit(src, coc, _dofMaterial, _circleOfConfusionPass);
        Graphics.Blit(src, dof0, _dofMaterial, _preFilterPass);
        Graphics.Blit(src, dof0);
        
        Graphics.Blit(dof0, dof1, _dofMaterial, _bokehPass);
        Graphics.Blit(dof1, dof0, _dofMaterial, _postFilterPass);
        Graphics.Blit(dof0, dof1, _dofMaterial, _postPass);
        Graphics.Blit(dof1, dest);
        
        
        
        
        RenderTexture.ReleaseTemporary(coc);
    }
}
