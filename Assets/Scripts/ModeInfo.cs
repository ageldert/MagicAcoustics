using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class ModeInfoState : State
{
    public ModeInfo currentInfo;
    private string[] headerTexts;
    private string[] bodyTexts;
    private string infoHeader = "What Are Room Modes?";

    private string infoText = "\tRoom modes are the most important acoustical characteristic of any enclosed room. " +
            "Each mode is a resonant standing wave formed from reflections between the surfaces in the room. " +
            "These standing waves can cause massive changes in the room response at that frequency. " +
            "Acoustical energy will especially accumulate near the corners and walls of the room. " +
            "\n\nModes are characterized by their order (L, W, H), which represents the number of pressure nodes in the wave formed " +
            "along each room dimension, and are also classified as:" +
            "\n\nAxial: mode along a single dimension ex. (0, 2, 0)" +
            "\nTangential: mode along two dimensions ex. (0, 2, 1)" +
            "\nOblique: mode along three dimensions ex. (1, 2, 1)";

    private string effectsHeader = "What Are the Effects of Modes?";

    private string effectsText = "\tAt a given location, frequencies whose modes have a pressure antinode will be amplified, and 'ring' " +
        "with a longer reverberation time. This 'ringing' modal resonance may be imperceptible if other modes are densely spaced near the amplified frequency, " +
        "but a room with widely spaced and prominent modes will create extreme frequency response variations at different locations in the room. " +
        "\n\nIf parallel surfaces are also very reflective, flutter echo may occur. This is an undesirable phenomenon where reflections " +
        "very audibly ring out in time. Compared to low frequency modes, mid and high frequency flutter echos are easily perceived and treated." +
        "\n\nThe placement of loudspeakers or other sound sources will also create excitation of certain modes. A subwoofer intending to " +
        "excite low frequency modes will benefit from placement in a corner, whereas a reference monitor should be distanced from walls.";

    private string treatmentHeader = "How Can Modes Be Treated?";

    private string treatmentText = "Architectural design considerations can lessen the adverse effects of room modes by:" +
        "\n\t- Proportioning room dimensions" +
        "\n\t- Splaying (canting) parallel walls" +
        "\n\t- Increasing room dimensions" +
        "\n\nAcoustical treatments can also be employed, such as:" +
        "\n\t- Tuned resonators or bass traps" +
        "\n\t- Large absorbers or diffusers (ex. furniture)" +
        "\n\nAdditionally:" +
        "\n\t- Loudspeakers and listening positions should avoid high energy regions" +
        "\n\t- Loudspeaker EQ cannot improve the entire room response" +
        "\n\t- Room response measurement should inform treatment decisions";

    public ModeInfoState(UserControl userControl, Text header, List<Text> columns) : base(userControl, header, columns)
    {
        myState = StateEnum.RoomDim;
    }

    public override void Tick()
    {
        if (timer >= Mathf.Epsilon)
            timer -= Time.deltaTime;
    }

    public override void OnStateEnter()
    {
        GLOBALS.meshVisible = false;
        GLOBALS.isMeshing = false;
        GLOBALS.measuringDim = Dim.none;
        userControl.EnableBeam(false);
        currentInfo = ModeInfo.Info;

        headerTexts = new string[3];
        bodyTexts = new string[3];

        headerTexts[0] = infoHeader;
        headerTexts[1] = effectsHeader;
        headerTexts[2] = treatmentHeader;

        bodyTexts[0] = infoText;
        bodyTexts[1] = effectsText;
        bodyTexts[2] = treatmentText;

        UpdateText();
    }

    public override void OnStateExit()
    {
        GLOBALS.isMeshing = false;
        ClearText();
    }

    public override void OnTouchGesture()
    {
        if (timer >= Mathf.Epsilon)
            return;
        switch (controller.TouchpadGesture.Direction)
        {
            case MLInputControllerTouchpadGestureDirection.Up:
                if (currentInfo == ModeInfo.Treatment)
                    currentInfo = ModeInfo.Info;
                else currentInfo++;
                UpdateText();
                break;
            case MLInputControllerTouchpadGestureDirection.Down:
                if (currentInfo == ModeInfo.Info)
                    currentInfo = ModeInfo.Treatment;
                else currentInfo--;
                UpdateText();
                break;
            case MLInputControllerTouchpadGestureDirection.Left:
                userControl.SetState(new WaveViewState(userControl, header, columns));
                break;
            case MLInputControllerTouchpadGestureDirection.Right:
                userControl.SetState(new RoomDimState(userControl, header, columns));
                break;
        }
    }

    private void UpdateText()
    {
        header.text = headerTexts[(int)currentInfo];
        columns[3].text = bodyTexts[(int)currentInfo];
    }

    

    }
