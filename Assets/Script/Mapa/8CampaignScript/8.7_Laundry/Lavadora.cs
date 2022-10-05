using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lavadora : MonoBehaviour
{
    [Header("Su GameObject Variable")]
    public int indexMod;
    [SerializeField] 
    [Header("Variable Ropa")]
    public int indexAllClothes;
    [Header("Lavadora On")]
    [SerializeField] SpriteRenderer botonLavadora;
    [SerializeField] GameObject basket;
    ActivarModificador activador;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        //Activar el modificador si tienes el cesto de ropa completo
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexAllClothes].modificacion)
        {
            activador.enabled = true;
        }
        //Si la lavadora se ha activado
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
            botonLavadora.color = Color.red;
        }
    }
    void Update()
    {
        LavadoraOn();
    }
    void LavadoraOn()
    {
        if (activador.modificacion)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            basket.SetActive(false);
            botonLavadora.color = Color.red;
        }
    }
}
