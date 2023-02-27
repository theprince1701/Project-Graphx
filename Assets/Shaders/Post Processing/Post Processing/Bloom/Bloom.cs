using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class Bloom : MonoBehaviour
{
    [SerializeField] private Shader bloomShader;
    [SerializeField] private bool debug;

    [SerializeField, Range(0, 16)]
    private int iterations;

    [SerializeField, Range(0, 1)]
    private float threshold = 1;

    [SerializeField, Range(0, 10)]
    private float intensity = 1;


    private RenderTexture[] _textures = new RenderTexture[16];

    [NonSerialized] 
    private Material _bloom;

    private const int BoxDownPass = 0;
    private const int BoxUpPass = 1;
    private const int ApplyBloomPass = 2;
    private const int BoxDownFilterPass = 0;
    private const int DebugBloomPass = 3;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (_bloom == null)
        {
            _bloom = new Material(bloomShader);
            _bloom.hideFlags = HideFlags.HideAndDontSave;
        }

        _bloom.SetFloat("_Intensity", Mathf.GammaToLinearSpace(intensity));
        _bloom.SetFloat("_Threshold", 1-threshold);
        
        int width = src.width / 2;
        int height = src.height / 2;

        RenderTextureFormat format = src.format;
        RenderTexture currentDestination = _textures[0] = RenderTexture.GetTemporary(width, height, 0, format);
        
        Graphics.Blit(src, currentDestination, _bloom, BoxDownFilterPass);
        RenderTexture currentSource = currentDestination;

        int i = 1;
        for (; i < iterations; i++)
        {
            width /= 2;
            height /= 2;

            if (height < 2)
            {
                break;
            }

            currentDestination = _textures[i] = RenderTexture.GetTemporary(width, height, 0, format);
            Graphics.Blit(currentSource, currentDestination, _bloom, BoxDownPass);
        }

        for (i -= 2; i >= 0; i--)
        {
            currentDestination = _textures[i];
            _textures[i] = null;
            Graphics.Blit(currentSource, currentDestination, _bloom, BoxUpPass);
            RenderTexture.ReleaseTemporary(currentSource);
            currentSource = currentDestination;
        }
        
        _bloom.SetTexture("_SourceTex", currentSource);
        Graphics.Blit(currentSource, dest, _bloom, ApplyBloomPass);
        RenderTexture.ReleaseTemporary(currentSource);
    }
}
