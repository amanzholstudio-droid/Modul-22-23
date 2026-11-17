using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMover : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private NavMeshAgent _navMeshAgent;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        if (_playerHealth.IsDead)
            _navMeshAgent.isStopped = true;
    }
    public void MoveTo(Vector3 point)
    {
        if (_playerHealth.IsDead) return;
        _navMeshAgent.SetDestination(point);
    }
}
