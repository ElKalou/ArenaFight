using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Competence/DistanceAttackTemplate")]
public class DistanceAttackTemplate : CompetenceTemplate, IDistanceAttackTemplate
{
    [SerializeField] private Projectile _projectile = null;
    [SerializeField] private float _damage = 0;

    public Projectile projectile => _projectile;

    public override CompetenceId id => CompetenceId.DistanceAttack;

    public float damage => _damage;

    public ProjectilePool projectilePool
    {
        get
        {
            if (_projectilePool == null)
                _projectilePool = new ProjectilePool(_projectile, 10);
            return _projectilePool;
        }
    }
    private ProjectilePool _projectilePool;
}
