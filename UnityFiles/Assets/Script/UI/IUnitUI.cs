using UnityEngine;

public interface IUnitUI
{
    Transform parentTransform { get; }
    CompetenceButton buttonPrefab { get; }
}