using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class StandingWave : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private LineRenderer _wave;
    private const int linePoints = 128;
    private bool active;

    // animation params, set by another script
    public Dim waveDim { get; set; }
    public int currentOrder { get; set; }
    public float currentFreq { get; set; }
    public Vector3 pos1 { get; set; }
    public Vector3 pos2 { get; set; }

    private void Start()
    {
        _wave = GetComponent<LineRenderer>();
        _wave.enabled = false;
        _wave.positionCount = 128;
        currentOrder = 1;
    }

    private void Update()
    {
        if (active)
        {
            Animate();
        }
        
    }

    public void SetActive(bool b)
    {
        active = b;
        _wave.enabled = b;

    }

    public void Animate()
    {
        // changed the positions of the line renderer

    }

}
