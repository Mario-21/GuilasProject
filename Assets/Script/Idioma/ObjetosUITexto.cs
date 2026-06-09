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
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        switch (IdiomaGlobalManager.instanciaIdioma.idiomaActual)
        {
            case "Español":
                textoObjeto.text = nombreEspañol;
                break;
            case "English":
                textoObjeto.text = nombreIngles;
                break;
        }
    }
}
