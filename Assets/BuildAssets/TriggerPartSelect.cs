using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPartSelect : MonoBehaviour
{
    public SelectParts selectParts;

    public int id;

    public bool isTool;

    public bool isWeapon;

    void OnMouseDown()
    {
        if (isTool)
            selectParts.SelectTool(id);
        if (isWeapon)
            selectParts.SelectWeapon(id);
    }
	
	public void Select() {
		OnMouseDown();
	}
}
