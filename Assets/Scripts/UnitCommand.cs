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

    Vector2 _startPosition;
    Vector2 _rightDownCorner;
    Vector2 _centerPoint;

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
            selectionArea.gameObject.SetActive(true);

            _startPosition = currentMousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 lowerLeftCorner = new Vector2(
                Mathf.Min(_startPosition.x, currentMousePosition.x)
                , Mathf.Min(_startPosition.y, currentMousePosition.y));
            Vector2 upperRightCorner = new Vector2(
                Mathf.Max(_startPosition.x, currentMousePosition.x)
                , Mathf.Max(_startPosition.y, currentMousePosition.y));

            selectionArea.position = lowerLeftCorner;
            selectionArea.localScale = new Vector2(
                upperRightCorner.x - lowerLeftCorner.x
                , upperRightCorner.y - lowerLeftCorner.y);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectionArea.gameObject.SetActive(false);

            //colliders = Physics.OverlapBox(_centerPoint,);
        }
    }
}
