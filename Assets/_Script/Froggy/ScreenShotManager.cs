using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotManager : UnitySingleton_DR<ScreenShotManager>
{
    public Texture2D ScreenShotTex;

    public void Screenshot()
    {
        ScreenShotTex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ScreenShotTex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ScreenShotTex.Apply();
    }
}