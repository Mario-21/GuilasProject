using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepPowderCinematic : MonoBehaviour
{
    [Header("Regresar Nivel Anterior")]
    public int regretScene;
    public int checkpoint;
    [Header("Escena Info")]
    [SerializeField]Transform brazoSoldier;
    public float timeRotateLimit;
    float timeRotate;

    enum SceneSleepPowder
    {
        First,
        Second
    }
    SceneSleepPowder sleepScene;
    float timeBetweenScene;

    void Update()
    {
        SleepPowder();
    }
    void Drink()
    {
        if (timeRotate < timeRotateLimit)
        {
            //Bebe La bebida
            timeRotate += Time.deltaTime;
            brazoSoldier.Rotate(0f, 0f, 1f);
        }
        else
        {
            sleepScene = SceneSleepPowder.Second;
        }
    }
    void SleepPowder()
    {
        switch (sleepScene)
        {
            case SceneSleepPowder.First:
                timeBetweenScene += Time.deltaTime;
                if(timeBetweenScene >= 3)
                {
                    Drink();
                }
                break;
            case SceneSleepPowder.Second:
                CheckPointController.numeroCheckPoint = checkpoint;
                EstructuraNiveles.nivel = regretScene;
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                break;
        }
    }
}
