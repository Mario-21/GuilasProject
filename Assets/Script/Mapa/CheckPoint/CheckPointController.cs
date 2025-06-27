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
    [Header("Orientacion Player")]
    [SerializeField] Transform puntoReferencia;
    int numOrientaciones;


    //Cuando se recarga la escena apareces en el ultimo Checkpoint
    private void Start()
    {
        player.transform.position = checkpoints[numeroCheckPoint].position;
        if (elegirSpawn)
        {
            player.transform.position = checkpoints[spawnElegido].position;
        }
        DistanciaReferencia();
        OrientacionSpawn();
    }
    private void Update()
    {
        if(numOrientaciones < 1)
        {
            Debug.Log("La distancia de referencia es de " + DistanciaReferencia());

            DistanciaReferencia();
            OrientacionSpawn();
            numOrientaciones++;
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
