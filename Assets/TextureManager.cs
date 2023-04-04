using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureManager : MonoBehaviour
{
    [SerializeField] private Texture2D defaultTexture;
    
    private Material _material;

    private bool _showingTexture;
}
