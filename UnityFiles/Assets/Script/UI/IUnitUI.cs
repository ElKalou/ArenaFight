using UnityEngine;

public interface IUnitUI
{
    RectTransform parentTransform { get; }
    CompetenceButton buttonPrefab { get; }
}