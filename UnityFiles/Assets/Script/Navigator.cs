using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigator : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private MoveCompetence _mover;
    private ParticleSystem _unitTrails;
    private IUnit _bindUnit;

    void Awake()
    {
        _navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        _bindUnit = GetComponentInParent<IUnit>();
    }

    public void SetDestination(Vector3 target, MoveCompetence mover)
    {
        _mover = mover;
        _navMeshAgent.speed = _mover.GetMaxVelocity();

        if (_unitTrails == null)
            _unitTrails = Instantiate(mover.template.unitTrail, transform);

        _navMeshAgent.SetDestination(target);
    }

    void Update()
    {
        ParticleTick();
        AnimationTick();
    }

    private void AnimationTick()
    {
        if (_mover == null)
            return;

        _bindUnit.animator.SetVelocity(Vector3.Magnitude(_navMeshAgent.velocity) / _mover.GetMaxVelocity());
    }

    private void ParticleTick()
    {
        if (_unitTrails == null)
            return;

        if (Vector3.Magnitude(_navMeshAgent.velocity) > 0.2f && !_unitTrails.isPlaying)
            _unitTrails.Play(true);
        else if(Vector3.Magnitude(_navMeshAgent.velocity) < 0.2f && _unitTrails.isPlaying)
            _unitTrails.Stop(true);
    }
}
