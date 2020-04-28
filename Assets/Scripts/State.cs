using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public abstract class State
{
    public StateEnum myState;
    protected float timer;
    protected UserControl userControl;
    protected Text header;
    protected List<Text> columns;
    protected MLInputController controller;
    //protected Text body;
    //protected Text footer;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public virtual void OnTriggerUp() { }
    public virtual void OnBumperUp() { }
    public virtual void OnHomeUp() { }
    public virtual void OnTouchGesture() { }

    public State(UserControl userControl, Text header, List<Text> columns = null)
    {
        this.userControl = userControl;
        this.header = header;
        this.columns = columns;
        controller = userControl._controller;
        timer = 0.5f;
    }

    public void ClearText()
    {
        header.text = "";
        columns[0].text = "";
        columns[1].text = "";
        columns[2].text = "";
        columns[3].text = "";
    }
}
