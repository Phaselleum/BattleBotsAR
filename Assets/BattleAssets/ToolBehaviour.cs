using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToolBehaviour : MonoBehaviour
{

    [SerializeField] protected Rigidbody tool;
    
    public abstract void ActuateTool();
    public abstract void DisengageTool();
}
