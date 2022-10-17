using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentiladorGiro : MonoBehaviour
{
    public float velocidad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GirarVentilador();
    }
    void GirarVentilador()
    {
        transform.Rotate(0, 0, transform.position.z + velocidad);
    }
}
