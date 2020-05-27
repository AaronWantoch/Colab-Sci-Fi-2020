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

    [HideInInspector] public List<Unit> selctedUnits;

    [SerializeField] private RectTransform selectionArea;
    [SerializeField] private Transform boxCast;   //the box that is being used to boxcast

    Vector2 _startPosition;
    Vector2 _rightDownCorner;
    Vector2 _centerPoint;
    Vector2 _lowerLeftCorner, _uperRightCorner;

    float width, height;

    private void Start()
    {
        selectionArea.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SelectSingleUnit();
        }
        BoxSelection();

    }

    private void SelectSingleUnit()
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

    private void BoxSelection()
    {
        Vector2 currentMousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = currentMousePosition;

            selectionArea.gameObject.SetActive(true);
        }
        else if (Input.GetMouseButton(0))
        {
            _lowerLeftCorner = new Vector2(
                Mathf.Min(_startPosition.x, currentMousePosition.x)
                , Mathf.Min(_startPosition.y, currentMousePosition.y));
            _uperRightCorner = new Vector2(
                Mathf.Max(_startPosition.x, currentMousePosition.x)
                , Mathf.Max(_startPosition.y, currentMousePosition.y));

            width = _uperRightCorner.x - _lowerLeftCorner.x;
            height = _uperRightCorner.y - _lowerLeftCorner.y;

            selectionArea.position = _lowerLeftCorner;
            selectionArea.localScale = new Vector2(width, height);


        }
        else if (Input.GetMouseButtonUp(0))
        {
            Collider[] colliders;

            selectionArea.gameObject.SetActive(false);

            boxCast.position = new Vector3(_lowerLeftCorner.x, _lowerLeftCorner.y,transform.position.z);
            boxCast.localScale = new Vector3(width, height, boxCast.localScale.z);


            /*
            foreach(Collider collider in colliders)
            {
                Unit unit = collider.GetComponent<Unit>();

                if(unit)
                    unit.Select();

                Debug.Log(collider);
            }*/
        }
    }
}
