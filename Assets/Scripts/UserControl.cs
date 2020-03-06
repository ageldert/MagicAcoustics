using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class UserControl : MonoBehaviour
{
    private State currentState;
    public RoomModel roomModel;

    [SerializeField] private MeshingControl meshingControl;

    private MLInputController _controller;
    private LineRenderer _controlBeam;
    
    private void Start()
    {
        if (!MLInput.IsStarted)
            MLInput.Start();
        MLInput.OnControllerButtonUp += OnButtonUp;
        MLInput.OnTriggerUp += OnTriggerUp;

        _controller = MLInput.GetController(MLInput.Hand.Left);
        _controlBeam = GetComponent<LineRenderer>();

        SetState(new RoomScanState(this));
    }

    private void Update()
    {
        currentState.Tick();
        //if (_controlBeam.enabled)
        //    HandleBeam();
    }

    public void SetState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;

        if (currentState != null)
            currentState.OnStateEnter();
    }

    public void EnableBeam(bool enabled)
    {   _controlBeam.enabled = enabled; }

    public void HandleBeam()
    {
        float beamLength = 1f;
        Vector3 beamEnd = _controller.Position + (transform.forward * beamLength); ;
        if (Physics.Raycast(_controller.Position, _controller.Position + transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            beamEnd = hit.point;
            meshingControl.DisplayNormal(hit);
        }
        else
        {
            meshingControl.HideNormal();
        }
        _controlBeam.SetPosition(0, _controller.Position);
        _controlBeam.SetPosition(1, beamEnd);
    }

    private void OnButtonUp(byte controllerId, MLInputControllerButton button)
    {
        if (button == MLInputControllerButton.Bumper)
        {
            currentState.OnBumperUp();
        }
        else if (button == MLInputControllerButton.HomeTap)
        {
            currentState.OnHomeUp();
        }
        
    }

    private void OnTriggerUp(byte controllerId, float pressure)
    {
        currentState.OnTriggerUp();
    }

    private void OnDisable()
    {
        MLInput.OnTriggerUp -= OnTriggerUp;
        MLInput.OnControllerButtonUp -= OnButtonUp;
        MLInput.Stop();
    }
}
