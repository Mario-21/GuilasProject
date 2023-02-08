using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water2_MaterialPropBlock : MonoBehaviour
{
    public Color mainColor, secondaryColor;
    public Vector2 direction, secondaryDirection;

    Renderer _renderer;
    MaterialPropertyBlock _propBlock;


    private void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Coges las propiedades del valor que quieres usar
        _renderer.GetPropertyBlock(_propBlock);

        //Cambias los valores
        _propBlock.SetColor("_MainColor", mainColor);
        _propBlock.SetColor("_SecondaryColor", secondaryColor);
        _propBlock.SetVector("_MainDirection", direction);
        _propBlock.SetVector("_SecondDirection", secondaryDirection);

        //Le estableces los valores cambiados
        _renderer.SetPropertyBlock(_propBlock);
    }
}
