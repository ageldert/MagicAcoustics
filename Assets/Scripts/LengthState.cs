using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LengthState : State
{
    public LengthState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        // default constructor
    }

    public override void Tick()
    {
        // Update
        userControl.meshingControl.UpdateMeshMaterial();
        float l = userControl.roomModel.dimensions.z = userControl.HandleBeam() * GLOBALS.m2ft;
        header.text = "Select a surface normal to the room LENGTH\n" +
                        "LENGTH: " + l.ToString(GLOBALS.format) + " ft\n" +
                        "TRIGGER: select";
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = false;
        GLOBALS.isMeshing = false;
        GLOBALS.measureHeight = false;
        userControl.EnableBeam(true);
    }

    public override void OnStateExit()
    {

    }

    public override void OnTriggerUp()
    {
        userControl.EnableBeam(false);
        userControl.SetState(new LengthViewState(userControl, header, columns));
    }

    public override void OnBumperUp()
    {
        
    }

}
