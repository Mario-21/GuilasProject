using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public Transform spawn;
    int count;
    void Update()
    {
        if (count < 1)
        {
            transform.position = spawn.position;
            count++;
            Debug.Log("White Snake"); 
        }
    }

}
