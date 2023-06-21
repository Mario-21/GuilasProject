using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Reliquia : MonoBehaviour
{
    public ListCampaign listaCampaign;
    [SerializeField] GameObject reliquia;
    void Update()
    {
        if (ListaReliquias.instancia.listaReliquiasTotal[listaCampaign.indexReliquia].reliquiaObtenida)
        {
            reliquia.SetActive(true);
        }
        else
        {
            reliquia.SetActive(false);
        }
    }
}
