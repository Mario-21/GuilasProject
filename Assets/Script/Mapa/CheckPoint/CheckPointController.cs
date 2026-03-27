using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static int numeroCheckPoint;
    public GameObject player;
    public Transform[] checkpoints;
    [Header("Spawn a Eleccion")]
    public bool elegirSpawn;
    public int spawnElegido;
    [Header("Orientacion Player por Referencia")]
    [SerializeField] Transform puntoReferencia;
    int numOrientaciones;
    [Header("Orientacion Player por Index")]
    public int indexOrientacion;
    [Range(-1, 1)]
    public int orientacionInicial;
    public enum TipoOrientacionCheckpoint
    {
        Punto_Referencia,
        Index,
    }
    public TipoOrientacionCheckpoint tipoSpawnOrientacion;

    //Cuando se recarga la escena apareces en el ultimo Checkpoint
    private void Start()
    {
        player.transform.position = checkpoints[numeroCheckPoint].position;
        if (elegirSpawn)
        {
            player.transform.position = checkpoints[spawnElegido].position;
        }
        switch (tipoSpawnOrientacion)
        {
            case TipoOrientacionCheckpoint.Punto_Referencia:
                DistanciaReferencia();
                OrientacionSpawn();
                break;
            case TipoOrientacionCheckpoint.Index:
                if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexOrientacion].modificacion)
                {
                    player.transform.localScale = new Vector3(orientacionInicial, 1, 1);
                }
                else
                {
                    player.transform.localScale = new Vector3(ListDataPlayer.listDataPlayer.orientacionPlayer, 1, 1);
                }
                break;
        }
    }
    private void Update()
    {
        if (numOrientaciones < 1)
        {
            switch (tipoSpawnOrientacion)
            {
                case TipoOrientacionCheckpoint.Punto_Referencia:
                    Debug.Log("La distancia de referencia es de " + DistanciaReferencia());
                    DistanciaReferencia();
                    OrientacionSpawn();
                    numOrientaciones++;
                    break;
                case TipoOrientacionCheckpoint.Index:
                    if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexOrientacion].modificacion)
                    {
                        player.transform.localScale = new Vector3(orientacionInicial, 1, 1);
                        StatusGameobjectsVariables.statusGameobject.modificacion[indexOrientacion].modificacion = true;
                    }
                    else
                    {
                        player.transform.localScale = new Vector3(ListDataPlayer.listDataPlayer.orientacionPlayer, 1, 1);
                    }
                    numOrientaciones++;
                    break;
            }
        }
    }
    void OrientacionSpawn()
    {
        if(DistanciaReferencia().x < 0)
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (DistanciaReferencia().x > 0)
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public Vector2 DistanciaReferencia()
    {
        Vector2 distanciaReferencia;
        return distanciaReferencia = player.transform.position - puntoReferencia.position;
        
    }

}
