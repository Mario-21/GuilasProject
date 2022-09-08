using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoviceSoldier : MonoBehaviour
{
    public float limitTimeDeathNovice;
    public int indexExceedTime;
    public int indexMinusTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SaveScene.instancia.timeNoviceDeath += Time.deltaTime;
        if (SaveScene.instancia.timeNoviceDeath > limitTimeDeathNovice)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexExceedTime].modificacion = true;
        }
        else 
        {
            Debug.Log("Dolencia");
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMinusTime].modificacion = true;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexExceedTime].modificacion = false;
        }
    }
}
