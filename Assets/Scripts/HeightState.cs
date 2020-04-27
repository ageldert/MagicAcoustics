using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeightState : State
{
    public HeightState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        myState = StateEnum.Height;
    }

    public override void Tick()
    {
        // Update
        userControl.meshingControl.UpdateMeshMaterial();
        float h = userControl.roomModel.dimensions.y = userControl.HandleBeam() * GLOBALS.m2ft;
        header.text = "Lastly, select a floor or ceiling normal to the room HEIGHT\n" +
                        "Measured: " + h.ToString(GLOBALS.format) + " ft\n";
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = false;
        GLOBALS.isMeshing = false;
        GLOBALS.measuringDim = Dim.Height;
        userControl.EnableBeam(true);
    }

    public override void OnStateExit()
    {
        userControl.EnableBeam(false);
    }

    public override void OnTriggerUp()
    {
        userControl.SetState(new HeightViewState(userControl, header, columns));
    }

    public override void OnHomeUp()
    {
        userControl.SetState(new RoomScanState(userControl, header, columns));
    }

}
