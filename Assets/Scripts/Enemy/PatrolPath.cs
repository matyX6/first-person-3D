using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    private const float WaypointGizmoRadius = 0.4f;


    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.DrawSphere(transform.GetChild(i).position, WaypointGizmoRadius);
        }
    }
}
