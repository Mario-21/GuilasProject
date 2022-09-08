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
    public int nivelInfarmary;
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
                DialogoCueva();
                break;
            case SceneCaves.Second:
                timeSceneCave += Time.deltaTime;
                if (timeSceneCave >= 3) 
                {
                    cinematicCave = SceneCaves.Third;
                    timeSceneCave = 0;
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
        if (caveEnemy)
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[indexExceedTime].modificacion)
            {
                if(dialogo < 1)
                {
                    Instantiate(globoDialogoDeath, globoUbi.position, Quaternion.identity);
                    dialogo++;
                    CheckPointController.numeroCheckPoint = checkpointDeath;
                    EstructuraNiveles.nivel = nivelDeath;
                    cinematicCave = SceneCaves.Second;
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
                    cinematicCave = SceneCaves.Second;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) caveEnemy = true;
    }
}
