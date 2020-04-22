using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleController : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer renderer;
    [SerializeField] Material highlightMaterial;

    Material defaultMaterial;

    private void Start()
    {
        defaultMaterial = renderer.material;

        GetComponent<UnitCommand>().OnUnitSelected += ActivateHighlight;
    }

    void ActivateHighlight()
    {
        renderer.material = highlightMaterial;
    }

    void DeactivateHighlight()
    {
        renderer.material = defaultMaterial;
    }
}
