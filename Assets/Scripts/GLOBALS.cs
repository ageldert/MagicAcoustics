using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GLOBALS
{
    // default units are meters
    public static bool inFeet = false;
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

/*  Consider 3dB differences axial, tangential, oblique
 *  build all pole filter (inverse comb)
 *  to plot the frequency response
 *  
 *  
 *  
 */
