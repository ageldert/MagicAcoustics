using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class WaveViewState : State
{
    

    public WaveViewState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        // default constructor
    }

    public override void Tick()
    {
        // Update
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = false;
        GLOBALS.isMeshing = false;
        GLOBALS.measuringDim = Dim.none;
        userControl.EnableBeam(false);

        header.text = "VIEWING STANDING WAVE\n";
    }

    public override void OnStateExit()
    {
        header.text = "";
        columns[0].text = "";
        columns[1].text = "";
        columns[2].text = "";
    }

    public override void OnBumperUp()
    {
        // change view axis, update StandingWaveParams
        userControl.standingWave.waveDim--;
        if (userControl.standingWave.waveDim == Dim.none)
            userControl.standingWave.waveDim = Dim.Height;
        userControl.standingWave.currentOrder = 1;
        UpdateWaveFreq();
    }

    public override void OnTouchGesture()
    {
        switch (controller.TouchpadGesture.Direction)
        {
            case MLInputControllerTouchpadGestureDirection.Left:
                userControl.SetState(new ModePlotState(userControl, header, columns));
                break;
            case MLInputControllerTouchpadGestureDirection.Right:
                // next state
                break;
            case MLInputControllerTouchpadGestureDirection.Up:
                // higher order
                break;
            case MLInputControllerTouchpadGestureDirection.Down:
                // lower order
                break;
        }
    }

    private void UpdateWaveFreq()
    {



    }
}
