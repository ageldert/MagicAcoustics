using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomModel
{
    // stores the length (z), width (x), and height (y) of the room in veet
    public Vector3 dimensions;
    public float volume;    // ft^3
    public float surfaceArea;   // ft^2
    public float meanFreePath;  // 4V/Sa (ft)

    public float MaxModeFreq { get; set; } = 280f;

    private Dictionary<Vector3Int, float> modes;

    public RoomModel()
    {
        modes = new Dictionary<Vector3Int, float>();
    }

    private float GetModeOfOrder(Vector3Int modeOrder)
    {
        float freq = Mathf.Sqrt(  Mathf.Pow((float)(modeOrder.x / dimensions.x), 2) +
                            Mathf.Pow((float)(modeOrder.y / dimensions.y), 2) +
                            Mathf.Pow((float)(modeOrder.z / dimensions.z), 2));
        freq *= (GLOBALS.c / 2);
        return freq;
    }

    public string DisplayModeOfOrder(Vector3Int order)
    {
        // displays via (L,W,H)
        string answer = "";
        if (modes.TryGetValue(order, out float freq))
        {
            answer = "(" + order.z + ", " + order.x + ", " + order.y + ") : " +
                        freq.ToString("F1") + "\n";
        }
        return answer;
    }

    public string DisplayAllModes()
    {
        string answer = "";
        foreach (KeyValuePair<Vector3Int, float> mode in modes)
        {
            answer += modeDisp(mode);
        }
        return answer;
    }

    public string DisplayAllModesUnderOrder(int maxOrder)
    {
        string answer = "";
        foreach (KeyValuePair<Vector3Int, float> mode in modes)
        {
            if ((mode.Key.z + mode.Key.y + mode.Key.x) > maxOrder) continue;
            answer += modeDisp(mode);
        }
        return answer;
    }

    public string DisplayAllModesAxial(int dim = 0)
    {
        string answer = "";
        switch(dim)
        {
            case 1:
                foreach (KeyValuePair<Vector3Int, float> mode in modes)
                {
                    if (mode.Key.z < 1 || mode.Key.y > 0 || mode.Key.x > 0) continue;
                    answer += modeDisp(mode);
                }
                break;
            case 2:
                foreach (KeyValuePair<Vector3Int, float> mode in modes)
                {
                    if (mode.Key.x < 1 || mode.Key.z > 0 || mode.Key.y > 0) continue;
                    answer += modeDisp(mode);
                }
                break;
            case 3:
                foreach (KeyValuePair<Vector3Int, float> mode in modes)
                {
                    if (mode.Key.y < 1 || mode.Key.z > 0 || mode.Key.x > 0) continue;
                    answer += modeDisp(mode);
                }
                break;
            default:
                foreach(KeyValuePair<Vector3Int, float> mode in modes)
                {
                    answer += modeDisp(mode);
                }
                break;
        }
        
        return answer;
    }

    private string modeDisp(KeyValuePair<Vector3Int, float> mode)
    {
        return "(" + mode.Key.z + ", " + mode.Key.x + ", " + mode.Key.y + ") : " +
                                mode.Value.ToString("F1") + " Hz\n";
    }

    public int GetModeMagnitude(Vector3Int order)
    {
        // Returns a value from -20 to 0 (dB) representing mode strength
        // Mode strength is NOT location-specific
        // Modeling with 0 dB axial, -3 dB tangential, -6 dB oblique
        // Modeling with -2 dB for increasing mode order
        int mag = 3; // there always is a 1st order -3 dB to offset for
        if (order.x > 0)
        {
            mag -= 3;   // axial, tangential, oblique
            mag -= 2 * (order.x - 1);   // mode order
        }
        if (order.y > 0)
        {
            mag -= 3;   // axial, tangential, oblique
            mag -= 2 * (order.y - 1);   // mode order
        }
        if (order.z > 0)
        {
            mag -= 3;   // axial, tangential, oblique
            mag -= 2 * (order.z - 1);   // mode order
        }
        return mag;
    }



    public void CalcDimensions()
    {
        volume = dimensions.x * dimensions.y * dimensions.z;
        surfaceArea = 2*(dimensions.x * dimensions.y +
            dimensions.x * dimensions.z +
            dimensions.y * dimensions.z);
        meanFreePath = 4 * volume / surfaceArea;
    }

    public void CalcModes()
    {
        // are we looking at the FIRST y order: do we need to increment y or x?
        bool firstY = false;
        bool firstX = false;
        Vector3Int order = new Vector3Int(0,0,1);
        float fMode;

        while(true)
        {
            fMode = GetModeOfOrder(order);
            if (fMode < MaxModeFreq)
            {
                modes.Add(order, fMode);
                order.z++;
                firstY = false;
                firstX = false;
            }
            else
            {
                // have we found the highest x,0,0 order?
                if (firstX)
                    break;
                // have we found the highest 0,y,0 order?
                if (firstY)
                {
                    order.x++;
                    order.y = 0;
                    order.z = 0;
                    firstX = true;
                }
                else
                {
                    order.y++;
                    order.z = 0;
                    firstY = true;
                }
            }
        }
    }
}
