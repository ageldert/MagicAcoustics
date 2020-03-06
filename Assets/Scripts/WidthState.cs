using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WidthState : State
{
    public WidthState(UserControl userControl, Text header) : base(userControl, header)
    {
        // default constructor
    }

    public override void Tick()
    {
        // Update
        userControl.HandleBeam();
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = true;
        GLOBALS.isMeshing = false;
        GLOBALS.measureHeight = false;
        userControl.EnableBeam(true);
        header.text = "Now, select a surface normal to the room WIDTH\n" +
                        "TRIGGER: select";
    }

    public override void OnStateExit()
    {
        GLOBALS.isMeshing = false;
    }

    public override void OnTriggerUp()
    {
        userControl.SetState(new HeightState(userControl, header));
    }
}