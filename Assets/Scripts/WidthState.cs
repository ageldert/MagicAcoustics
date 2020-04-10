using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WidthState : State
{
    public WidthState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        // default constructor
    }

    public override void Tick()
    {
        // Update
        userControl.meshingControl.UpdateMeshMaterial(); userControl.meshingControl.UpdateMeshMaterial();
        float w = userControl.roomModel.dimensions.x = userControl.HandleBeam() * GLOBALS.m2ft;
        header.text = "Select a surface normal to the room WIDTH\n" +
                        "WIDTH: " + w.ToString(GLOBALS.format) + "ft\n" +
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
        userControl.SetState(new WidthViewState(userControl, header, columns));
    }

    public override void OnBumperUp()
    {

    }

}