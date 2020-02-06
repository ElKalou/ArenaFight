using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Competence/MeleeAttackTemplate")]
public class MeleeAttackTemplate : CompetenceTemplate, IMeleeAttackTemplate
{
    [SerializeField] private float _damage = 5.0f;

    public float damage => _damage;

    public override CompetenceId id => CompetenceId.MeleeAttack;
}
