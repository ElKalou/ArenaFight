using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class Selectable : MonoBehaviour
{
    private UnitInfo attachedInfo;
    public bool isSelected { get; private set; }

    private void Start()
    {
        isSelected = false;
        attachedInfo = GetComponent<Unit>().boundData;
    }

    public void Select()
    {
        isSelected = true;
        //Debug.Log(attachedInfo.name + " is Selected");
    }

    public void Unselect()
    {
        isSelected = false;
        Debug.Log(attachedInfo.name + " is deSelected");
    }

    public UnitInfo GetUnitInfo()
    {
        return attachedInfo;
    }
}
