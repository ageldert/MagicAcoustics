using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LengthState : State
{
    public LengthState(UserControl userControl, Text header) : base(userControl, header)
    {
        // default constructor
    }

    public override void Tick()
    {
        // Update
        GLOBALS.roomModel.dimensions.z = userControl.HandleBeam();
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = true;
        GLOBALS.isMeshing = false;
        GLOBALS.measureHeight = false;
        userControl.EnableBeam(true);
        header.text = "Select a surface normal to the room LENGTH\n" +
                        "LENGTH: " + GLOBALS.roomModel.dimensions.z.ToString(GLOBALS.format) + "m\n" +
                        "TRIGGER: select";
    }

    public override void OnStateExit()
    {

    }

    public override void OnTriggerUp()
    {
        userControl.EnableBeam(false);
        userControl.SetState(new LengthViewState(userControl, header));
    }

    public override void OnBumperUp()
    {
        
    }

}
