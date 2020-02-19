using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Competence
{
    public ICompetenceTemplate template { get; private set; }
    public IUnit caster { get; private set; }
    public bool canBeCast { get; private set; }
    public Vector3 target { get; internal set; }

    public float coolDownTimer { get; private set; }

    public abstract CompetenceId id { get; }

    private MeshRenderer _meshInstance;

    public void PreCast()
    {
        if (_meshInstance == null)
            _meshInstance = UnityEngine.Object.Instantiate(template.rangeMesh, caster.unitTransform);
        else
            _meshInstance.enabled = true;
        Vector3 oldScale = _meshInstance.transform.localScale;
        float unitDisplacement = GetRange();
        _meshInstance.transform.localScale = new Vector3(
                unitDisplacement * 2,
                oldScale.y,
                unitDisplacement * 2
            );
    }

    public abstract float GetRange();

    public abstract bool TryCast();

    public abstract void Cast(Vector3 target);


    public void EndCast()
    {
        ResetCoolDown();
        _meshInstance.enabled = false;
    }

    public Competence(ICompetenceTemplate templateUse, IUnit caster)
    {
        this.caster = caster;
        template = templateUse;
    }

    public void Tick()
    {
        coolDownTimer += Time.deltaTime;
        if (coolDownTimer > GetCoolDown())
        {
            coolDownTimer = GetCoolDown();
            canBeCast = true;
        }
        else
            canBeCast = false;
    }

    protected void ResetCoolDown()
    {
        coolDownTimer = 0.0f;
        canBeCast = false;
    }

    public float GetCoolDown()
    {
        return template.coolDown;
    }
}
