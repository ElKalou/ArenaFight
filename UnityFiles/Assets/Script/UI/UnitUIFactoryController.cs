using UnityEditor;
using UnityEngine;

public class UnitUIFactoryController
{
    private IUnitUIFactory _factory;

    public UnitUIFactoryController(IUnitUIFactory factory)
    {
        _factory = factory;
    }

    public UnitUI SpawnUnitUI(UnitInfo unitInfo)
    {
        UnitUI newUnitUI = (UnitUI)PrefabUtility.InstantiatePrefab(_factory.prefabUnitUI, _factory.parentTransform);
        newUnitUI.Init(unitInfo);
        _factory.instanceManager.RegisterNewUnitUI(newUnitUI);
        return newUnitUI;
    }
}
