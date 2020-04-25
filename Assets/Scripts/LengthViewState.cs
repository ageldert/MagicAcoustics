using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LengthViewState : State
{
    public LengthViewState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        // default constructor
    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        GLOBALS.isMeshing = false;
        GLOBALS.measureHeight = false;
        userControl.EnableBeam(false);
        header.text = "LENGTH: " + userControl.roomModel.dimensions.z.ToString(GLOBALS.format) + " ft\n" +
                        "TRIGGER: continue\n" +
                        "BUMPER: remeasure";
    }

    public override void OnStateExit()
    {

    }

    public override void OnTriggerUp()
    {
        userControl.SetState(new WidthState(userControl, header, columns));
    }

    public override void OnBumperUp()
    {
        userControl.SetState(new LengthState(userControl, header, columns));
    }

}