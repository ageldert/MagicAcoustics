using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class ModePlotState : State
{
    private ModePlot modePlot;

    public ModePlotState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        modePlot = new ModePlot();
    }

    public override void Tick()
    {
        // Update

    }
    public override void OnTouchGesture()
    {
        switch (controller.TouchpadGesture.Direction)
        {
            case MLInputControllerTouchpadGestureDirection.Left:
                userControl.SetState(new ModeListState(userControl, header, columns));
                break;
            case MLInputControllerTouchpadGestureDirection.Right:
                // anything else?
                break;
        }
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = false;
        GLOBALS.isMeshing = false;
        GLOBALS.measureHeight = false;
        userControl.EnableBeam(false);
        userControl.plot.SetActive(true);

        modePlot.Initialize();

        // plot all modes
        foreach(Mode m in userControl.roomModel.modeList)
        {
            modePlot.PlotMode(m);
        }
    }

    public override void OnStateExit()
    {
        GLOBALS.isMeshing = false;
        userControl.plot.SetActive(false);
    }

    public override void OnTriggerUp()
    {
        
    }

}
