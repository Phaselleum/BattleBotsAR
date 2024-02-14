using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FamethrowerBehaviour : ToolBehaviour
{
    public ParticleSystem[] flamethrowers;

    public override void ActuateTool()
    {
        foreach (var flamethrower in flamethrowers)
        {
            if(flamethrower.isStopped) 
                flamethrower.Play();
        }
    }

    public override void DisengageTool()
    {
        foreach (var flamethrower in flamethrowers)
        {
            if(flamethrower.isPlaying) 
                flamethrower.Stop();
        }
    }
}
