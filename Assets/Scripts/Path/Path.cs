using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private Transform[] _waypoints;

    private void Awake()
    {
        _waypoints = GetComponentsInChildren<Transform>();
    }

    public Transform[] GetPath()
    {
        return _waypoints;
    }
}
