using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class WelcomeState : State
{
    public WelcomeState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        myState = StateEnum.Welcome;
    }

    public override void Tick()
    {
        userControl.EnableBeam(false);
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = false;
        GLOBALS.isMeshing = false;
        GLOBALS.measuringDim = Dim.none;
        GLOBALS.measuringDim = Dim.none;
        userControl.EnableBeam(false);
        
        header.text = "Welcome to MagicAcoustics!";
        columns[1].text = "Begin by looking at your controller.\nThroughout the app, help will be displayed there.";
    }

    public override void OnStateExit()
    {
        GLOBALS.isMeshing = false;
        ClearText();
    }

    public override void OnTriggerUp()
    {
        userControl.SetState(new RoomScanState(userControl, header, columns));
    }
}
