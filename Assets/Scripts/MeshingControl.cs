using System;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class MeshingControl : MonoBehaviour
{
    [SerializeField] private MLSpatialMapper mapper;
    [SerializeField] private Material visMaterial;
    [SerializeField] private Material invisMaterial;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        mapper.enabled = GLOBALS.isMeshing;
        if (mapper.enabled)
            UpdateMeshMaterial();
    }

    public void UpdateMeshMaterial()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            MeshRenderer meshRenderer = transform.GetChild(i).gameObject.GetComponent<MeshRenderer>();
            if (GLOBALS.meshVisible)
                meshRenderer.material = visMaterial;
            else
                meshRenderer.material = invisMaterial;
        }
    }

}
