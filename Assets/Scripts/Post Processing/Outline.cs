using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class Outline : MonoBehaviour
{
    public Shader dofShader;

    [NonSerialized]
    Material dofMaterial;
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (dofMaterial == null)
        {
            dofMaterial = new Material(dofShader);
            dofMaterial.hideFlags = HideFlags.HideAndDontSave;
        }
        Graphics.Blit(source, destination, dofMaterial);
    }
}
