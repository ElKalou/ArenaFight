using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Selectable))]
public class Unit : MonoBehaviour, IUnitEventEmitter, IUnit
{
    [SerializeField] private UnitTemplate _unitTemplate = null;
    [SerializeField] private UnitEvent _setUpUI = null;

    //IUnitEventEmitter
    public UnitEvent eventToSend => _setUpUI;
    public IUnit dataToSend => this;

    //IUnit
    public IUnitTemplate template => _unitTemplate;
    public Transform unitTransform => transform;
    public ISelectable selectable
    {
        get
        {
            if (_selectable == null)
                _selectable = GetComponent<Selectable>();
            return _selectable;
        }
    }
    public List<Competence> competences { get; private set; } = new List<Competence>();
    public int currentLife { get; protected set; }

    private UnitEventEmitterController _eventController;
    private UnitController _unitController;
    private ISelectable _selectable;

    private void Awake()
    {
        _eventController = new UnitEventEmitterController(this);
        _unitController = new UnitController(this);

        InitDataFromTemplate();

        _eventController.RaiseEvent();
    }

    private void InitDataFromTemplate()
    {
        currentLife = _unitController.ChangeLife(template.maxLife);
        competences = _unitController.InitCompetences();
    }

    public void AddCompetence(ICompetenceTemplate toAdd)
    {
        _unitController.AddCompetence(toAdd);
    }

    public void SetCurrentLife(int life)
    {
        _unitController.ChangeLife(life);
    }
}
