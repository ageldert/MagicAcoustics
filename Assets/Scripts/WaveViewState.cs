﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class WaveViewState : State
{
    
    public WaveViewState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        myState = StateEnum.WaveView;
    }

    public override void Tick()
    {
        if(timer >= Mathf.Epsilon)
            timer -= Time.deltaTime;
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = false;
        GLOBALS.isMeshing = false;
        GLOBALS.measuringDim = Dim.none;
        userControl.EnableBeam(false);

        userControl.standingWave.SetActive(true);
        userControl.standingWave.InitializeAnimation();
        DisplayHeaderWithOrder();
    }

    public override void OnStateExit()
    {
        userControl.standingWave.SetActive(false);
        ClearText();
    }

    public override void OnBumperUp()
    {
        // toggle pressure/velocity
        userControl.standingWave.ToggleVelocityPressure();
        DisplayHeaderWithOrder();
    }

    public override void OnTriggerUp()
    {
        // change view axis, update StandingWaveParams
        userControl.standingWave.ToggleDimension();
        DisplayHeaderWithOrder();
    }

    public override void OnTouchGesture()
    {
        if (timer >= Mathf.Epsilon)
            return;
        else timer = 0.5f;
        switch (controller.TouchpadGesture.Direction)
        {
            case MLInputControllerTouchpadGestureDirection.Left:
                userControl.SetState(new ModePlotState(userControl, header, columns));
                break;
            case MLInputControllerTouchpadGestureDirection.Right:
                userControl.SetState(new ModeInfoState(userControl, header, columns));
                break;
            case MLInputControllerTouchpadGestureDirection.Up:
                // higher order
                userControl.standingWave.IncrementOrder();
                DisplayHeaderWithOrder();
                break;
            case MLInputControllerTouchpadGestureDirection.Down:
                // lower order
                userControl.standingWave.DecrementOrder();
                DisplayHeaderWithOrder();
                break;
        }
    }

    private void DisplayHeaderWithOrder()
    {
        header.text = "AXIAL STANDING WAVE\n";
        if(userControl.standingWave.inVelocity)
            header.text += "Air Velocity\n";
        else
            header.text += "Air Pressure\n";
        Vector3Int order = userControl.standingWave.currentOrder;
        header.text += "(" + order.z + ", " + order.x + ", " + order.y + "): ";
        header.text += userControl.standingWave.freq.ToString("F1") + " Hz (x0.01 rate)";

    }
}
