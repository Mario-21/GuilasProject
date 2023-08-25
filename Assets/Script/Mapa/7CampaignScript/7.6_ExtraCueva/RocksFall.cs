using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMOD.Studio;


public class RocksFall : MonoBehaviour
{
    public int indexMod;
    [Header("Range Spawn")]
    [SerializeField] Transform range1;
    [SerializeField] Transform range2;
    [Header("Range Particles")]
    [SerializeField] Transform range1Particle;
    [SerializeField] Transform range2Particle;
    [Header("Rocks")]
    [SerializeField] GameObject rocks;
    [SerializeField] GameObject particleRocks;
    [Header("Time Spawn Rocks")]
    public float timeBetweenRocks;
    public float timeBetweenLimit;
    [Header("Time Particle")]
    public float timeBetweenParticle;
    [Header("Duration RocksFall")]
    public float timeRocksFall;
    public float timeRocksFallEnds;
    [Header("Camera Shake")]
    [SerializeField] CinemachineVirtualCamera cmCamera_1;

    //Transform randomSpawn;

    public float positionRandom;

    int stablishOnce;

    EventInstance rumblingInstance;
    int onceRumblingSFX;
    void Start()
    {
        rumblingInstance = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.rumbling);
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) SpawnRandomRock();
    }
    void SpawnRandomRock()
    {
        if(timeRocksFall < timeRocksFallEnds)
        {
            if(onceRumblingSFX < 1)
            {
                rumblingInstance.start();
                onceRumblingSFX++;
            }
            //ShaKe Camera
            cmCamera_1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
            //Time Duration
            timeRocksFall += Time.deltaTime;
            //Time Spawn
            timeBetweenRocks += Time.deltaTime;
            //Estableces la posicion random
            if(stablishOnce < 1)
            {
                positionRandom = Random.Range(range1.position.x, range2.position.x);
                stablishOnce++;
            }
            //Spawneas la particula antes 
            if(timeBetweenRocks >= timeBetweenParticle && stablishOnce < 2)
            {
                Instantiate(particleRocks, new Vector3(positionRandom, range1Particle.position.y, 0f), Quaternion.identity);
                stablishOnce++;
            }
            //Spawneas la Roca 
            if (timeBetweenRocks >= timeBetweenLimit)
            {
                Instantiate(rocks, new Vector3(positionRandom, range1.position.y, 0f), Quaternion.identity);
                timeBetweenRocks = 0;
                stablishOnce = 0;
            }
        }
        else 
        {
            rumblingInstance.stop(STOP_MODE.ALLOWFADEOUT);
            cmCamera_1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
