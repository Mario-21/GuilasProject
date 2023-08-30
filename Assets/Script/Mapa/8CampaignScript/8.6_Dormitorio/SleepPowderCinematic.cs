using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepPowderCinematic : MonoBehaviour
{
    public int indexMod;
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

    int audiReproduce;

    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }
    void Update()
    {
        SleepPowder();
    }
    void Drink()
    {
        if (timeRotate < timeRotateLimit)
        {
            //Bebe La bebida
            if(audiReproduce < 1)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.drinkEnemy);
                audiReproduce++;
            }
            timeRotate += Time.deltaTime;
            brazoSoldier.Rotate(0f, 0f, 1f);
        }
        else
        {
            sleepScene = SceneSleepPowder.Second;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
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
