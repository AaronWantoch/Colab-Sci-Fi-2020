using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PathEditor : MonoBehaviour
{
    private Transform[] _waypoints;

    private void OnDrawGizmosSelected()
    {
        _waypoints = GetComponentsInChildren<Transform>();

        if (_waypoints.Length == 0)
            return;

        DrawPath();
    }

    private void DrawPath()
    {
        Transform lastWaypoint = _waypoints[0];
        for (int i = 1; i < _waypoints.Length; i++)
        {
            Gizmos.DrawLine(lastWaypoint.position, _waypoints[i].position);
            lastWaypoint = _waypoints[i];
        }
    }
}
