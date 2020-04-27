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


                break;
            case StateEnum.LengthView:


                break;
            case StateEnum.Width:


                break;
            case StateEnum.WidthView:

                break;
            case StateEnum.Height:


                break;
            case StateEnum.HeightView:

                break;
            case StateEnum.ModeList:

                break;
            case StateEnum.RoomDim:

                break;
            case StateEnum.ModePlot:

                break;
            case StateEnum.WaveView:

                break;
            default:

                break;
        }
        
    }

}
