using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBehaviour : ToolBehaviour
{
    public override void ActuateTool()
    {
        tool.AddRelativeTorque(0, 10, 0);
    }

    public override void DisengageTool()
    {
        return;
    }
}
