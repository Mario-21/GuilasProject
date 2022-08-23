using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoviceSoldier : MonoBehaviour
{
    public float limitTimeDeathNovice;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SaveScene.instancia.timeNoviceDeath += Time.deltaTime;
    }
}
