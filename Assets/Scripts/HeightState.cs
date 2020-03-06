using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeightState : State
{
    public HeightState(UserControl userControl, Text header) : base(userControl, header)
    {
        // default constructor
    }

    public override void Tick()
    {
        // Update
        userControl.roomModel.dimensions.y = userControl.HandleBeam();
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = true;
        GLOBALS.isMeshing = false;
        GLOBALS.measureHeight = true;
        userControl.EnableBeam(true);
        header.text = "Lastly, select a floor or ceiling normal to the room HEIGHT\n" +
                        "HEIGHT: " + userControl.roomModel.dimensions.y.ToString(GLOBALS.format) + "m\n" +
                        "TRIGGER: select";
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnTriggerUp()
    {
        userControl.EnableBeam(false);
        userControl.SetState(new HeightViewState(userControl, header));
    }

}
