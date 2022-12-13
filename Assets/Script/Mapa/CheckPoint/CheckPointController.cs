using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static int numeroCheckPoint;
    public Transform player;
    public Transform[] checkpoints;
    [Header("Spawn a Eleccion")]
    public bool elegirSpawn;
    public int spawnElegido;

    //Cuando se recarga la escena apareces en el ultimo Checkpoint
    private void Start()
    {
        player.position = checkpoints[numeroCheckPoint].position;
        if (elegirSpawn)
        {
            player.position = checkpoints[spawnElegido].position;
        }
    }

}
