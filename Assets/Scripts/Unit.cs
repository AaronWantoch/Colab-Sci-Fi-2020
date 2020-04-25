using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    NavMeshAgent _agent;
    UnitCommand _unitCommand;

    bool isSelected;

    public event Action OnUnitSelected;
    public event Action OnUnitDeselected;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _unitCommand = UnitCommand.instance; 

        OnUnitSelected += AddToSelectedList;
        OnUnitDeselected += RemoveFromSelectedList;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isSelected)
        {
            OnUnitSelected();
            isSelected = true;
        }
        else if (Input.GetMouseButtonDown(0) && isSelected)
        {
            OnUnitDeselected();
            isSelected = false;
        }
    }

    public void MoveTo(Vector3 where)
    {
        _agent.SetDestination(where);
    }

    void AddToSelectedList()
    {
        _unitCommand.selctedUnits.Add(this);
    }

    void RemoveFromSelectedList()
    {
        _unitCommand.selctedUnits.Remove(this);
    }
}
