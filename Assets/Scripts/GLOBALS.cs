using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GLOBALS
{
    // Unity default units are meters
    public static bool inFeet = true;
    // conversion value
    public const float m2ft = 3.28084f;
    // speed of sound
    public const float c = 343f;
    // room mesh visibility
    public static bool meshVisible = true;
    // actively using MLSpatialMapper
    public static bool isMeshing = false;
    // precision of digits
    public const string format = "F2";
    // L, W, H?
    public static bool measureHeight = false;
}

// Mode struct is used for plotting
// Dictionary used instead for storage in RoomModel
public struct Mode
{
    public float freq;
    public Vector3Int order;
    public float mag;
};

/*  Consider 3dB differences axial, tangential, oblique
 *  build all pole filter (inverse comb)
 *  to plot the frequency response
 *  
 *  Create plot of lines of modes 
 *
 *  Horizontal swipe during mode view for:
 *      - Axial Mode Display
 *      - Tangential, Oblique Mode Display
 *      - Mode frequency lines
 *      - Room volume, surface area, MFP
 *      -
 */
