using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceOneSoldier : MonoBehaviour
{
    public Transform soldier;
    public float magnitudSoldier;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        magnitudSoldier = distancia().magnitude;
    }
    Vector2 distancia()
    {
        Vector2 DistanceSoldier;
        return DistanceSoldier = soldier.position - transform.position;
    }
}
