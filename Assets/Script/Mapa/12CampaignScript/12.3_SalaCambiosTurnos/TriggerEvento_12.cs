using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TriggerEvento_12 : MonoBehaviour
{
    public int indexMod;
    public enum evento_12
    {
        Explosion,
        Overcharge,
        TanqueAgua
    }
    public evento_12 myEvent;
    [Header("Explosion Info")]
    public CinemachineVirtualCamera mainCamera;
    public float shakeForce;
    [Header("Overcharge Info")]
    public GameObject luz;
    public float timeBlink;
    public float timeBlinkLimit;
    public int countBlink;
    public int countBlinkLimit;
    [Header("TanqueAgua Info")]
    public GameObject gotas;

    public bool prueba;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //int total = numero_A % 2;

        //Debug.Log("El resto de la division es " + total);
        if(prueba) SelectEvento();
    }
    void SelectEvento()
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        //Selecciona de manera manual que evento quieres
        switch (myEvent)
        {
            case evento_12.Explosion:
                Explosion explosion = new Explosion();
                explosion.ShakeExplosion(mainCamera, shakeForce);
                break;
            case evento_12.Overcharge:
                Overcharge overcharge = new Overcharge();

                overcharge.BlinkLight(luz, ref countBlink, ref timeBlink);
                /*
                if (countBlink < countBlinkLimit)
                {
                    timeBlink += Time.deltaTime;
                    if(timeBlink >= timeBlinkLimit)
                    {
                        timeBlink = 0;
                        //countBlink++;
                    }
                }*/
                break;
            case evento_12.TanqueAgua:
                TanqueAgua waterTank = new TanqueAgua();
                waterTank.WaterBreakTank(gotas);
                break;
        }
    }
}
