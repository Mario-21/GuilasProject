using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cascada_MaterialPropBlock : MonoBehaviour
{
    public Color mainColor, secondaryColor;
    public Vector2 directionCascada;
    public float cellDensity;

    Renderer _renderer;
    MaterialPropertyBlock _propBlock;
    private void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.GetPropertyBlock(_propBlock);

        _propBlock.SetColor("_MainColor", mainColor);
        _propBlock.SetColor("_SecondaryColor", secondaryColor);
        _propBlock.SetVector("_DirectionCascada", directionCascada);
        _propBlock.SetFloat("_CellDensity", cellDensity);

        _renderer.SetPropertyBlock(_propBlock);
    }
}
