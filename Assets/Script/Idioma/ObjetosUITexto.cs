using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosUITexto : MonoBehaviour
{
    public Text textoObjeto;

    [Header("Nombre Español")]
    [SerializeField] string nombreEspañol;
    [Header("Nombre Ingles")]
    [SerializeField] string nombreIngles;

    string idiomaGuardado;
    void Update()
    {
        IdiomaGlobalManager.instanciaIdioma.SelectorTextoIdioma(ref idiomaGuardado, textoObjeto, nombreEspañol, nombreIngles);
    }
}
