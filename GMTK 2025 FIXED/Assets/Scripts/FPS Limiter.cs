using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    public int FPS;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;

        Application.targetFrameRate = FPS;
    }

   
}
