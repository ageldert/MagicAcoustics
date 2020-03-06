using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomModel
{
    // stores the length (z), width (x), and height (y) of the room
    public Vector3 dimensions;

    public float MaxModeFreq { get; set; } = 300f;

    private Dictionary<Vector3Int, float> modes;

    private float GetModeOfOrder(Vector3Int modeOrder)
    {
        float freq = Mathf.Sqrt(  Mathf.Pow((float)(modeOrder.x / dimensions.x), 2) +
                            Mathf.Pow((float)(modeOrder.y / dimensions.y), 2) +
                            Mathf.Pow((float)(modeOrder.z / dimensions.z), 2));
        freq *= (GLOBALS.c / 2);
        return freq;
    }

    public string ModeDisplay(Vector3Int order)
    {
        string answer = "";
        if (modes.TryGetValue(order, out float freq))
        {
            answer = "(" + order.x + ", " + order.y + ", " + order.z + ") : " +
                        freq.ToString(GLOBALS.format) + " Hz";
        }
        return answer;
    }

    public void CalculateModes()
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
