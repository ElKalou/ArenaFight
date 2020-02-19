using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public float currentLife { get; protected set; }
    public Navigator navigator { get; private set; }
    public AnimatorController animator { get; private set; }

    private UnitEventEmitterController _eventController;
    private UnitController _unitController;
    private ISelectable _selectable;

    private void Awake()
    {
        _eventController = new UnitEventEmitterController(this);
        _unitController = new UnitController(this);
        navigator = GetComponentInChildren<Navigator>();
        animator = GetComponentInChildren<AnimatorController>();

        InitDataFromTemplate();

        _eventController.RaiseEvent();
    }

    internal void TakeDamage(float damage)
    {
        Debug.Log(string.Format("unit {0} take {1} damage", name, damage)); //feedback
        SetCurrentLife(currentLife - damage);
    }

    private void InitDataFromTemplate()
    {
        SetCurrentLife(template.maxLife);
        competences = _unitController.InitCompetences();
    }

    public void AddCompetence(ICompetenceTemplate toAdd)
    {
        _unitController.AddCompetence(toAdd);
    }

    public void SetCurrentLife(float newLife)
    {
        currentLife = newLife;
    }


    private void Update()
    {
        foreach (Competence comp in competences) //in competenceManager ?? 
            comp.Tick();
    }

    public float GetDisplacement()
    {
        return template.displacement; //to determine from template + charac + inventory...
    }
}
