using UnityEngine;
[ExecuteInEditMode]
public class DitherEffect : MonoBehaviour
{
    public Material ditherMat;
    public float ditherPower = 32.0f;
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        ditherMat.SetFloat("dPower", ditherPower);
        Graphics.Blit(src, dest, ditherMat);
    }
}
