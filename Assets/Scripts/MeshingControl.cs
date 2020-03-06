using System;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class MeshingControl : MonoBehaviour
{
    [SerializeField] private MLSpatialMapper mapper;
    [SerializeField] private Material visMaterial;
    [SerializeField] private Material invisMaterial;
    LineRenderer _meshNormal;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        _meshNormal = GetComponent<LineRenderer>();
        HideNormal();
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

    public void DisplayNormal(RaycastHit hit)
    {
        _meshNormal.SetPosition(0, hit.point);
        _meshNormal.SetPosition(1, hit.point + hit.normal * 0.4f);
        _meshNormal.enabled = true;
    }

    public void HideNormal()
    {
        _meshNormal.enabled = false;
    }

}
