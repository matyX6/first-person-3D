using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    private const float WaypointGizmoRadius = 0.4f;


    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int j = GetNextIndex(i);
            Gizmos.DrawSphere(GetWaypoint(i), WaypointGizmoRadius);
            Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
        }
    }

    private int GetNextIndex(int i)
    {
        if (i + 1 == transform.childCount)
            return 0;

        return i + 1;
    }

    private Vector3 GetWaypoint(int i)
    {
        return transform.GetChild(i).position;
    }
}

