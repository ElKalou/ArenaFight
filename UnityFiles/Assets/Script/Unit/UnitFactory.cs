using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(UnitManager))]
public class UnitFactory : MonoBehaviour
{
    [SerializeField] private ArmyData _armyData = null;
    [SerializeField] private SpawnTransform _spawnPositions = null;

    public UnitManager unitManager { get; private set; }

    public void Init()
    {
        unitManager = GetComponent<UnitManager>();
    }

    private void Start()
    {
        Init();
        if(_armyData != null)
            SpawnArmy(_armyData.units, _spawnPositions._transforms);
    }

    public List<Unit> SpawnArmy(List<Unit> units, List<Transform> transforms)
    {
        List<Unit> instanciatedUnits = new List<Unit>();
        for (int i = 0; i < Mathf.Min(units.Count, transforms.Count); i++)
            instanciatedUnits.Add(SpawnUnit(units[i], transforms[i]));

        return instanciatedUnits;
    }

    public Unit SpawnUnit(Unit unit, Transform spawnTransform)
    {
        Unit newUnit = (Unit)PrefabUtility.InstantiatePrefab(unit, this.transform);
        newUnit.Init();
        unitManager.RegisterNewUnit(newUnit.GetComponent<Selectable>());
        newUnit.transform.position = spawnTransform.position;
        newUnit.transform.rotation = spawnTransform.rotation;
        return newUnit;
    }
}
