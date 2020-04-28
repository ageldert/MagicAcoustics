using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class RoomDimState : State
{
    public RoomDimState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        myState = StateEnum.RoomDim;
    }

    public override void Tick()
    {
        if (timer >= Mathf.Epsilon)
            timer -= Time.deltaTime;
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = false;
        GLOBALS.isMeshing = false;
        GLOBALS.measuringDim = Dim.none;
        userControl.EnableBeam(false);

        header.text = "ROOM DIMENSIONS\n";

        columns[1].text = "Length: " + userControl.roomModel.dimensions.z.ToString(GLOBALS.format) + " ft\n" +
            "Width: " + userControl.roomModel.dimensions.x.ToString(GLOBALS.format) + " ft\n" +
            "Height: " + userControl.roomModel.dimensions.y.ToString(GLOBALS.format) + " ft\n";

        columns[1].text += "\nSurface Area: " + userControl.roomModel.surfaceArea.ToString("F1") + " ft²\n";
        columns[1].text += "Volume: " + userControl.roomModel.volume.ToString("F0") + " ft³\n";
        columns[1].text += "Mean Free Path: " + userControl.roomModel.meanFreePath.ToString(GLOBALS.format) + " ft\n";
        columns[3].text = "";
    }

    public override void OnStateExit()
    {
        GLOBALS.isMeshing = false;
        ClearText();
    }

    public override void OnTouchGesture()
    {
        if (timer >= Mathf.Epsilon)
            return;
        switch (controller.TouchpadGesture.Direction)
        {
            case MLInputControllerTouchpadGestureDirection.Left:
                userControl.SetState(new ModeInfoState(userControl, header, columns));
                break;
            case MLInputControllerTouchpadGestureDirection.Right:
                userControl.SetState(new ModeListState(userControl, header, columns));
                break;
        }
    }
}
