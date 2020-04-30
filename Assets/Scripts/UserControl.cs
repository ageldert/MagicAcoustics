using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;

public class UserControl : MonoBehaviour
{
    [SerializeField] public MeshingControl meshingControl;
    [SerializeField] private Text header;
    [SerializeField] private List<Text> columns;
    [SerializeField] public GameObject plot;
    [SerializeField] public ModePlot modePlot;
    [SerializeField] public StandingWave standingWave;

    public RoomModel roomModel;
    public MLInputController _controller;

    private State currentState;
    private LineRenderer _controlBeam;
    private ControlHelp _controlHelp;

    private void Start()
    {
        if (!MLInput.IsStarted)
            MLInput.Start();
        MLInput.OnControllerButtonUp += OnButtonUp;
        MLInput.OnTriggerUp += OnTriggerUp;
        MLInput.OnControllerTouchpadGestureStart += OnTouchGesture;
        _controller = MLInput.GetController(MLInput.Hand.Left);
        _controlBeam = GetComponent<LineRenderer>();
        _controlHelp = GetComponent<ControlHelp>();
        plot.SetActive(false);
        EnableBeam(false);
        SetState(new WelcomeState(this, header, columns));
        roomModel = new RoomModel();
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
        _controlHelp.DisplayInstructions(currentState);

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
            RaycastHit normalHit = meshingControl.CalculateNormal(hit);
            measured = normalHit.distance;
            if(measured > Mathf.Epsilon)
            {
                // store the 2 positions into roomPoints
                switch (GLOBALS.measuringDim)
                {
                    case Dim.Length:
                        roomModel.roomPoints.len1 = hit.point;
                        roomModel.roomPoints.len2 = normalHit.point;
                        break;
                    case Dim.Width:
                        roomModel.roomPoints.wid1 = hit.point;
                        roomModel.roomPoints.wid2 = normalHit.point;
                        break;
                    case Dim.Height:
                        roomModel.roomPoints.hgt1 = hit.point;
                        roomModel.roomPoints.hgt2 = normalHit.point;
                        break;
                    default:
                        break;
                }
            }
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

    private void OnTouchGesture(byte controllerId, MLInputControllerTouchpadGesture touchpadGesture)
    {
        currentState.OnTouchGesture();
    }

    private void OnDisable()
    {
        MLInput.OnTriggerUp -= OnTriggerUp;
        MLInput.OnControllerButtonUp -= OnButtonUp;
        MLInput.Stop();
    }
}
