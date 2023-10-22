using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
#if UNITY_STANDALONE && !UNITY_EDITOR
 displayShit();
#endif
    }

    void displayShit()
    {
        // Check the number of monitors connected.
        if (Display.displays.Length > 1)
        {
            // Activate the display 1 (second monitor connected to the system).
            
            Display.displays[1].Activate(1280, 720, 60);
            Display.displays[2].Activate(1280, 720, 60);
            //Display.displays[1].SetRenderingResolution(960, 720);
            //Display.displays[1].SetParams(1280, 720, 0, 0);
            Screen.fullScreen = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
