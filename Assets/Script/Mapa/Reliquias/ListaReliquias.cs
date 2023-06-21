using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaReliquias : MonoBehaviour
{
    public static ListaReliquias instancia;

    public List<Reliquias> listaReliquiasTotal;

    private void Awake()
    {
        if (ListaReliquias.instancia == null)
        {
            ListaReliquias.instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame

}
