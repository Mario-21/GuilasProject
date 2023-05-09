using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterPc_MaterialPropBlock : MonoBehaviour
{
    [Header("Shader Normal")]
    public float velocity;
    public float sizeBar;
    public float numBar;
    public float transparencia;
    [Header("Shader Noise")]
    public float velocityNoise;
    public float trasnparenciaNoise;
    [Header("Rotation")]
    public Vector2 centerRotate;
    [Header("Color")]
    public Color mainColor;

    public Renderer _renderer;
    public Image imagen;
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

        //imagen.material
        //imagen.materialForRendering.get
        //Cambias los valores
        //Normal
        _propBlock.SetFloat("_Velocity", velocity);
        _propBlock.SetFloat("_SizeBar", sizeBar);
        _propBlock.SetFloat("_NumBar", numBar);
        _propBlock.SetFloat("_Transparencia", transparencia);
        //Noise
        _propBlock.SetFloat("_VelocityNoise", velocityNoise);
        _propBlock.SetFloat("_TransparenciaNoise", trasnparenciaNoise);
        //Rotacion
        _propBlock.SetVector("_CenterRotate", centerRotate);
        //Color
        _propBlock.SetColor("_MainColor", mainColor);
        //_propBlock.SetVector("_MainDirection", direction);
        //_propBlock.SetVector("_SecondDirection", secondaryDirection);

        //Le estableces los valores cambiados
        _renderer.SetPropertyBlock(_propBlock);
    }
}
