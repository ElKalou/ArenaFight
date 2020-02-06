using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UnitFactoryController
{
    private IUnitFactory _factory;
    public Dictionary<IUnitTemplate, int> unitsAvailable { get; private set; }

    public UnitFactoryController(IUnitFactory factory)
    {
        _factory = factory;       
    }

    public void MakeDictionnary()
    {
        unitsAvailable = new Dictionary<IUnitTemplate, int>();
        for (int i = 0; i < _factory.prefabs.Count; i++)
        {
            IUnitTemplate key = _factory.prefabs[i].template;
            if (!unitsAvailable.ContainsKey(key))
                unitsAvailable.Add(key, i);
        }
    }

    public int GetIndex(IUnitTemplate unitTemplate)
    {
        if (unitsAvailable == null)
            MakeDictionnary();
        return unitsAvailable[unitTemplate];
    }

    public void PassUnitToManager(IUnit unit)
    {
        _factory.instanceManager.RegisterNewElement(unit.selectable);
    }
}
