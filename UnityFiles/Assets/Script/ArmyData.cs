using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit/ArmyData")]
public class ArmyData : ScriptableObject
{
    [SerializeField] private List<Unit> _units = new List<Unit>();
    [SerializeField] private Brain brain;

    public List<Unit> units => _units;

    public void AddUnit(Unit unit)
    {
        _units.Add(unit);
    }

    public void AddUnits(List<Unit> units)
    {
        foreach (Unit unit in units)
            _units.Add(unit);
    }
}

[System.Serializable]
public enum Brain
{
    player,
    computer
}
