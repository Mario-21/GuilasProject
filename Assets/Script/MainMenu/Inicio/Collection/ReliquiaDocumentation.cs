using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReliquiaDocumentation : MonoBehaviour
{
    public int numeroReliquia;
    [Header("Documentation Reliquia")]
    [SerializeField] GameObject documentos;
    [SerializeField] GameObject fotoReliquia;
    [SerializeField] Button reliquiaButton;
    void Start()
    {
        CheckearReliquiaDocumentation();
    }

    void CheckearReliquiaDocumentation()
    {
        if (ListaReliquias.instancia.listaReliquiasTotal[numeroReliquia].reliquiaObtenida)
        {
            documentos.SetActive(true);
            fotoReliquia.SetActive(true);
            reliquiaButton.enabled = true;
        }
        else
        {
            documentos.SetActive(false);
            fotoReliquia.SetActive(false);
            reliquiaButton.enabled = false;
        }
    }
}
