using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<Selectable> selectables { get; private set; } = new List<Selectable>();

    private Selectable currentUnitSelected;

    public void OnReceiveSelectionRequest(UnitInfo infoReceived)
    {
        if (currentUnitSelected != null && infoReceived == currentUnitSelected.GetUnitInfo())
            return;

        if (currentUnitSelected != null)
            currentUnitSelected.Unselect();
        currentUnitSelected = selectables.Find(v => v.GetUnitInfo() == infoReceived);
        currentUnitSelected.Select();
    }

    public void RegisterNewUnit(Selectable newUnit)
    {
        if (!selectables.Contains(newUnit))
            selectables.Add(newUnit);

        newUnit.GetComponent<Unit>().SetID(selectables.FindIndex(x => x == newUnit));
    }
}
