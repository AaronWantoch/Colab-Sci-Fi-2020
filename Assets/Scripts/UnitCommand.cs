using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class UnitCommand : MonoBehaviour
{
    #region Singleton
    public static UnitCommand instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    #endregion 

    public List<Unit> selctedUnits;

    Vector2 _startingSelectionPoint;
    Vector2 _endingSelectionPoint;
    Vector2 _centerPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit))
                return;

            foreach (Unit unit in selctedUnits)
            {
                unit.MoveTo(hit.point);
            }
        }
        else if (Input.GetMouseButtonDown(0))
            _startingSelectionPoint = Input.mousePosition;
        else if(Input.GetMouseButtonUp(0))
        {
            _endingSelectionPoint = Input.mousePosition;
            _centerPoint = (_startingSelectionPoint + _endingSelectionPoint) / 2;

            float halfExtent = Mathf.Sqrt(
                Mathf.Pow(_centerPoint.x - _startingSelectionPoint.x, 2)
                + Mathf.Pow(_centerPoint.y - _startingSelectionPoint.y, 2));
            Collider[] colliders;


            //colliders = Physics.OverlapBox(_centerPoint,);
        }

    }
}
