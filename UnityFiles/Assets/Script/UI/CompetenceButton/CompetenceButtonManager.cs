using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(RectTransform))]
public class CompetenceButtonManager : MonoBehaviour, ICompetenceButtonManager
{
    public List<IElementUI> workers { get; private set; } = new List<IElementUI>();

    public RectTransform parentOfInstance
    {
        get
        {
            if (_parentOfInstance == null)
                _parentOfInstance = GetComponent<RectTransform>();
            return _parentOfInstance;
        }
    }
    private RectTransform _parentOfInstance;

    private CompetenceButtonManagerController _controller;

    public void Awake()
    {
        _controller = new CompetenceButtonManagerController(this);
    }

    public void RegisterNewElement(IElementUI newElement)
    {
        if (workers.Contains(newElement))
            return;

        workers.Add(newElement);

        if (_controller == null)
            _controller = new CompetenceButtonManagerController(this);
        _controller.PlaceButton();
    }
}
