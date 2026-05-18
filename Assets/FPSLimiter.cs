using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    public int framerate = 10;
    public bool vSync = true;
    void Start() {
        Application.targetFrameRate = framerate;
        
        if (vSync = true) {
            QualitySettings.vSyncCount = 1;
        }
        else {
            QualitySettings.vSyncCount = 0;
        }
        }
}
