using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Competence/DistanceAttackTemplate")]
public class DistanceAttackTemplate : CompetenceTemplate, IDistanceAttackTemplate
{
    [SerializeField] private int _distance = 5;
    [SerializeField] private float _damage = 2.0f;

    public int distance => _distance;
    public float damage => _damage;

    public override CompetenceId id => CompetenceId.DistanceAttack;


}
