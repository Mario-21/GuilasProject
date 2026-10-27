using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrasDerrumbar : MonoBehaviour
{
    [Header("Rumbling")]
    public int indexMod;
    [Header("Player Ubi")]
    [SerializeField] Transform player;

    [Header("Spawn Next Scene")]
    public int spawnA;
    public int spawnB;
    int siguientePuntoSpawn;
    void Update()
    {
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)DistanciaConPlayer();
    }
    void DistanciaConPlayer()
    {
        Vector2 distanciaConPlayer;

        distanciaConPlayer = player.transform.position - transform.position;

        if (distanciaConPlayer.x > 0) siguientePuntoSpawn = spawnA;
        else siguientePuntoSpawn = spawnB;
        
    }

    private void OnDestroy()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) CheckPointController.numeroCheckPoint = siguientePuntoSpawn;
        //Catch key in 3.2
    }
}
