using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttackCompetence : Competence
{
    public new IDistanceAttackTemplate template { get; private set; }

    public override CompetenceId id => CompetenceId.DistanceAttack;


    private Camera _mainCam;

    private ProjectilePool _projectilePool;

    public DistanceAttackCompetence(IDistanceAttackTemplate templateUse, IUnit caster) : base(templateUse, caster)
    {
        //Template & caster can be null on construction of the competence factory
        if (templateUse == null && caster == null) 
            return;

        template = templateUse;
        _mainCam = Camera.main;
        _projectilePool = templateUse.projectilePool;
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
            if (Vector3.Distance(caster.unitTransform.position, target) < GetRange())
                return true;
        }
        return false;
    }

    public override void Cast(Vector3 target)
    {
        caster.unitTransform.LookAt(target);
        Projectile projectile = _projectilePool.GetInstance();
        projectile.Init(target, caster, template);
    }

    public override float GetRange()
    {
        return template.range;
    }
}
