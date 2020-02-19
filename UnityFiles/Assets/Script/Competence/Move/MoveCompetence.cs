using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MoveCompetence : Competence
{
    private Camera _mainCam;

    public override CompetenceId id => CompetenceId.Move;

    public new IMoveCompetenceTemplate template { get; private set; }

    private MeshRenderer _meshInstance;

    public MoveCompetence(IMoveCompetenceTemplate template, IUnit caster) : base(template, caster)
    {
       this.template = template;
        _mainCam = Camera.main;
    }

    public override float GetRange()
    {
        return caster.GetDisplacement() * template.range;
    }

    public float GetMaxVelocity()
    {
        return template.speed;
    }

    public override bool TryCast()
    {                 
        if (!canBeCast)
            return false;

        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            target = hit.point;
            if (Vector3.Distance(caster.unitTransform.position, hit.point) < GetRange())
                return true;
        }

        return false;
    }

    public override void Cast(Vector3 target)
    {
        caster.navigator.SetDestination(target, this);
    }


    
}
