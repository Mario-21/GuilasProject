using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicBoss : MonoBehaviour
{
    public int indexMod;
    enum OrderTalk
    {
        firstDialogue,
        secondDialogue,
        End
    }
    OrderTalk talking;

    [Header("Time to Talk")]
    public float firstTalk;
    public float secondTalk;
    float timeTalk;
    [Header("Dialogue Enemy")]
    public Transform ubiGloboEnemy;
    public GameObject globoEntregar;
    GameObject copiaEnemyGlobo;
    [Header("Dialogue Player")]
    public Transform ubiGloboPlayer;
    public GameObject globoConfirm;
    GameObject copiaPlayerGlobo;
    [Header("Player Data")]
    public MovPlayerCin playerMov;

    int contadorTalk;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Talking();
    }
    void Talking()
    {
        switch (talking)
        {
            case OrderTalk.firstDialogue:
                timeTalk += Time.deltaTime;
                if(timeTalk > firstTalk)
                {
                    //Coloca el Dialogo
                    copiaEnemyGlobo = Instantiate(globoEntregar, ubiGloboEnemy.transform.position, Quaternion.identity);
                    //Cambiar segundo Dialogo
                    talking = OrderTalk.secondDialogue;
                    //Resetea el tiempo
                    timeTalk = 0;
                }
                break;
            case OrderTalk.secondDialogue:
                timeTalk += Time.deltaTime;
                if(timeTalk > secondTalk)
                {
                    //Destruye el Anterior dialogo para que no se solape
                    Destroy(copiaEnemyGlobo);
                    //Colocar Dialogo Player
                    copiaPlayerGlobo = Instantiate(globoConfirm, ubiGloboPlayer.transform.position, Quaternion.identity);
                    copiaPlayerGlobo.transform.parent = ubiGloboPlayer;
                    //Cambiar End
                    talking = OrderTalk.End;
                    //Resetea el tiempo
                    timeTalk = 0;
                }
                break;
            case OrderTalk.End:
                timeTalk += Time.deltaTime;
                if(timeTalk > firstTalk)
                {
                    Destroy(copiaPlayerGlobo);
                    playerMov.enabled = true;
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                }
                break;
        }
    }
}
