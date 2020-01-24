using UnityEngine;

public interface IFactory<Manager, Prefab>
{
    Manager instanceManager { get; }
    Prefab prefabUnitUI { get; }
    Transform parentTransform { get; }
}

public interface IUnitUIFactory : IFactory<UnitUIManager, UnitUI> { }