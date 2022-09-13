using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoviceSoldier : MonoBehaviour
{
    public int indexStop;
    [Header("Time Limit Novice Survive")]
    public float limitTimeDeathNovice;
    [Header("Time Options")]
    public int indexExceedTime;
    public int indexMinusTime;
    void Start()
    {
        
    }
    void Update()
    {
        StopTime();
        OptionsTime();
    }
    void OptionsTime()
    {
        if (SaveScene.instancia.timeNoviceDeath > limitTimeDeathNovice)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexExceedTime].modificacion = true;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMinusTime].modificacion = false;
        }
        else
        {

            StatusGameobjectsVariables.statusGameobject.modificacion[indexMinusTime].modificacion = true;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexExceedTime].modificacion = false;
        }
    }
    void StopTime()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexStop].modificacion)
        {
            SaveScene.instancia.timeNoviceDeath += Time.deltaTime;
        }
    }
}
