using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PozoEnter : MonoBehaviour
{
    public int indexMod;
    ActivarModificador activador;
    [Header("Pozo Características")]
    public GameObject cuerdaRota;
    public GameObject cuerdaArreglada;
    [SerializeField] Camino_CambiarZona pozoZone;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            PozoCuerda();
            activador.enabled = false;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnPozo();
    }
    void OnPozo()
    {
        if (activador.modificacion)
        {
            PozoCuerda();
            //Mod
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            activador.enabled = false;
        }
    }
    void PozoCuerda()
    {
        //Poner Cuerda
        cuerdaRota.SetActive(false);
        cuerdaArreglada.SetActive(true);
        //Habilitar Zona
        pozoZone.enabled = true;
    }
}
