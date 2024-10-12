using UnityEngine;

public class Hoverable : MonoBehaviour
{
    public Material highlight;
    public MeshRenderer meshRenderer;

    private readonly Material[] originalMaterials = new Material[1];
    private readonly Material[] highlightMaterials = new Material[2];
    private void Start()
    {
        originalMaterials[0] = meshRenderer.sharedMaterial;

        highlightMaterials[0] = meshRenderer.sharedMaterial;
        highlightMaterials[1] = highlight;
    }

    private void OnMouseEnter()
    {
        meshRenderer.sharedMaterials = highlightMaterials;
    }

    private void OnMouseExit()
    {
        meshRenderer.sharedMaterials = originalMaterials;
    }
}
