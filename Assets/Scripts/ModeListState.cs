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

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = false;
        GLOBALS.isMeshing = false;
        GLOBALS.measuringDim = Dim.none;
        userControl.EnableBeam(false);
        userControl.meshingControl.UpdateMeshMaterial();
        userControl.meshingControl.HideNormal();
        header.text = "MODAL RESONANCES - (L,W,H)\n";
        for(int i = 0; i < 3; i++)
        {
            columns[i].text = userControl.roomModel.DisplayAllModesAxial(i+1);
        }
    }

    public override void OnStateExit()
    {
        GLOBALS.isMeshing = false;
        header.text = "";
        columns[0].text = "";
        columns[1].text = "";
        columns[2].text = "";
    }

    public override void OnTouchGesture()
    {
        switch (controller.TouchpadGesture.Direction)
        {
            case MLInputControllerTouchpadGestureDirection.Left:
                userControl.SetState(new RoomDimState(userControl, header, columns));
                break;
            case MLInputControllerTouchpadGestureDirection.Right:
                userControl.SetState(new ModePlotState(userControl, header, columns));
                break;
        }
    }
}
