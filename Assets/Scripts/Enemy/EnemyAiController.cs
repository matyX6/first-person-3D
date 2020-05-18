using UnityEngine;
using UnityEngine.AI;

public class EnemyAiController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent = null;
    [SerializeField] private PatrolPath _patrolPath = null;
    [SerializeField] private float _waypointTolerance = 2f;
    private Vector3 _defaultEnemyPosition = Vector3.zero;
    private int _currentWaypointIndex = 0;


    private void Start()
    {
        _defaultEnemyPosition = transform.position;
    }

    private void Update()
    {
        PatrolBehaviour();
    }

    private void PatrolBehaviour()
    {
        Vector3 nextPosition = _defaultEnemyPosition;

        if (_patrolPath != null)
        {
            if (AtWaypoint())
            {
                CycleWaypoint();
            }
            nextPosition = GetCurrentWaypoint();
        }

        _navMeshAgent.destination = nextPosition;

    }

    private bool AtWaypoint()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
        return distanceToWaypoint < _waypointTolerance;
    }

    private Vector3 GetCurrentWaypoint()
    {
        return _patrolPath.GetWaypoint(_currentWaypointIndex);
    }

    private void CycleWaypoint()
    {
        _currentWaypointIndex = _patrolPath.GetNextIndex(_currentWaypointIndex);
    }
}
