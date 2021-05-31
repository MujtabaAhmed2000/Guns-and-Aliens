using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipControls : MonoBehaviour
{
    static bool rightTrue = true;
    [SerializeField] GameObject rightControls;
    [SerializeField] GameObject leftControls;
    
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
