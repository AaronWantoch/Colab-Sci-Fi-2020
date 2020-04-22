using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleController : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer _renderer;
    [SerializeField] Material _highlightMaterial;

    Material defaultMaterial;

    private void Start()
    {
        defaultMaterial = _renderer.material;

        Unit unit = GetComponent<Unit>();
        unit.OnUnitSelected += ActivateHighlight;
        unit.OnUnitDeselected += DeactivateHighlight;
    }

    void ActivateHighlight()
    {
        _renderer.material = _highlightMaterial;
    }

    void DeactivateHighlight()
    {
        _renderer.material = defaultMaterial;
    }
}
