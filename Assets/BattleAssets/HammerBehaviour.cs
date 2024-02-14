using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBehaviour : ToolBehaviour
{
    public override void ActuateTool()
    {
        tool.AddRelativeTorque(100, 0, 0);
    }
    
    public override void DisengageTool()
    {
        tool.AddRelativeTorque(-10, 0, 0);
    }
}
