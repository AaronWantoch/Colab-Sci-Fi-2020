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

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit))
                return;

            foreach(Unit unit in selctedUnits)
            {
                unit.MoveTo(hit.point);
            }
        }
    }
}
