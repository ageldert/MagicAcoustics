using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScanState : State
{
    public RoomScanState(UserControl userControl) : base(userControl)
    {
        // default constructor
    }

    public override void Tick()
    {
        // Update
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = true;
        GLOBALS.isMeshing = true;
        userControl.EnableBeam(false);
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
}
