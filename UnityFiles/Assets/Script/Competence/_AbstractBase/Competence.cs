using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Competence
{
    public ICompetenceTemplate template { get; private set; }

    public float coolDownTimer { get; private set; }

    public abstract CompetenceId id { get; }

    //Unit info
    public Unit bindUnit {
        get
        {
            if(_bindUnit == null)
            {
                if (_unitTransform == null)
                    return null;
                _bindUnit = _unitTransform.GetComponent<Unit>();
            }
            return _bindUnit;
        }
        private set { }
    }
    private Unit _bindUnit;
    private Transform _unitTransform;

    public abstract bool CastCompetence();

    internal void SetUnitTransform(Transform ownerTransform)
    {
        _unitTransform = ownerTransform;
    }

    internal void InitDataFromTemplate(ICompetenceTemplate competenceTemplate)
    {
        template = competenceTemplate;
    }
}
