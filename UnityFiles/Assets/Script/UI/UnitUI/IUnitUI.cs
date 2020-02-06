using UnityEngine;

public interface IUnitUI : IElementUI
{
    IUnit attachedUnit { get; }

    void Init(IUnit dataReceived);
}