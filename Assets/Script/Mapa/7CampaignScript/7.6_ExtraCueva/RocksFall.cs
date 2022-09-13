using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksFall : MonoBehaviour
{
    [Header("Range Spawn")]
    [SerializeField] Transform range1;
    [SerializeField] Transform range2;
    [Header("Rocks")]
    [SerializeField] GameObject rocks;
    [Header("Time Spawn Rocks")]
    public float timeBetweenRocks;
    public float timeBetweenLimit;
    [Header("Duration RocksFall")]
    public float timeRocksFall;
    public float timeRocksFallEnds;

    //Transform randomSpawn;

    public float positionRandom;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnRandomRock();
    }
    void SpawnRandomRock()
    {
        timeRocksFall += Time.deltaTime;
        if(timeRocksFall < timeRocksFallEnds)
        {
            timeBetweenRocks += Time.deltaTime;
            if(timeBetweenRocks >= timeBetweenLimit)
            {
                positionRandom = Random.Range(range1.position.x, range2.position.x);
                timeBetweenRocks = 0;
                Instantiate(rocks, new Vector3(positionRandom, range1.position.y, 0f), Quaternion.identity);
            }
            //Instantiate(rocks, randomSpawn,)
        }
    }
}
