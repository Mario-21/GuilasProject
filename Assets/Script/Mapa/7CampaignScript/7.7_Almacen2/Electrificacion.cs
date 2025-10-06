using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Electrificacion : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] VidaPlayer playerVida;
    [SerializeField] BloquearMovimientoPlayer playerBlock;
    [Header("Atributes Empuje")]
    public float timeOnPlayerLimit;
    public float timeOnPlayer;
    bool enabledMov;

    float repeatDamage;
    public bool canRepeat;

    [Header("Electricidad SFX")]
    [SerializeField] EventReference electricitySFX;
    EventInstance electricity;
    private void Start()
    {
        electricity = AudioManager.instancia.CreateEventInstance(electricitySFX);
        electricity.start();
    }
    void Update()
    {
        //Creo que no voy a añadir fuerzas, pondré unos efectos con partículas uno animación de electrocución y ya
        Electricity();
        RepeatDamage();
    }
    void Electricity()
    {
        if (enabledMov)
        {
            timeOnPlayer += Time.deltaTime;
            if (timeOnPlayer >= timeOnPlayerLimit)
            {
                playerBlock.HabilitarMovPlayer();
                timeOnPlayer = 0;
                enabledMov = false;
            }
        }
    }
    void RepeatDamage()
    {
        if (canRepeat)
        {
            repeatDamage += Time.deltaTime;
            if (repeatDamage >= timeOnPlayerLimit + 0.1)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.electroDamage);
                playerVida.Daño(25);
                //No inhabilitar llamar al bloqueoPlayer
                playerBlock.BloquearMovConDaño();
                enabledMov = true;
                repeatDamage = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.electroDamage);
            playerVida.Daño(20);
            Debug.Log("Capela");
            playerBlock.BloquearMovConDaño();
            enabledMov = true;
            canRepeat = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canRepeat = false;
            playerBlock.HabilitarMovPlayer();
            Debug.Log("El jugador ha entrado a Rango.");
            repeatDamage = 0;
        }
    }
    private void OnDestroy()
    {
        electricity.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
