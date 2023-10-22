using UnityEngine;

[ExecuteInEditMode]
public class CustomDepthEffect : MonoBehaviour
{

    public Material precisionMat;
    [Range(1, 256)]
    public int colorDepth = 1;

    public bool colorDepthAdvanced = false;
    [Range(1, 256)]
    public int colorDepthAdvancedR = 1;
    [Range(1, 256)]
    public int colorDepthAdvancedG = 1;
    [Range(1, 256)]
    public int colorDepthAdvancedB = 1;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        precisionMat.SetInt("cDepth", colorDepth);
        precisionMat.SetInt("_AdvancedModeOn", colorDepthAdvanced ? 1 : 0);
        precisionMat.SetInt("advR", colorDepthAdvancedR);
        precisionMat.SetInt("advG", colorDepthAdvancedG);
        precisionMat.SetInt("advB", colorDepthAdvancedB);
        Graphics.Blit(src, dest, precisionMat);
    }
}