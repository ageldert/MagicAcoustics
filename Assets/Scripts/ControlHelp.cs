using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlHelp : MonoBehaviour
{
    // the help text accompanying the controller visualizer
    [SerializeField] TextMeshPro triggerText;
    [SerializeField] TextMeshPro bumperText;
    [SerializeField] TextMeshPro homeText;
    [SerializeField] TextMeshPro padText;

    [SerializeField] MeshRenderer triggerMesh;
    [SerializeField] MeshRenderer bumperMesh;
    [SerializeField] MeshRenderer homeMesh;
    [SerializeField] MeshRenderer padMesh;

    [SerializeField] Material triggerMaterial;
    [SerializeField] Material bumperMaterial;
    [SerializeField] Material homeMaterial;
    [SerializeField] Material padMaterial;

    private void Update()
    {
        // fix materials
        triggerMesh.material = triggerMaterial;
        bumperMesh.material = bumperMaterial;
        homeMesh.material = homeMaterial;
        padMesh.material = padMaterial;
    }

    public void DisplayInstructions(State state)
    {
        // updates controller text with instructions for that state
        switch (state.myState)
        {
            case StateEnum.RoomScan:
                triggerText.text = "TRIGGER\nFinish Scan";
                bumperText.text = "BUMPER\nPause/Resume Meshing";
                homeText.text = "HOME\nHide/Show Mesh";
                padText.text = "";
                break;
            case StateEnum.Length:
                triggerText.text = "TRIGGER\nSelect surface";
                bumperText.text = "";
                homeText.text = "HOME\nRestart Scan";
                padText.text = "";
                break;
            case StateEnum.LengthView:
                triggerText.text = "TRIGGER\nContinue";
                bumperText.text = "BUMPER\nRemeasure";
                homeText.text = "HOME\nRestart Scan";
                padText.text = "";
                break;
            case StateEnum.Width:
                triggerText.text = "TRIGGER\nSelect surface";
                bumperText.text = "";
                homeText.text = "HOME\nRestart Scan";
                padText.text = "";
                break;
            case StateEnum.WidthView:
                triggerText.text = "TRIGGER\nContinue";
                bumperText.text = "BUMPER\nRemeasure";
                homeText.text = "HOME\nRestart Scan";
                padText.text = "";
                break;
            case StateEnum.Height:
                triggerText.text = "TRIGGER\nSelect surface";
                bumperText.text = "";
                homeText.text = "HOME\nRestart Scan";
                padText.text = "";
                break;
            case StateEnum.HeightView:
                triggerText.text = "TRIGGER\nContinue";
                bumperText.text = "BUMPER\nRemeasure";
                homeText.text = "HOME\nRestart Scan";
                padText.text = "";
                break;
            case StateEnum.ModeInfo:
                triggerText.text = "";
                bumperText.text = "";
                homeText.text = "";
                padText.text = "SWIPE PAD\n" +
                    "^ More Info\n" +
                    "v More Info\n" +
                    "< Standing Wave\n" +
                    "> Room Dimensions";
                break;
            case StateEnum.RoomDim:
                triggerText.text = "";
                bumperText.text = "";
                homeText.text = "";
                padText.text = "SWIPE PAD\n" +
                    "< Mode Information\n" +
                    "> Mode List";
                break;
            case StateEnum.ModeList:
                triggerText.text = "";
                bumperText.text = "";
                homeText.text = "";
                padText.text = "SWIPE PAD\n" +
                    "< Room Dimensions\n" +
                    "> Mode Plot";
                break;
            case StateEnum.ModePlot:
                triggerText.text = "";
                bumperText.text = "";
                homeText.text = "";
                padText.text = "SWIPE PAD\n" + 
                    "< Mode List\n" +
                    "> Standing Wave";
                break;
            case StateEnum.WaveView:
                triggerText.text = "TRIGGER\nChange Dimension";
                bumperText.text = "BUMPER\nToggle Pressure/Velocity";
                homeText.text = "";
                padText.text = "SWIPE PAD\n" +
                    "^ Increase Order\n" +
                    "v Decrease Order\n" +
                    "< Mode Plot\n" +
                    "> Mode Information";
                break;
            default:

                break;
        }
        
    }

}
