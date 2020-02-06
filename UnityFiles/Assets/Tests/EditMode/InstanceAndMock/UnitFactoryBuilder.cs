using NSubstitute;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactoryBuilder
{
    private List<IUnit> _units = new List<IUnit>();
    private UnitManager _instanceManager;
    private Transform _parentTransform;

    public UnitFactoryBuilder()
    {
        _instanceManager = new GameObject().AddComponent<UnitManager>();
        _parentTransform = _instanceManager.transform;
    }

    public UnitFactoryBuilder With(int numberOfUnits)
    {
        for (int i = 0; i < numberOfUnits; i++)
            _units.Add(A.MockUnit().Build());

        return this;
    }

    public UnitFactoryBuilder With(List<IUnit> units)
    {
        _units = units;
        return this;
    }

    public IUnitFactory Build()
    {
        IUnitFactory mockFactory = Substitute.For<IUnitFactory>();
        mockFactory.instanceManager.Returns(_instanceManager);
        mockFactory.parentTransform.Returns(_parentTransform);
        mockFactory.prefabs.Returns(_units);
        return mockFactory;
    }
}