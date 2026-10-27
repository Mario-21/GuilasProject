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
    [SerializeField] GameObject basket;
    ActivarModificador activador;
    [Header("Informacion botones Lavadora")]
    [SerializeField] SpriteRenderer botonRojo;
    [SerializeField] SpriteRenderer botonVerde;
    [SerializeField] Color colorLuzVerde;
    [SerializeField] Color colorLuzRojo;

    int audio;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        //Activar el modificador si tienes el cesto de ropa completo
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexAllClothes].modificacion)
        {
            activador.enabled = true;
        }
        //Si la lavadora se ha activado
    }
    void Update()
    {
        LavadoraOn();
    }
    void LavadoraOn()
    {
        if (activador.modificacion || StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            basket.SetActive(false);
            botonRojo.color = colorLuzRojo;
            botonVerde.color = colorLuzVerde;
            if (audio < 1)
            {
                activador.emissorAction.Play();
                audio++;
                this.enabled = false;
            }
            activador.enabled = false;
        }
    }
}
