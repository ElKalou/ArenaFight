using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUIManager : MonoBehaviour
{
    public List<UnitUI> managedUnitUI { get; private set; } = new List<UnitUI>();

    public void RegisterNewUnitUI(UnitUI newUnitUI)
    {
        if (managedUnitUI.Contains(newUnitUI))
            return;

        managedUnitUI.Add(newUnitUI);
        PlaceUnitUI(newUnitUI);

    }

    private void PlaceUnitUI(UnitUI toPlace)
    {
        int index = managedUnitUI.FindIndex(value => value == toPlace);
        RectTransform rectTransform = managedUnitUI[index].GetComponent<RectTransform>();
        float height = rectTransform.rect.height;
        rectTransform.position -= new Vector3(0, height * index, 0);
    }
}
