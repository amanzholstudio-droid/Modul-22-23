using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMover : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 point)
    {
        _navMeshAgent.SetDestination(point);
    }
}
