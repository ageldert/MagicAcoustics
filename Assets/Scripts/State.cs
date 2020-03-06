using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected UserControl userControl;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public virtual void OnTriggerUp() { }
    public virtual void OnBumperUp() { }
    public virtual void OnHomeUp() { }

    public State(UserControl userControl)
    {
        this.userControl = userControl;
    }
}
