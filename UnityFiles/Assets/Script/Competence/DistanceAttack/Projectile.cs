using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed = 0;
    [SerializeField] float _launchDist = 0.5f;

    private Vector3 _target;
    private IUnit _caster;
    private IDistanceAttackTemplate _competenceTemplate;
    private ProjectilePool _pool;

    internal void Init(Vector3 target, IUnit caster, IDistanceAttackTemplate competenceTemplate)
    {
        _target = target;
        _caster = caster;
        _competenceTemplate = competenceTemplate;
        _pool = competenceTemplate.projectilePool;
        transform.position = new Vector3(
            _caster.unitTransform.position.x,
            0.5f,
            _caster.unitTransform.position.z) + _caster.unitTransform.forward * _launchDist;
        StartCoroutine(MoveTowardTarget());
    }

    public IEnumerator MoveTowardTarget()
    {
        Vector3 direction = Vector3.Normalize(_target - transform.position);
        direction.y = 0;
        while (transform.position.magnitude < 50)
        {
            transform.position += _speed * Time.deltaTime * direction;
            yield return null;
        }
        _pool.RecycleInstance(this);
    }

    private void Impact(Collider collider)
    {
        StopCoroutine(MoveTowardTarget());

        Debug.Log("impact with " + collider.gameObject.name); //impact feed back

        Unit unit = collider.GetComponent<Unit>();
        if (unit)
            unit.TakeDamage(GetDamage());
        _pool.RecycleInstance(this);
    }

    private float GetDamage()
    {
        return _competenceTemplate.damage; //mix of competencetemplate, caster, target
    }

    public void OnTriggerEnter(Collider other)
    {
        Impact(other);
    }
}