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
    VentiladorBombilla ceiiling;
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
        ceiiling = GetComponent<VentiladorBombilla>();
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
        //ceiiling.cabezaVentilador.sprite = ceiiling.ventiladorOff;
        //ceiiling.luzFake.SetActive(false);
        water.SetActive(true);
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        ceiiling.onCeilingFan = false;
        ceiiling.enabled = false;
        activar.enabled = false;
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
