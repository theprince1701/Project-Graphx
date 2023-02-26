using UnityEngine;


[ExecuteInEditMode]
public class ColorGrading : MonoBehaviour
{
    [SerializeField] private Material colorGradingMaterial;
    
    public void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, colorGradingMaterial);
    }
}
