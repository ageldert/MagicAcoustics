using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeightViewState : State
{
    public HeightViewState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
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
        header.text = "HEIGHT: " + userControl.roomModel.dimensions.y.ToString(GLOBALS.format) + " ft\n" +
                        "TRIGGER: continue\n" +
                        "BUMPER: remeasure";
    }

    public override void OnStateExit()
    {

    }

    public override void OnTriggerUp()
    {
        // advance to analyses
        userControl.SetState(new ModeListState(userControl, header, columns));
    }

    public override void OnBumperUp()
    {
        userControl.SetState(new HeightState(userControl, header, columns));
    }

}