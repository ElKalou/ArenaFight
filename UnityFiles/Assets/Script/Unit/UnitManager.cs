using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour, IUnitManager
{
    public List<ISelectable> workers { get; private set; } = new List<ISelectable>();

    private ISelectable currentUnitSelected;

    public void RegisterNewElement(ISelectable newUnit)
    {
        if (!workers.Contains(newUnit))
            workers.Add(newUnit);
    }

    public void OnReceiveSelectionRequest(Unit infoReceived)
    {
        /*Debug.Log("receive selection event");
        if (currentUnitSelected != null && infoReceived == currentUnitSelected.boundUnit)
            return;

        if (currentUnitSelected != null)
            currentUnitSelected.Unselect();
        currentUnitSelected = selectables.Find(v => v.boundUnit == infoReceived);
        currentUnitSelected.Select();*/
    }

   
}
