using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour, ISelectable
{
    public IUnit boundUnit { get; private set; }
    public bool isSelected { get; private set; }

    private void Start()
    {
        isSelected = false;
        boundUnit = GetComponent<IUnit>();
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
