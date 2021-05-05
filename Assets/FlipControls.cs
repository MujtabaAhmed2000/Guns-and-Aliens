using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipControls : MonoBehaviour
{
    //public Transform controlsPanel;
    //public Transform activityPanel;

    public static bool rightTrue = true;
    public GameObject rightControls;
    public GameObject leftControls;
    
    public void flipcontrols()
    {
        if (rightTrue)
        {
            rightControls.SetActive(false);
            leftControls.SetActive(true);
            rightTrue = false;
        }
        else if (!rightTrue)
        {
            rightControls.SetActive(true);
            leftControls.SetActive(false);
            rightTrue = true;
        }
    }
}
