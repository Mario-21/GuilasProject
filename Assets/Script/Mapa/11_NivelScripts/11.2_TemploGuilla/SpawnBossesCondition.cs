using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossesCondition : MonoBehaviour
{
    [SerializeField] Transform spawn;
    [Header("Soldier Info")]
    [SerializeField] Transform ubiSoldado;
    [SerializeField] SoldierLife soldadoLife;
    [Header("Time Spawnear")]
    [SerializeField] float timeLimitSpawn;
    float timeSpawn;
    void Update()
    {
        if(timeSpawn >= timeLimitSpawn)
        {
            if (soldadoLife.vida > 0) ubiSoldado.position = spawn.position;
            this.enabled = false;
        }
        else
        {
            timeSpawn += Time.deltaTime;
        }
    }
}
