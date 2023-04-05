using UnityEngine;


[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class ColorGrading : MonoBehaviour
{
    [SerializeField] private Material colorGradingMaterial;
    [SerializeField] private Texture2D[] luts;

    private int _index;
    
    public void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, colorGradingMaterial);
    }

    public void ToggleLUT()
    {
        _index++;
        _index %= luts.Length;
        
        colorGradingMaterial.SetTexture("_LUT", luts[_index]);
    }
}
