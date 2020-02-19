using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnRangeAttack() { }
    public void OnMeleeAttack() { }
    public void OnMagicAttack() { }
    public void OnTakeDamage() { }
    public void SetVelocity(float velocity)
    {
        _animator.SetFloat("Velocity", velocity);
    }
}