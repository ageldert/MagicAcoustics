using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeightState : State
{
    public HeightState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        // default constructor
    }

    public override void Tick()
    {
        // Update
        userControl.meshingControl.UpdateMeshMaterial();
        float h = userControl.roomModel.dimensions.y = userControl.HandleBeam() * GLOBALS.m2ft;
        header.text = "Lastly, select a floor or ceiling normal to the room HEIGHT\n" +
                        "HEIGHT: " + h.ToString(GLOBALS.format) + " ft\n" +
                        "TRIGGER: select";
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = false;
        GLOBALS.isMeshing = false;
        GLOBALS.measureHeight = true;
        userControl.EnableBeam(true);
    }

public override void OnStateExit()
    {
        
    }

    public override void OnTriggerUp()
    {
        userControl.EnableBeam(false);
        userControl.SetState(new HeightViewState(userControl, header, columns));
    }

}
