using System.Collections.Generic;
using UnityEngine;

public interface IManager<Worker>
{
    List<Worker> workers { get; }
    void RegisterNewElement(Worker newElement);
}

public interface IUnitManager : IManager<ISelectable>
{
}

public interface IUnitUIManager : IManager<IUnitUI>
{
}

public interface ICompetenceButtonManager : IManager<IElementUI>
{
    RectTransform parentOfInstance { get; }
}