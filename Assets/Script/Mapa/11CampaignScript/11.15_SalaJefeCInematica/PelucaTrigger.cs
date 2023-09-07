using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PelucaTrigger : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] int indexPeluca;
    [SerializeField] MovPlayerCin movPlayer;
    [Header("Enemy Data")]
    public Transform boss;
    [Range(-1,1)]
    public int girar;
    [Header("Enemy Dialogue")]
    public Transform ubiGloboEnemy;
    public GameObject globo;
    GameObject globoCopy;
    [Header("Time Enemy Dialogue")]
    public float timeEnemyTalkLimit;
    float enemyTalk;
    [Header("Out Scene")]
    public int nextScene;
    public int checkPoint;

    bool stopPlayer;
    enum TalkEnemyPeluca
    {
        Girarse,
        TalkPlayer,
        End
    }
    TalkEnemyPeluca talkEnemy;
    [Header("Audio_Ascensor")]
    [SerializeField] EventReference audioAscensor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NicePeluca();
    }
    void NicePeluca()
    {
        if (stopPlayer)
        {
            //Paras al Player
            movPlayer.enabled = false;
            movPlayer.anim.SetBool("Walk", false);
            //Habla el enemigo
            EnemyTalk();
        }
    }
    void EnemyTalk()
    {
        switch (talkEnemy)
        {
            case TalkEnemyPeluca.Girarse:
                enemyTalk += Time.deltaTime;
                if(enemyTalk >= timeEnemyTalkLimit)
                {
                    boss.transform.localScale = new Vector3(girar, 1, 1);
                    talkEnemy = TalkEnemyPeluca.TalkPlayer;
                    enemyTalk = 0;
                }
                break;
            case TalkEnemyPeluca.TalkPlayer:
                enemyTalk += Time.deltaTime;
                if(enemyTalk >= timeEnemyTalkLimit)
                {
                    globoCopy = Instantiate(globo, ubiGloboEnemy.transform.position, Quaternion.identity);
                    globoCopy.transform.parent = ubiGloboEnemy;
                    talkEnemy = TalkEnemyPeluca.End;
                    enemyTalk = 0;
                }
                break;
            case TalkEnemyPeluca.End:
                enemyTalk += Time.deltaTime;
                if(enemyTalk >= timeEnemyTalkLimit)
                {
                    AudioManager.instancia.PlayOneShot(audioAscensor);
                    EstructuraNiveles.nivel = nextScene;
                    AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                    CheckPointController.numeroCheckPoint = checkPoint;
                }
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[indexPeluca].modificacion)
            {
                stopPlayer = true;
            }
        }
    }
}
