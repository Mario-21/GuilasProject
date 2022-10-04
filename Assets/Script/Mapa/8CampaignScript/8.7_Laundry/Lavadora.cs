using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lavadora : MonoBehaviour
{
    public int indexMod;
    //Añadir los activadores de las 3 ropas para poder activarelModificador, sino podrías usar el cesto sin tener la ropa y todo se romperia
    [SerializeField] SpriteRenderer botonLavadora;
    ActivarModificador activador;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
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
            botonLavadora.color = Color.red;
        }
    }
}
