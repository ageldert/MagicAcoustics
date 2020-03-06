using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;

public class UserControl : MonoBehaviour
{
    private State currentState;

    [SerializeField] public MeshingControl meshingControl;
    [SerializeField] private Text header;

    private MLInputController _controller;
    private LineRenderer _controlBeam;

    public RoomModel roomModel;
    
    private void Start()
    {
        if (!MLInput.IsStarted)
            MLInput.Start();
        MLInput.OnControllerButtonUp += OnButtonUp;
        MLInput.OnTriggerUp += OnTriggerUp;

        _controller = MLInput.GetController(MLInput.Hand.Left);
        _controlBeam = GetComponent<LineRenderer>();

        SetState(new RoomScanState(this, header));
    }

    private void Update()
    {
        currentState.Tick();
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

    public float HandleBeam()
    {
        float measured = 0.0f;
        if (Physics.Raycast(_controller.Position, transform.forward, out RaycastHit hit, 30f))
        {
            _controlBeam.SetPosition(0, _controller.Position);
            _controlBeam.SetPosition(1, hit.point);
            measured = meshingControl.CalculateNormal(hit);
        }
        else
        {
            meshingControl.HideNormal();
        }
        return measured;
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
