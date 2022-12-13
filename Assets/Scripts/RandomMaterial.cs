using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial: MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material[] materials;

    private void OnEnable()
    {
        meshRenderer.material = materials[Random.Range(0, materials.Length)];
    }
}
