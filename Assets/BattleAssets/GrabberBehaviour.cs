using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class GrabberBehaviour : ToolBehaviour
{
    public Rigidbody leftGrabber;
    public Rigidbody rightGrabber;
    
    public override void ActuateTool()
    {
        leftGrabber.AddRelativeTorque(0, 10, 0);
        rightGrabber.AddRelativeTorque(0, -10, 0);
    }
    public override void DisengageTool()
    {
        leftGrabber.AddRelativeTorque(0, -10, 0);
        rightGrabber.AddRelativeTorque(0, 10, 0);
    }
}