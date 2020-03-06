using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeListState : State
{
    public ModeListState(UserControl userControl, Text header) : base(userControl, header)
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
        userControl.roomModel.CalculateModes();

        header.text = "MODES:\n" +
                        userControl.roomModel.ModeDisplay(new Vector3Int(1, 0, 0)) + "\n" +
                        userControl.roomModel.ModeDisplay(new Vector3Int(0, 1, 0)) + "\n" +
                        userControl.roomModel.ModeDisplay(new Vector3Int(0, 0, 1));
    }

    public override void OnStateExit()
    {
        GLOBALS.isMeshing = false;
    }

    public override void OnTriggerUp()
    {
        //userControl.SetState(new HeightState(userControl, header));
    }

}
