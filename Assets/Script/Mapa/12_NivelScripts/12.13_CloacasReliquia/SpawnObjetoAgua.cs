using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjetoAgua : MonoBehaviour
{
    [Header("Info Agua")]
    public int aguaData;
    public int porcentajeAguaSpawn;
    int registrarAguaPrevia;
    [Header("Info Objeto")]
    [SerializeField] GameObject objeto;
    [SerializeField] Transform spawnInicial;
    [SerializeField] Transform spawnPostAgua;
    [Header("Modo Actualizar")]
    [Tooltip("Esta opción es para objetos que pueden actualizarse en escena con la subida y bajada del agua")]
    [SerializeField] bool actualizar;
    void Start()
    {
        registrarAguaPrevia = ListWaters.listWaters.infoAguas[aguaData].porcentajeAgua;
        if (ListWaters.listWaters.infoAguas[aguaData].porcentajeAgua < porcentajeAguaSpawn)
        {
            objeto.transform.position = spawnInicial.position;
        }
        else if(ListWaters.listWaters.infoAguas[aguaData].porcentajeAgua >= porcentajeAguaSpawn)
        {
            objeto.transform.position = spawnPostAgua.position;
        }
    }
    private void Update()
    {
        if (actualizar)
        {
            ActualizarObjetoAgua();
        }
    }
    void ActualizarObjetoAgua()
    {
        if(registrarAguaPrevia != ListWaters.listWaters.infoAguas[aguaData].porcentajeAgua)
        {
            if (ListWaters.listWaters.infoAguas[aguaData].porcentajeAgua < porcentajeAguaSpawn)
            {
                objeto.transform.position = spawnInicial.position;
                registrarAguaPrevia = ListWaters.listWaters.infoAguas[aguaData].porcentajeAgua;
            }
            else if (ListWaters.listWaters.infoAguas[aguaData].porcentajeAgua >= porcentajeAguaSpawn)
            {
                objeto.transform.position = spawnPostAgua.position;
                registrarAguaPrevia = ListWaters.listWaters.infoAguas[aguaData].porcentajeAgua;
            }
        }
    }
}
