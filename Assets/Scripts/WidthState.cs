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
        GLOBALS.roomModel.dimensions.x = userControl.HandleBeam();
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = true;
        GLOBALS.isMeshing = false;
        GLOBALS.measureHeight = false;
        userControl.EnableBeam(true);
        header.text = "Select a surface normal to the room WIDTH\n" +
                        "WIDTH: " + GLOBALS.roomModel.dimensions.x.ToString(GLOBALS.format) + "m\n" +
                        "TRIGGER: select";
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnTriggerUp()
    {
        userControl.EnableBeam(false);
        userControl.SetState(new WidthViewState(userControl, header));
    }

    public override void OnBumperUp()
    {

    }

}