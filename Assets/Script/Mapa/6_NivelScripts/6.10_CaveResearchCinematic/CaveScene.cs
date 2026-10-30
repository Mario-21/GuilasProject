using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveScene : MonoBehaviour
{
    int dialogo;
    bool caveEnemy;
    public int indexModFinish;
    [Header("Index Conditions")]
    public int indexExceedTime;
    public int indexMinusTime;
    [Header("Niveles")]
    public int nivelDeath;
    public string nombreEscenaMuerte;
    public int nivelInfarmary;
    public string nombreEscenaEnfermeria;
    [Header("Checkpoints")]
    public int checkpointDeath;
    public int checkpointInfarmary;
    [Header("Globo Dialogos")]
    public GameObject globoDialogoDeath;
    public GameObject globoDialogoInfarmary;
    [Header("Globo Position")]
    public Transform globoUbi;
    enum SceneCaves
    {
        Firts,
        Second,
        Third
    }
    SceneCaves cinematicCave;

    float timeSceneCave;
    public float timeSceneCaveLimit;

    float timeDurationDialogo;
    public float timeDurationDialogoLimit;

    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModFinish].modificacion) this.enabled = false;
    }
    void Update()
    {
        CaveCinematic();
    }
    void CaveCinematic()
    {
        switch (cinematicCave)
        {
            case SceneCaves.Firts:
                //Secuencia de Andar
                if (timeSceneCave >= timeSceneCaveLimit)
                {
                    cinematicCave = SceneCaves.Second;
                    timeSceneCave = 0;
                }
                else
                {
                    timeSceneCave += Time.deltaTime;
                }
                break;
            case SceneCaves.Second:
                DialogoCueva();

                timeDurationDialogo += Time.deltaTime;
                if(timeDurationDialogo >= timeDurationDialogoLimit)
                {
                    cinematicCave = SceneCaves.Third;
                }
                break;
            case SceneCaves.Third:
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                StatusGameobjectsVariables.statusGameobject.modificacion[indexModFinish].modificacion = true;
                break;
        }
    }
    void DialogoCueva()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexExceedTime].modificacion)
        {
            if (dialogo < 1)
            {
                Instantiate(globoDialogoDeath, globoUbi.position, Quaternion.identity);
                dialogo++;
                CheckPointController.numeroCheckPoint = checkpointDeath;
                EstructuraNiveles.nivel = nivelDeath;
                EstructuraNiveles.nombreNivel = nombreEscenaMuerte;
            }
        }
        else if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMinusTime].modificacion)
        {
            if (dialogo < 1)
            {
                Instantiate(globoDialogoInfarmary, globoUbi.position, Quaternion.identity);
                dialogo++;
                CheckPointController.numeroCheckPoint = checkpointInfarmary;
                EstructuraNiveles.nivel = nivelInfarmary;
                EstructuraNiveles.nombreNivel = nombreEscenaEnfermeria;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Enemy")) caveEnemy = true;
    }
}
