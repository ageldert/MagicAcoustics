using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class UserControl : MonoBehaviour
{
    private MLInputController _controller;
    private LineRenderer _controlBeam;

    void Start()
    {
        if (!MLInput.IsStarted)
            MLInput.Start();
        _controller = MLInput.GetController(MLInput.Hand.Left);
        _controlBeam = GetComponent<LineRenderer>();
        MLInput.OnControllerButtonUp += OnButtonUp;
        MLInput.OnTriggerUp += OnTriggerUp;
    }

    void Update()
    {
        if (_controlBeam.enabled)
            HandleBeam();
    }

    private void HandleBeam()
    {
        Vector3 beamEnd;
        RaycastHit hit;
        float beamLength = 1f;
        if (Physics.Raycast(_controller.Position, _controller.Position + transform.forward, out hit, Mathf.Infinity))
        {
            beamLength = hit.distance;
        }
        beamEnd = _controller.Position + (transform.forward * beamLength);
        _controlBeam.SetPosition(0, _controller.Position);
        _controlBeam.SetPosition(1, beamEnd);
    }

    private void OnButtonUp(byte controllerId, MLInputControllerButton button)
    {
        if (button == MLInputControllerButton.Bumper)
        {
            // toggle meshing
            GLOBALS.isMeshing = GLOBALS.isMeshing ? false : true;
        }
        else if (button == MLInputControllerButton.HomeTap)
        {
            // change materials
            GLOBALS.meshVisible = GLOBALS.meshVisible ? false : true;
        }
    }

    private void OnTriggerUp(byte controllerId, float pressure)
    {
        // raycast to a mesh and show its normals
        _controlBeam.enabled = _controlBeam.enabled ? false : true;
    }

    private void OnDisable()
    {
        MLInput.OnTriggerUp -= OnTriggerUp;
        MLInput.OnControllerButtonUp -= OnButtonUp;
        MLInput.Stop();
    }
}
