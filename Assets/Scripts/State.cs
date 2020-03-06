using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class State
{
    protected UserControl userControl;
    protected Text header;
    //protected Text body;
    //protected Text footer;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public virtual void OnTriggerUp() { }
    public virtual void OnBumperUp() { }
    public virtual void OnHomeUp() { }

    public State(UserControl userControl, Text header)
    {
        this.userControl = userControl;
        this.header = header;
    }
}
