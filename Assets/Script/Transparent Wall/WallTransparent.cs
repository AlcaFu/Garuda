using UnityEngine;

public class WallTransparent : MonoBehaviour
{
    private MeshRenderer wallMeshRenderer;
    private Material[] originalMaterial;
    [SerializeField] private Material transparentMaterial;
    public bool doFade = false;


    void Start()
    {
        wallMeshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = wallMeshRenderer.materials;
    }

    void Update()
    {
        if (doFade)
        {
            FadeNow();
        }
        else
        {
            ResetFade();
        }
    }

    private void FadeNow()
    {
        Material[] tempTransparentMaterial = new Material[originalMaterial.Length];
        for (int i = 0; i < originalMaterial.Length; i++)
        {
            tempTransparentMaterial[i] = transparentMaterial;
        }
        wallMeshRenderer.materials = tempTransparentMaterial;
    }

    private void ResetFade()
    {
        wallMeshRenderer.materials = originalMaterial;
    }
}
