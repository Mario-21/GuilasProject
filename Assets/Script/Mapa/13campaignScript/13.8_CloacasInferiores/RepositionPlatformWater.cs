using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionPlatformWater : MonoBehaviour
{
    int saveWater;

    public WaterData water;
    public List<SpawnPlatform> platforms;
    void Start()
    {
        saveWater = water.porcentajeAgua;
    }

    // Update is called once per frame
    void Update()
    {
        DiferentVolumeWater();
    }
    void DiferentVolumeWater()
    {
        //El Volumen del agua a cambiado, por tanto, debe reposicionar las plataformas
        if(saveWater != water.porcentajeAgua)
        {
            for(int e = 0; e < platforms.Count; e++)
            {
                platforms[e].RepositionPlatform();
                Debug.Log("La plataforma " + e + " se ha reposicionado");
            }
            saveWater = water.porcentajeAgua;
        }
    }
}
