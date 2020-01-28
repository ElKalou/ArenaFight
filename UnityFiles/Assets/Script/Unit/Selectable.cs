using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class Selectable : MonoBehaviour
{
    public UnitInfo boundUnit { get; private set; }
    public bool isSelected { get; private set; }

    private void Start()
    {
        isSelected = false;
        boundUnit = GetComponent<Unit>().boundData;
    }

    public void Select()
    {
        isSelected = true;
    }

    public void Unselect()
    {
        isSelected = false;
    }
}
