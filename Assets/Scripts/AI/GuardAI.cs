using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    private Transform[] _path;

    private NavMeshAgent _agent;

    private int _whichWaypointNextIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _path = FindObjectOfType<Path>().GetPath(); //TODO Get FindObjectOfType out of there

        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        _agent.SetDestination(_path[_whichWaypointNextIndex].position);
        _whichWaypointNextIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasArrivedToWaypoint() && _whichWaypointNextIndex < _path.Length)
        {
            MoveToNextWaypoint();
        }
    }

    private bool HasArrivedToWaypoint()
    {
        return Vector3.Distance(transform.position, _path[_whichWaypointNextIndex - 1].position)
                    <= _agent.stoppingDistance;
    }
}
