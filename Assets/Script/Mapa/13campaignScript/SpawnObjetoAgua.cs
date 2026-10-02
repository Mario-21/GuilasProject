using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjetoAgua : MonoBehaviour
{
    [Header("Info Agua")]
    public int aguaData;
    public int porcentajeAguaSpawn;
    [Header("Info Objeto")]
    [SerializeField] GameObject objeto;
    [SerializeField] Transform spawnInicial;
    [SerializeField] Transform spawnPostAgua;
    void Start()
    {
        if (ListWaters.listWaters.infoAguas[aguaData].porcentajeAgua < porcentajeAguaSpawn)
        {
            objeto.transform.position = spawnInicial.position;
        }
        else if(ListWaters.listWaters.infoAguas[aguaData].porcentajeAgua >= porcentajeAguaSpawn)
        {
            objeto.transform.position = spawnPostAgua.position;
        }
        this.enabled = false;
    }
}
