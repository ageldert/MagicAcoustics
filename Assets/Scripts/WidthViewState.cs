using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WidthViewState : State
{
    public WidthViewState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        myState = StateEnum.WidthView;
    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        GLOBALS.isMeshing = false;
        GLOBALS.measuringDim = Dim.none;
        userControl.EnableBeam(false);
        header.text = "WIDTH: " + userControl.roomModel.dimensions.x.ToString(GLOBALS.format) + " ft\n" +
                        "TRIGGER: continue\n" +
                        "BUMPER: remeasure";
    }

    public override void OnStateExit()
    {

    }

    public override void OnTriggerUp()
    {
        userControl.SetState(new HeightState(userControl, header, columns));
    }

    public override void OnBumperUp()
    {
        userControl.SetState(new WidthState(userControl, header, columns));
    }

    public override void OnHomeUp()
    {
        userControl.SetState(new RoomScanState(userControl, header, columns));
    }
}