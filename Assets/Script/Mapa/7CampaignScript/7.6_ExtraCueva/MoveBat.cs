using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBat : MonoBehaviour
{
    public float velocidad_x;
    public float velocidad_y;

    public bool move_X;
    // Update is called once per frame
    void Update()
    {
        if (move_X)
        {
            transform.Translate(Vector3.right * velocidad_x * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * velocidad_y * Time.deltaTime);
        }
        
    }
}
