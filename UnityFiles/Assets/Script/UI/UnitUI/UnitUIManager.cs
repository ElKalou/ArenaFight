using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUIManager : MonoBehaviour, IUnitUIManager
{
    public List<IUnitUI> workers { get; private set; } = new List<IUnitUI>();

    public void RegisterNewElement(IUnitUI newUnitUI)
    {
        if (workers.Contains(newUnitUI))
            return;

        workers.Add(newUnitUI);
        PlaceUnitUI(newUnitUI);
    }

    private void PlaceUnitUI(IUnitUI toPlace)
    {
        int index = workers.FindIndex(value => value == toPlace);
        RectTransform rectTransform = workers[index].rectTransform;
        float height = rectTransform.rect.height;
        rectTransform.position -= new Vector3(0, height * index, 0);
    }
}
