using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    private const float WoundedThreshold = 0.3f;
    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int IsWoundedHash = Animator.StringToHash("IsWounded");
    private static readonly int IsDeadHash = Animator.StringToHash("IsDead");
    private static readonly int HitHash = Animator.StringToHash("Hit");
    private NavMeshAgent _agent;
    private Animator _animator;
    private PlayerHealth _health;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _health = GetComponent<PlayerHealth>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat(SpeedHash, _agent.velocity.magnitude / _agent.speed);
        _animator.SetBool(IsWoundedHash, _health.HealthPercent < WoundedThreshold);
        _animator.SetBool(IsDeadHash, _health.IsDead);
    }

    public void PlayHit()
    {
        _animator.SetTrigger(HitHash);
    }
}
