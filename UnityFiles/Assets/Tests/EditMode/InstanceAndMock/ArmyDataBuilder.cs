using System.Collections.Generic;
using UnityEngine;

public class ArmyDataBuilder
{
    private ArmyData _armyData;

    public ArmyDataBuilder()
    {
        _armyData = ScriptableObject.CreateInstance<ArmyData>();
    }

    public ArmyDataBuilder(string path)
    {
        _armyData = Resources.Load<ArmyData>(path);
    }

    public ArmyDataBuilder With(List<Unit> units)
    {
        _armyData.AddUnits(units);
        return this;
    }

    public ArmyDataBuilder With(Unit unit)
    {
        _armyData.AddUnit(unit);
        return this;
    }

    public ArmyDataBuilder With(int numberOfUnits)
    {
        for (int i = 0; i < numberOfUnits; i++)
        {
            //_armyData.AddUnit(A.MockUnit().Build());
        }
        return this;
    }

    public static implicit operator ArmyData(ArmyDataBuilder armyBuilder) => armyBuilder.Build();


    public ArmyData Build()
    {
        return _armyData;
    }
}

