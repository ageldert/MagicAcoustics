using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoomScanState : State
{
    public RoomScanState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        // default constructor
    }

    public override void Tick()
    {
        // Update
        userControl.meshingControl.UpdateMeshMaterial();
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = true;
        GLOBALS.isMeshing = true;
        GLOBALS.measuringDim = Dim.none;
        userControl.EnableBeam(false);
        header.text =   "BUMPER: pause/resume scanning\n" + 
                        "HOME: show/hide mesh\n" +
                        "TRIGGER: finish scan";
    }

    public override void OnStateExit()
    {
        GLOBALS.isMeshing = false;
    }

    public override void OnBumperUp()
    {
        GLOBALS.isMeshing = GLOBALS.isMeshing ? false : true;
    }

    public override void OnHomeUp()
    {
        // change materials
        GLOBALS.meshVisible = GLOBALS.meshVisible ? false : true;
    }

    public override void OnTriggerUp()
    {
        userControl.SetState(new LengthState(userControl, header, columns));
    }
}
