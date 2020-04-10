using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class ModeListState : State
{
    public ModeListState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        // default constructor
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

                break;
            case MLInputControllerTouchpadGestureDirection.Right:

                break;
        }
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = false;
        GLOBALS.isMeshing = false;
        GLOBALS.measureHeight = false;
        userControl.EnableBeam(false);
        userControl.roomModel.CalcModes();

        header.text = "MODAL RESONANCES - (L,W,H)\n";
        for(int i = 0; i < 3; i++)
        {
            columns[i].text = userControl.roomModel.DisplayAllModesAxial(i+1);
        }
    }

    public override void OnStateExit()
    {
        GLOBALS.isMeshing = false;
    }

    public override void OnTriggerUp()
    {
        //userControl.SetState(new HeightState(userControl, header));
    }

}
