using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoviceSoldier : MonoBehaviour
{
    public static NoviceSoldier noviceDeathLife;

    public int indexStop;
    [Header("Time Limit Novice Survive")]
    public float limitTimeDeathNovice;
    public float timeNoviceDeath;
    [Header("Time Options")]
    public int indexExceedTime;
    public int indexMinusTime;
    private void Awake()
    {
        if (NoviceSoldier.noviceDeathLife == null)
        {
            NoviceSoldier.noviceDeathLife = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        StopTime();
        OptionsTime();
    }

    void StopTime()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexStop].modificacion)
        {
            timeNoviceDeath += Time.deltaTime;
        }
    }
    void OptionsTime()
    {

        if (timeNoviceDeath > limitTimeDeathNovice)
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
}
