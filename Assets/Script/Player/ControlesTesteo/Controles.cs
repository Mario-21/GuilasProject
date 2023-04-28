using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Controles : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Comienza el Texteo Controles");
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Salto");
        }
        if (Input.GetButtonDown("Action"))
        {
            Debug.Log("Accion");
        }
        if (Input.GetButtonDown("Take"))
        {
            Debug.Log("Tomar Item");
        }
        if (Input.GetButtonDown("Inventory"))
        {
            Debug.Log("Inventario");
        }
        if (Input.GetButtonDown("Draw_Weapon"))
        {
            Debug.Log("Sacar Arma");
        }
        if (Input.GetButtonDown("Change_Weapon"))
        {
            Debug.Log("Cambiar Arma");
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log("Fire3");
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Debug.Log("Plus");
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            Debug.Log("Minus");
        }
    }
}
