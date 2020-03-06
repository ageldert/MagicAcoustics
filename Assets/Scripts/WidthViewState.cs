using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WidthViewState : State
{
    public WidthViewState(UserControl userControl, Text header) : base(userControl, header)
    {
        // default constructor
    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = true;
        GLOBALS.isMeshing = false;
        GLOBALS.measureHeight = false;
        userControl.EnableBeam(false);
        header.text = "WIDTH: " + userControl.roomModel.dimensions.x.ToString(GLOBALS.format) + "m\n" +
                        "TRIGGER: continue\n" +
                        "BUMPER: remeasure";
    }

    public override void OnStateExit()
    {

    }

    public override void OnTriggerUp()
    {
        userControl.SetState(new HeightState(userControl, header));
    }

    public override void OnBumperUp()
    {
        userControl.SetState(new WidthState(userControl, header));
    }

}