using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarTurbina : MonoBehaviour
{
    public float velocidad;
    [SerializeField] GameObject turbina;
    void Update()
    {
        turbina.transform.Rotate(0, transform.position.y + velocidad, 0);
    }
}
