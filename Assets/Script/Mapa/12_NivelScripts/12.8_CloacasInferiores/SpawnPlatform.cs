using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public Transform spawn;
    [HideInInspector] public int count;
    void Update()
    {
        //Se hace en el update para asegurarte de que va a Spawnear bien, sin ningun problema a la hora de calcular la posicion de agua
        if (count < 1)
        {
            RepositionPlatform();
            count++; 
        }
    }
    public void RepositionPlatform()
    {
        transform.position = spawn.position;
    }

}
