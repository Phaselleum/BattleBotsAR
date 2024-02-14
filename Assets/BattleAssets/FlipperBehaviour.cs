using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperBehaviour : ToolBehaviour
{
    public override void ActuateTool()
    {
        tool.AddRelativeTorque(-25, 0, 0);
    }
    public override void DisengageTool()
    {
        tool.AddRelativeTorque(5, 0, 0);
    }
}
