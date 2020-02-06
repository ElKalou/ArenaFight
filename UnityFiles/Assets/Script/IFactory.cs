using System.Collections.Generic;
using UnityEngine;

public interface IFactory<Manager, Prefab>
{
    Manager instanceManager { get; }
    Transform parentTransform { get; }
}

public interface IUnitFactory : IFactory<IUnitManager, Unit>
{
    List<IUnit> prefabs { get; }
}

public interface IUnitUIFactory : IFactory<IUnitUIManager, UnitUI>
{
}

public interface ICompetenceButtonFactory : IFactory<ICompetenceButtonManager, CompetenceButton>
{
}

