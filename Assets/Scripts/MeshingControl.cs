using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class MeshingControl : MonoBehaviour
{
    [SerializeField] private MLSpatialMapper mapper;
    [SerializeField] private Material visMaterial;
    [SerializeField] private Material invisMaterial;
    private LineRenderer _meshNormal;

    void Start()
    {
        _meshNormal = GetComponent<LineRenderer>();
        HideNormal();
    }

    void Update()
    {
        mapper.enabled = GLOBALS.isMeshing;
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

    public float CalculateNormal(RaycastHit hit)
    {
        if (hit.collider.gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer target))
        {
            target.material = visMaterial;
        }

        Vector3 hitNormal = hit.normal;
        if (!GLOBALS.measureHeight)
            hitNormal.y = 0f;
        else
        {
            hitNormal.x = 0f;
            hitNormal.z = 0f;
        }

        if (Physics.Raycast(hit.point, hitNormal, out RaycastHit normalHit, 30f))
        {
            _meshNormal.SetPosition(0, hit.point);
            _meshNormal.SetPosition(1, normalHit.point);
            _meshNormal.enabled = true;
            return normalHit.distance;
        }
        else
        {
            _meshNormal.enabled = false;
            return 0.0f;
        }
    }

    public void HideNormal()
    {
        _meshNormal.enabled = false;
    }

}
