using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CeiilingFan : MonoBehaviour
{
    public int indexMod;
    [Header("Velocidad")]
    public float speed;
    public  bool onCeilingFan;
    [Header("On Ceiling Fan")]
    [SerializeField] Transform ceilingFan;
    [Header("Soldier Switch")]
    [SerializeField] SoldierLife soldierSwitchLife;
    public float timeOnCeilingLimit = 1.5f;
    float timeOnCeiling;
    bool enemyHere;

    [Header("Ceiling Fan SFX")]
    [SerializeField] EventReference ceilingSFX;
    public StudioEventEmitter emitterCeilingFan;
    [SerializeField] GameObject ceiling;

    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        emitterCeilingFan = AudioManager.instancia.InitializeEventEmitter(ceilingSFX, ceiling);
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) emitterCeilingFan.Play();
    }
    void Update()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ActiveCeilingFan();
            CeilingFan();
            SoldierOnCeiling();
        }
        else
        {
            emitterCeilingFan.Stop();
        }
    }
    void ActiveCeilingFan()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
                onCeilingFan = !onCeilingFan;
                SoundCeilingFan();
            }
        }
        
    }
    void CeilingFan()
    {
        if (onCeilingFan)
        {
            ceilingFan.Rotate(0f, speed, 0f);
        }
        else
        {
            ceilingFan.Rotate(0f, 0f, 0f);
        }
    }
    void SoldierOnCeiling()
    {
        //On Ceiling Pan
        if (enemyHere && soldierSwitchLife.vida > 0)
        {
            timeOnCeiling += Time.deltaTime;
            if (timeOnCeiling >= timeOnCeilingLimit)
            {
                onCeilingFan = true;
                emitterCeilingFan.Stop();
                timeOnCeiling = 0;
                enemyHere = false;
            }
        }
        else
        {
            timeOnCeiling = 0;
        }
    }
    void SoundCeilingFan()
    {
        if (onCeilingFan)
        {
            emitterCeilingFan.Play();
        }
        else
        {
            emitterCeilingFan.Stop();
        }
    }
    private void OnDisable()
    {
        emitterCeilingFan.Stop();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) enemyHere = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            enemyHere = false;
            timeOnCeiling = 0;
        }
    }
}
