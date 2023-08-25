using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class WetSwich : MonoBehaviour
{
    public int indexMod;
    [Header("Water")]
    public GameObject water;
    ActivarModificador activar;
    CeiilingFan ceiiling;
    [Header("Soldier Switch")]
    [SerializeField] SoldierLife soldierSwitchLife;
    bool enemyHere;
    float timeOnCeiling;
    [Header("Switch Sound")]
    [SerializeField] EventReference electricity;
    StudioEventEmitter emitterElec;
    int soundEffect;
    void Start()
    {
        emitterElec = AudioManager.instancia.InitializeEventEmitter(electricity, this.gameObject);
        activar = GetComponent<ActivarModificador>();
        ceiiling = GetComponent<CeiilingFan>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            SwitchWet();
        }
    }
    void Update()
    {
        if (activar.modificacion) SwitchWet();
        //The switch is wet
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            if (soundEffect < 1)
            {
                emitterElec.Play();
                soundEffect++;
            }
            if (enemyHere)
            {
                SoldierTakeDamageWet();
            }
        }
    }
    void SwitchWet()
    {
        ceiiling.emitterCeilingFan.Stop();
        water.SetActive(true);
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        ceiiling.onCeilingFan = false;
        ceiiling.enabled = false;
    }
    void SoldierTakeDamageWet()
    {
        if (enemyHere && soldierSwitchLife.vida > 0)
        {
            timeOnCeiling += Time.deltaTime;
            if (timeOnCeiling > 1)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.electroDamage);
                soldierSwitchLife.Daño(3);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) enemyHere = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) enemyHere = false;
    }
}
